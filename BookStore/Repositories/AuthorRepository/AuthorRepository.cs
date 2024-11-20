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
        public async Task<bool> UpdateAuthor(Guid Authorid,AddAuthorDTO author)
        {
            var query= @"
            UPDATE Author
            SET FirstName = @FirstName,
                LastName = @LastName,
                BirthDate = @BirthDate
            WHERE AuthorId = @AuthorId";

            var result = await _dbConnection.ExecuteAsync(query, new
            {
                AuthorId = Authorid,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate
            });
            return result > 0;
        }

        public async Task<AuthorWithBooksDTO> GetAuthorById(Guid authorId)
        {
            var sql = "sp_authorById"; 

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
                        authorEntry.Books = authorEntry.Books ?? new List<BookForAuthorDTO>();
                        authorEntry.Books.Add(book);
                    }

                    return authorEntry;
                },
                new { AuthorId = authorId }, 
                commandType: CommandType.StoredProcedure,
                splitOn: "BookId"
            );

            return authorDictionary.Values.FirstOrDefault();
        }
        public async Task<bool> DeleteAuthor(Guid id)
        {
            var query = "DELETE FROM Author WHERE AuthorId = @AuthorId";

            var result = await _dbConnection.ExecuteAsync(query, new { AuthorId = id });

            return result > 0;
        }
    }
}
