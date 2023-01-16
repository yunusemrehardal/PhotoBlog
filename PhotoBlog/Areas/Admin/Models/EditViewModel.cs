using System.ComponentModel.DataAnnotations;
using PhotoBlog.Attributes;

namespace PhotoBlog.Areas.Admin.Models
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [MaxLength(140)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }

        [ValidImage(MaxFileSize = 2)]
        public IFormFile? Photo { get; set; }

        public HashSet<string>? Tags { get; set; } = new HashSet<string>();
    }
}
