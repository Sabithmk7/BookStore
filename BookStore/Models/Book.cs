using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public Guid Bookid { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Author? Author { get; set; }
    }
}
