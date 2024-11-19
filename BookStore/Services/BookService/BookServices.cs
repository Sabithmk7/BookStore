using BookStore.Models.DTOs;
using BookStore.Repository.BookRepository;

namespace BookStore.Services.BookService
{
    public class BookServices:IBookServices
    {
        private readonly IBookRepository _bookRepository;
        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> AddBook(AddBookDTO bookDTO)
        {
            try
            {
                await _bookRepository.AddBook(bookDTO);
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ResponseBookDTO>> GetBooks()
        {
            try
            {
                var res = await _bookRepository.GetBooks();
                return res;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseBookDTO> GetBookById(Guid id)
        {
            try
            {
                var res = await _bookRepository.GetBookById(id);
                return res;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
