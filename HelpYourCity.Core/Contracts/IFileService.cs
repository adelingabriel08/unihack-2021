using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using HelpYourCity.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HelpYourCity.Core.Contracts
{
    public interface IFileService
    {
        Task<UploadedFile> UploadAsync(IFormFile file);
    }
}