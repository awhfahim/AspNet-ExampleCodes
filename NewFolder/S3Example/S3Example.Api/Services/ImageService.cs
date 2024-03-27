using Microsoft.AspNetCore.Mvc;

namespace S3Example.Api.Services;

using Amazon.S3;
using Amazon.S3.Model;

public class ImageService(IAmazonS3 s3Client)
{
    public async Task<string> UploadImageAsync(IFormFile imageFile, string bucketName, string key)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new ArgumentNullException(nameof(imageFile));
        }

        var uploadRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = key,
            InputStream = imageFile.OpenReadStream(),
            ContentType = imageFile.ContentType
        };

        var response = await s3Client.PutObjectAsync(uploadRequest);

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            return await GetPresignedUrlAsync(bucketName, key, DateTime.Now.AddMinutes(30));
        }
        else
        {
            throw new Exception($"Error uploading image to S3: {response.HttpStatusCode}");
        }
    }
    
    public async Task<string> GetPresignedUrlAsync(string bucketName, string key, DateTime expiration)
    {
        try
        {
            var presignedUrl = await s3Client.GetPreSignedURLAsync(new GetPreSignedUrlRequest(){BucketName = bucketName, 
                Key = key, Expires = expiration, Verb = HttpVerb.GET});
            return presignedUrl;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating presigned URL: {ex.Message}");
            return null;
        }
    }
    
}
