using System;
using System.Security.Cryptography;
using System.Text;

namespace NKS.Customers.API.Extensions
{
    public static class StringExtensions
    {
        public static string GetHashValue(this string content)
        {
            if (string.IsNullOrEmpty(content))
                return string.Empty;

            using var sha = new SHA256Managed();
            var textData = Encoding.UTF8.GetBytes(content);
            var hash = sha.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        public static bool HasValue(this string content)

        {
            return string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content);
        }
    }
}