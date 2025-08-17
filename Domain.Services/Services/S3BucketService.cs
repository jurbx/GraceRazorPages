using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Http;

namespace Domain.Services.Services
{
    public class S3BucketService : IS3BucketService
    {
        string keyId = "AKIAZKOFJPO5MXE3JWZB";
        string secretKey = "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";
        string bucketName = "grace-furniture";
        RegionEndpoint region = RegionEndpoint.EUWest2;

        public async Task UploadFileAsync(IFormFile formFile, string? newFilename = null)
        {
            using (var client = new AmazonS3Client(keyId, secretKey, region))
            {
                using (var memoryStream = new MemoryStream())
                {
                    formFile.CopyTo(memoryStream);

                    var request = new TransferUtilityUploadRequest
                    {
                        InputStream = memoryStream,
                        Key = newFilename ?? formFile.FileName,
                        BucketName = bucketName,
                        ContentType = formFile.ContentType
                    };

                    var transferUtility = new TransferUtility(client);
                    await transferUtility.UploadAsync(request);
                }
            }
        }

        public async Task<Stream> GetByFilenameAsync(string fileName)
        {

            using (var client = new AmazonS3Client(keyId, secretKey, region))
            {
                var transferUtility = new TransferUtility(client);
                var objectRequest = new GetObjectRequest()
                {
                    BucketName = bucketName,
                    Key = fileName
                };
                var response = await transferUtility.S3Client.GetObjectAsync(objectRequest);
                return response.ResponseStream;
            }
        }

        public async Task DeleteFileAsync(string fileName)
        {

            using (var client = new AmazonS3Client(keyId, secretKey, region))
            {
                var transferUtility = new TransferUtility(client);
                var objectRequest = new DeleteObjectRequest()
                {
                    BucketName = bucketName,
                    Key = fileName
                };
                var response = await transferUtility.S3Client.DeleteObjectAsync(objectRequest);
            }
        }
    }
}
