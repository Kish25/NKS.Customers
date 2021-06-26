using System;

namespace NKS.Customers.API.Configuration
{
    public class ApiInfo
    {
        public string   Version        { get; set; }
        public DateTime CreationDate   { get; set; }
        public Swagger  ApiVersionInfo { get; set; }
    }
}
