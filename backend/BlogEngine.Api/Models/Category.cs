using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Api.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public required ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
