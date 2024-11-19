using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Repository.BookRepository
{
    public interface IBookRepository
    {
        Task AddBook(AddBookDTO bookDTO);
        Task<IEnumerable<ResponseBookDTO>> GetBooks();
        Task<ResponseBookDTO> GetBookById(Guid id);
    }
}
