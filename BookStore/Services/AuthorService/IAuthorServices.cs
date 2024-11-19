using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Services.AuthorService
{
    public interface IAuthorServices
    {
        Task<bool> AddAuthor(AddAuthorDTO addAuthor);
        Task<IEnumerable<AuthorWithBooksDTO>> GetAuthors();
    }
}
