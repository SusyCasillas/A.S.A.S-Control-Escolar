using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http.Headers;

namespace A.S.A.S_Control_Escolar.ExternalTools
{
    public class FileControl
    {
        
        private const string PATH_TEMP = "\\ASAS\\temp\\";
        private const string PATH_FILES = "\\ASAS\\Files\\";
        public string SaveFile(IWebHostEnvironment environment, IFormFile imgFile, string idUser)
        {
            string fileName = ContentDispositionHeaderValue.Parse(imgFile.ContentDisposition).FileName.Trim('"');
            string folderName = CreateUserFolder(environment, idUser);
            if (fileName.Contains("\\"))
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            string fullFileName = folderName + fileName;

            using (FileStream stream = File.Create(fullFileName))
            {
                imgFile.CopyTo(stream);
            }
            return fullFileName;
        }
        public static string SaveTemporalFile(IWebHostEnvironment environment, IFormFile file)
        {
            string fileName, folderName, fullFileName;
            fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            folderName = CreateTempFolder(environment);
            if (fileName.Contains("\\"))
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            fullFileName = folderName + fileName;
            using (FileStream stream = File.Create(fullFileName))
            {
                file.CopyTo(stream);
            }
            return fullFileName;
        }
        public static void DropTemporalFile(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
        }
        public string CreateUserFolder(IWebHostEnvironment environment, string idUser)
        {
            string fullPath = Directory.GetCurrentDirectory() + PATH_FILES + "Files_" + idUser + "\\";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            return fullPath;
        }
        public static string CreateTempFolder(IWebHostEnvironment environment)
        {
            string fullPath = Directory.GetCurrentDirectory() + PATH_TEMP;
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            return fullPath;
        }
        public static string ConvertImage(string imgPath)
        {
            string dev = string.Empty;
            using (Image img = Image.FromFile(imgPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    byte[] arr = ms.ToArray();
                    dev = Convert.ToBase64String(arr);
                }
            }
            return dev;
        }
        public static string ConvertImage()
        {
            string dev = string.Empty;
            using (Image img = Image.FromFile(Directory.GetCurrentDirectory() + PATH_FILES +"imgDefault.png"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    byte[] arr = ms.ToArray();
                    dev = Convert.ToBase64String(arr);
                }
            }
            return dev;
        }
    }
}
