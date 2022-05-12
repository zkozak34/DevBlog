using System.Security.Cryptography;
using System.Text;

namespace DevBlog.Service.Utilities.Hashing
{
    public class Security 
    {
        
        public static string Encrypt(string plainText)
        {
            using (SHA256 cryptoService = SHA256.Create())
            {
                var beforeHash = plainText.Substring(0, plainText.Length / 2) + ServiceRegistration.SaltKey +
                                 plainText.Substring((plainText.Length / 2));
                byte[] sourceBytes = Encoding.UTF8.GetBytes(beforeHash);
                byte[] hashBytes = cryptoService.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }
    }
}
