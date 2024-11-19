
using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task AddAuthor(AddAuthorDTO addAuthor);
        Task<IEnumerable<AuthorWithBooksDTO>> GetAuthors();

    }
}
