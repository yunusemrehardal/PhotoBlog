using System.ComponentModel.DataAnnotations;
using PhotoBlog.Attributes;

namespace PhotoBlog.Areas.Admin.Models
{
    public class CreateViewModel
    {

        [MaxLength(140)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }

        [ValidImage(MaxFileSize = 2)]
        public IFormFile Photo { get; set; } = null!;

        public HashSet<string>? Tags { get; set; } = new HashSet<string>();
    }
}
