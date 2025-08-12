using Microsoft.AspNetCore.Http;

namespace Domain.Services.Contracts.Services
{
    public interface IS3BucketService
    {
        Task<string> UploadFileAsync(IFormFile formFile, string? newFilename = null);
        Task<Stream> GetByFilenameAsync(string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
