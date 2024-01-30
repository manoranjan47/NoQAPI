using System.Security.Cryptography;
using System.Text;

namespace MyAPI.ConfigureService.ServiceCollection
{
     public class CryptoService
 {
          /*
     private const string key = "01234567890123456789012345678901";
     private const string iv = "0123456789ABCDEF";

     public string Encrypt(string plainText)
     {
         byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
         byte[] encryptedBytes;

         using (Aes aes = Aes.Create())
         {
             aes.Mode = CipherMode.CBC;
             aes.Key = Encoding.UTF8.GetBytes(key);
             aes.IV = Encoding.UTF8.GetBytes(iv);
             aes.Padding = PaddingMode.PKCS7;

             ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
             using (var msEncrypt = new MemoryStream())
             {
                 using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                 {
                     csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                     csEncrypt.FlushFinalBlock();
                 }
                 encryptedBytes = msEncrypt.ToArray();
             }
         }

         return Convert.ToBase64String(encryptedBytes);
     }

     public string Decrypt(string encryptedText)
     {
         byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
         string decryptedText;

         using (Aes aes = Aes.Create())
         {
             aes.Mode = CipherMode.CBC;
             aes.Key = Encoding.UTF8.GetBytes(key);
             aes.IV = Encoding.UTF8.GetBytes(iv);
             aes.Padding = PaddingMode.PKCS7;

             ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
             using (var msDecrypt = new MemoryStream(encryptedBytes))
             {
                 using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                 {
                     using (var srDecrypt = new StreamReader(csDecrypt))
                     {
                         decryptedText = srDecrypt.ReadToEnd();
                     }
                 }
             }
         }

         return decryptedText;
     }

     public string EncryptForUri(string plainText)
     {
         using (Aes aes = Aes.Create())
         {
             aes.Mode = CipherMode.CBC;
             aes.Key = Encoding.UTF8.GetBytes(key);
             aes.IV = Encoding.UTF8.GetBytes(iv);
             aes.Padding = PaddingMode.PKCS7;

             ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

             byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
             byte[] encryptedBytes;

             using (MemoryStream msEncrypt = new MemoryStream())
             {
                 using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                 {
                     csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                     csEncrypt.FlushFinalBlock();
                     encryptedBytes = msEncrypt.ToArray();
                 }
             }

             string base64Encoded = Convert.ToBase64String(encryptedBytes);
             string urlEncoded = Uri.EscapeDataString(base64Encoded).Replace("/", "_");

             return urlEncoded;
         }
     }

     public string DecryptFromUri(string encryptedForUri)
     {
         encryptedForUri = encryptedForUri.Replace("_", "/"); // Replace '_' with '/'

         string base64Encoded = Uri.UnescapeDataString(encryptedForUri);

         byte[] encryptedBytes = Convert.FromBase64String(base64Encoded);

         using (Aes aes = Aes.Create())
         {
             aes.Mode = CipherMode.CBC;
             aes.Key = Encoding.UTF8.GetBytes(key);
             aes.IV = Encoding.UTF8.GetBytes(iv);
             aes.Padding = PaddingMode.PKCS7;

             ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

             string decryptedText;

             using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
             {
                 using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                 {
                     using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                     {
                         decryptedText = srDecrypt.ReadToEnd();
                     }
                 }
             }

             return decryptedText;
         }
     }

     */
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
