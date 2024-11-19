using BookStore.Models.DTOs;

namespace BookStore.Services.BookService
{
    public interface IBookServices
    {
        Task<bool> AddBook(AddBookDTO bookDTO);
        Task<IEnumerable<ResponseBookDTO>> GetBooks();
        Task<ResponseBookDTO> GetBookById(Guid id);

    }
}
