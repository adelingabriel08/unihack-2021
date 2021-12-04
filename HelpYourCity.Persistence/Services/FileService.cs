using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.EF;
using Microsoft.AspNetCore.Http;

namespace HelpYourCity.Persistence.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _dbContext;

        public FileService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UploadedFile> UploadAsync(IFormFile file)
        {
            

            var uploadedFilesDirectory = Path.Combine("content");
            if (!Directory.Exists(uploadedFilesDirectory))
            {
                Directory.CreateDirectory(uploadedFilesDirectory);
            }

            var fileEntity = new UploadedFile()
            {
                Name = SanitizeFileName(file.FileName) + "_" + GenerateRandomHexString(),
                Extension = Path.GetExtension(file.FileName).Substring(1).ToLower(),
                OrginalName = file.FileName
            };


            var filePath = Path.Combine(uploadedFilesDirectory, $"{fileEntity.Name}.{fileEntity.Extension}")
                .Replace("\\", "/");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            fileEntity.Path = filePath;

            var fileEntry = await _dbContext.UploadedFiles.AddAsync(fileEntity);

            await _dbContext.SaveChangesAsync();
            

            return fileEntry.Entity;
        }
        
        
        private string SanitizeFileName(string fileName)
        {
            var nfn = new StringBuilder();

            fileName = Path.GetFileNameWithoutExtension(fileName);
            
            foreach (var c in fileName)
            {
                if (Path.GetInvalidFileNameChars().Contains(c))
                {
                    nfn.Append("_");
                }
                else
                {
                    nfn.Append(c);
                }
            }

            return nfn.ToString();
        }
        
        private string GenerateRandomHexString(int length = 10)
        {
            var str = "";
            while (str.Length < length)
            {
                str += Guid.NewGuid().ToString().ToLower().Replace("-", "");
            }

            return str.Substring(0, length);
        }

    }

}