using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Api.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
