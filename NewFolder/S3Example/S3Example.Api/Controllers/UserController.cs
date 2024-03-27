using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using S3Example.Api.Services;

namespace S3Example.Api.Controllers;

public class UserController(ImageService imageService) : Controller
{
    [HttpPost]
    public async Task UploadProfilePicture(IFormFile profilePicture)
    {
        var userId = Guid.NewGuid(); // Replace with your logic to get user ID
        var key = $"profile-pictures/{Guid.NewGuid()}.jpg"; // Example key format

        try
        {
            var imageUrl = await imageService.UploadImageAsync(profilePicture, "my-imagestore-bucket", key);
            // Update user profile with image URL in your database
            //await UpdateUserProfilePicture(userId, imageUrl);
            
        }
        catch (Exception ex)
        {
           // return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet]
    public async Task GetProfilePictureUrl()
    {
        var key = $"1.jpg"; // Example key format
        var expirationTime = DateTime.Now.AddMinutes(30); // Adjust expiration time as needed

        try
        {
            var presignedUrl = await imageService.GetPresignedUrlAsync("my-imagestore-bucket", key, expirationTime);
            if (presignedUrl != null)
            {
                //return Ok(presignedUrl);
            }
            else
            {
                //return NotFound("Profile picture not found");
            }
        }
        catch (Exception ex)
        {
            //return StatusCode(500, ex.Message);
        }
    }
    /*
    [HttpGet]
    public async Task<IActionResult> GetProfilePictureUrl(string userId, string clientKey)
    {
        // Replace "your-secret-key" with a strong, securely stored secret key
        const string secretKey = "your-secret-key";

        // Validate input
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(clientKey))
        {
            return BadRequest("Missing required parameters");
        }

        try
        {
            // Generate unique key using userId and hashed secret key
            var hashedKey = HashUtil.GetSHA256Hash(secretKey + userId);
            var key = $"profile-pictures/{userId}-{hashedKey}.jpg";

            var expirationTime = DateTimeOffset.UtcNow.AddMinutes(30);

            var presignedUrl = await _imageService.GetPresignedUrlAsync("your-bucket-name", key, expirationTime);
            if (presignedUrl != null)
            {
                return Ok(presignedUrl);
            }
            else
            {
                return NotFound("Profile picture not found");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    public static class HashUtil
    {
        public static string GetSHA256Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hashedBytes = sha256.ComputeHash(bytes);
                return Convert.ToHexString(hashedBytes);
            }
        }
    } */


}
