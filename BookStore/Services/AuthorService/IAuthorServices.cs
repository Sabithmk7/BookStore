using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Services.AuthorService
{
    public interface IAuthorServices
    {
        Task<bool> AddAuthor(AddAuthorDTO addAuthor);
        Task<IEnumerable<AuthorWithBooksDTO>> GetAuthors();
        Task<bool> UpdateAuthor(Guid Authorid, AddAuthorDTO author);
        Task<AuthorWithBooksDTO> GetAuthorById(Guid authorId);
        Task<bool> DeleteAuthor(Guid id);
    }
}
