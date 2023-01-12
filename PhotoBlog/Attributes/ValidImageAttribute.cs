using System.ComponentModel.DataAnnotations;

// https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0
namespace PhotoBlog.Attributes
{
    public class ValidImageAttribute : ValidationAttribute
    {
        /// <summary>
        /// Maximum file size of the uploaded file in megabytes. (Default=1)
        /// </summary>
        public int MaxFileSize { get; set; } = 1;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? photo = value as IFormFile;

            if (photo == null)
                return ValidationResult.Success;

            if (!photo.ContentType.StartsWith("image/"))
            {
                return new ValidationResult("Invalid image file");
            }
            else if (photo.Length > MaxFileSize * 1024 * 1024)
            {
                return new ValidationResult($"Maximum file size: {MaxFileSize}MB");
            }

            return ValidationResult.Success;
        }
    }
}
