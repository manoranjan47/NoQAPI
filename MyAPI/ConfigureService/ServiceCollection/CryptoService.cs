using System.Security.Cryptography;
using System.Text;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class CryptoService
    {
        private readonly string secretKey = "MySecretKey123!@#";

        public string Encrypt(object data)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(secretKey);
                aesAlg.IV = new byte[16]; // Use Initialization Vector for additional security

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                            swEncrypt.Write(jsonData);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public object Decrypt(string encryptedData)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(secretKey);
                aesAlg.IV = new byte[16]; // Use Initialization Vector for additional security

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedData)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            string jsonData = srDecrypt.ReadToEnd();
                            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);
                        }
                    }
                }
            }
        }

        public string EncryptForUrl(object data)
        {
            string encryptedData = Encrypt(data);
            string urlEncodedData = Uri.EscapeDataString(encryptedData).Replace("/", "_");
            return urlEncodedData;
        }

        public object DecryptFromUrl(string urlEncodedData)
        {
            string encryptedData = Uri.UnescapeDataString(urlEncodedData.Replace("_", "/"));
            return Decrypt(encryptedData);
        }
    }
}
