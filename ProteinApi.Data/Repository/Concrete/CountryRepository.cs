using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperDbContext _dbContext;

        public CountryRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var sql = "SELECT * FROM dbo.country";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Country>(sql);
                return result;
            }
        }

        public async Task<Country> GetByIdAsync(int entityId)
        {
            var query = "SELECT * FROM dbo.country WHERE Id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Country>(query, new { Id });
                return result;
            }
        }

        public async Task InsertAsync(Country entity)
        {
            var query = "INSERT INTO dbo.country (CountryId, CountryName, Continent, Currency) " +
                "VALUES (@CountryId, @CountryName, @Continent, @Currency)";

            entity.CreatedAt = DateTime.UtcNow;

            var parameters = new DynamicParameters();
            parameters.Add("CountryId", entity.CountryId, DbType.String);
            parameters.Add("CountryName", entity.CountryName, DbType.String);
            parameters.Add("Continent", entity.Continent, DbType.String);
            parameters.Add("Currency", entity.Currency, DbType.String);

            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void RemoveAsync(Country entity)
        {
            var query = "DELETE FROM dbo.country WHERE Id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new { entity.Id });
            }
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
