
using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task AddAuthor(AddAuthorDTO addAuthor);
        Task<IEnumerable<AuthorWithBooksDTO>> GetAuthors();
        Task<bool> UpdateAuthor(Guid authorId,AddAuthorDTO author);
        Task<AuthorWithBooksDTO> GetAuthorById(Guid authorId);

        Task<bool> DeleteAuthor(Guid id);

    }
}
