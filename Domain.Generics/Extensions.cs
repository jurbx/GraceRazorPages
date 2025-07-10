using System.Security.Cryptography;
using System.Text;

namespace Domain.Generics
{
    public static class Extensions
    {
        public static string HashStringSHA512(this string text)
        {
            string hash = string.Empty;

            using (HashAlgorithm algorithm = SHA512.Create())
            {
                var stringByte = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
                hash = Encoding.UTF8.GetString(stringByte);
            }

            return hash;
        }
    }
}
