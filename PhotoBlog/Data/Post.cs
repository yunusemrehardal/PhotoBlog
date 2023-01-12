using System.ComponentModel.DataAnnotations;

namespace PhotoBlog.Data
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(140)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }

        [MaxLength(255)]
        public string Photo { get; set; } = null!;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

    }
}
