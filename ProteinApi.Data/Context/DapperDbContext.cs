using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly string databaseType;
        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            databaseType = "SQL";
            connectionString = GetConnectionString();
        }
        private string GetConnectionString()
        {
            switch (databaseType)
            {
                case "SQL":
                    return this.configuration.GetConnectionString("DefaultConnection");
                case "Postgre":
                    return this.configuration.GetConnectionString("PosgreSqlConnection");
                default:
                    return this.configuration.GetConnectionString("DefaultConnection");
            }
        }
        public IDbConnection CreateConnection()
        {
            switch (databaseType)
            {
                case "SQL":
                    return new SqlConnection(connectionString);
                case "Postgre":
                    return new NpgsqlConnection(connectionString);
                default:
                    return new SqlConnection(connectionString);
            }
        }
    }
}
