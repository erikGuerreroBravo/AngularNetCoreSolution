using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System.Data.SqlClient;

namespace Northwind.DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository

    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User ValidateUser(string mail, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", mail);
            parameters.Add("@password", password);
            using (var conexion = new SqlConnection(_connectionString))
            {
                return conexion.QueryFirstOrDefault<User>(
                        "dbo.ValidateUser",parameters,
                        commandType:System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
