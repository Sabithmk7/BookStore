using BookStore.Models;
using BookStore.Models.DTOs;
using BookStore.Repository.AuthorRepository;

namespace BookStore.Services.AuthorService
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorRepository _repository;
        public AuthorServices(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAuthor(AddAuthorDTO addAuthor)
        {
            try
            {
                await _repository.AddAuthor(addAuthor);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AuthorWithBooksDTO>> GetAuthors()
        {
            try
            {
                var res = await _repository.GetAuthors();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateAuthor(Guid Authorid, AddAuthorDTO author)
        {
            try
            {
                var res = await _repository.UpdateAuthor(Authorid, author);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AuthorWithBooksDTO> GetAuthorById(Guid authorId)
        {
            try
            {
                var res = await _repository.GetAuthorById(authorId);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAuthor(Guid id)
        {
            try
            {
                var res = await _repository.DeleteAuthor(id);
                return res;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
