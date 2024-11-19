using BookStore.Models;
using BookStore.Models.DTOs;
using Dapper;
using System.Data;

namespace BookStore.Repository.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbConnection _dbConnection;
        public AuthorRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task AddAuthor(AddAuthorDTO addAuthor)
        {
            var sql = "insertAuthor";
            await _dbConnection.ExecuteAsync(sql, addAuthor, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AuthorWithBooksDTO>> GetAuthors()
        {
            var sql = "AuthorWithBooks1";
            var authorDictionary = new Dictionary<Guid, AuthorWithBooksDTO>();

            var result = await _dbConnection.QueryAsync<AuthorWithBooksDTO, BookForAuthorDTO, AuthorWithBooksDTO>(
                sql,
                (author, book) =>
                {
                    if (!authorDictionary.TryGetValue(author.AuthorId, out var authorEntry))
                    {
                        authorEntry = author;
                        authorDictionary.Add(author.AuthorId, authorEntry);
                    }

                    if (book != null)
                    {
                        authorEntry?.Books?.Add(book);
                    }
                    return authorEntry;
                },
                splitOn: "BookId"
                );
            return authorDictionary.Values;

        }
    }
}
