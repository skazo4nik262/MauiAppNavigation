using System.Security.Cryptography;
using System.Text;

namespace MauiApp1
{
    public class MyHash
    {
        private static MyHash instance;
        public static MyHash Instance { get { return instance ??= new MyHash(); } }
        public string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }

}
