using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NKS.Customers.API.Configuration;
using NKS.Customers.Core.Configuration;
using NKS.Customers.Infrastructure.Configuration;
using Serilog;

namespace NKS.Customers.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Log.Information("Configure services");
            services.Configure<Swagger>(Configuration.GetSection("SwaggerConfiguration"));
            //services.AddSingleton(provider => new MapperConfiguration
            //(
            //    cfg => cfg.AddProfile(new DatabaseProfile())
            //).CreateMapper());

            services
                .AddApiConfiguration(Configuration)
                .AddInfrastruture(Configuration["ConnectionStrings:CustomersDatabase"])
                .AddDomainServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var swaggerConfig = Configuration.GetSection("SwaggerConfiguration").Get<Swagger>();

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint($"/swagger/v{swaggerConfig.Version}/swagger.json", "NKS.Customers.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
