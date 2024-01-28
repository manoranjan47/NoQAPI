using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class FilesService : IFilesService
    {
        public async Task<string?> GetFilePath(string? base64WithImageType, string? path)
        {
            string? filePath = null;
            if (string.IsNullOrEmpty(base64WithImageType))
            {
                return filePath;
            }

            try
            {
                // Get the root path up to the 'uploads' folder
                var rootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "uploads"));

                // Ensure the 'uploads' folder exists, create if not
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }
                var rootPath2 = AppContext.BaseDirectory;
                var encodedImage = base64WithImageType.Split(',')[1];
                var decodedImage = Convert.FromBase64String(encodedImage);
                string imageType = base64WithImageType.Split(',')[0].Split('/')[1].Split(';')[0].ToString();
                string fileName = Guid.NewGuid() + "." + imageType;

                if (!string.IsNullOrEmpty(path))
                {
                    // If a custom path is provided, append it to the root path
                    rootPath = Path.GetFullPath(Path.Combine(rootPath, path));
                }

                // Ensure the subdirectory exists, create if not
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string localFilePath = Path.Combine(rootPath, fileName);

                using (var stream = new FileStream(localFilePath, FileMode.Create))
                {
                    await stream.WriteAsync(decodedImage, 0, decodedImage.Length);
                }
                var relativePath = Path.GetRelativePath(rootPath, localFilePath);

                // Replace backslashes with forward slashes
                filePath = relativePath.Replace(Path.DirectorySeparatorChar, '/');
            
                //filePath = localFilePath.Replace('\\', '/');

                filePath = Path.Combine("uploads",path,filePath);
                filePath = filePath.Replace('\\', '/');

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return filePath;
        }

        public async Task<string?> GenerateQRForTables(string frontUrl, int branchId, int tableId)
        {
            frontUrl = "http://localhost:5173";
            var rootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "uploads", "tableQr"));

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            string content = $"{frontUrl}/main/branch/branch-menu?branchId={branchId}&tableId={tableId}";

            string fileName = $"Delegate-{branchId}-{tableId}.png";
            string filePath = Path.Combine(rootPath, fileName);

            if (File.Exists(filePath))
            {
                // If the file already exists, delete it before creating a new one
                File.Delete(filePath);
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            qrCodeImage.Save(filePath, ImageFormat.Png);
            string result = "uploads/TableQr/" + fileName;

            return result;
        }

    }
}
