using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.DTOs
{
    public class AuthorWithBooksDTO
    {
        public Guid AuthorId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<BookForAuthorDTO>? Books { get; set; } = new List<BookForAuthorDTO>();
    }
}
