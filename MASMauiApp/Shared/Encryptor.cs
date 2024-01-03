using System.Security.Cryptography;
using System.Text;

namespace AssetManagementApp.Shared
{
    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
                MD5 md5 = new MD5CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete

                //compute hash from the bytes of text
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

                //get hash result after compute it
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                byte[] result = md5.Hash;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits
                    //for each byte
                    strBuilder.Append(result[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
            return null;
        }
    }
}
