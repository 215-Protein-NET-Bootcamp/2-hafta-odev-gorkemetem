using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DapperDbContext dapperDbContext;

        public AuthorRepository(DapperDbContext dapperDbContext) : base()
        {
            this.dapperDbContext = dapperDbContext;
        }

        public Task<IEnumerable<Author>> FindAsync(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> FindByNameAsync(string FirstName)
        {
            var sql = $"SELECT * FROM Author WHERE Name like @FirstName";
            using (var connection = dapperDbContext.CreateConnection())
            {
                var result = connection.QueryAsync<Author>(sql, new { FirstName });
                return result;
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var sql = "SELECT * FROM dbo.Author";
            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Author>(sql);
                return result;
            }
        }

        public async Task<Author> GetByIdAsync(int Id)
        {
            var query = "SELECT * FROM Author WHERE Id = @Id";
            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Author>(query, new { Id });
                return result;
            }
        }

        public async Task InsertAsync(Author entity)
        {
            var query = "INSERT INTO Author (FirstName, LastName, Email,Phone,CreatedBy,CreatedAt,Available ) " +
                "VALUES (@FirstName, @LastName, @Email,@Phone,@CreatedBy,@CreatedAt,@Available)";

            entity.Available = true;
            entity.CreatedAt = DateTime.UtcNow;

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", entity.FirstName, DbType.String);
            parameters.Add("LastName", entity.LastName, DbType.String);
            parameters.Add("Email", entity.Email, DbType.String);
            parameters.Add("Phone", entity.Phone, DbType.String);
            parameters.Add("CreatedBy", entity.CreatedBy, DbType.String);
            parameters.Add("CreatedAt", entity.CreatedAt, DbType.DateTime);
            parameters.Add("Available", entity.Available, DbType.Boolean);

            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void RemoveAsync(Author entity)
        {
            var query = "DELETE FROM Author WHERE Id = @Id";
            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new { entity.Id });
            }
        }

        public Task<int> TotalRecordAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
