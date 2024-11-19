using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.DTOs
{
    public class AddBookDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
