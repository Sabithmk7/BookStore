using BookStore.Models;
using BookStore.Models.DTOs;
using Dapper;
using System.Data;

namespace BookStore.Repository.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _dbConnection;
        public BookRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddBook(AddBookDTO bookDTO)
        {
            var sql = "insertBook";
            await _dbConnection.ExecuteAsync(sql, bookDTO, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ResponseBookDTO>> GetBooks()
        {
            var query = "BooksWithAuthor";
            var result = await _dbConnection.QueryAsync<ResponseBookDTO>(
            query,
            commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<ResponseBookDTO> GetBookById(Guid id)
        {
            var query = "GetBookById";
            var result = await _dbConnection.QueryFirstOrDefaultAsync<ResponseBookDTO>(query, new { BookId = id }, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
