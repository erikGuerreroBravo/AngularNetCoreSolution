using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Northwind.DataAccess
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// constructor de la clase  que hereda de la clase base la cadena de conexion
        /// </summary>
        /// <param name="connectionString">el nombre de la cadena de conexion</param>
        public CustomerRepository(string connectionString): base(connectionString)
        {

        }

        public IEnumerable<Customer> CustomerPageList(int page, int rows)
        {
            var paremeters = new DynamicParameters();
            paremeters.Add("@page",page);
            paremeters.Add("@rows",rows);
            
            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.Query<Customer>("dbo.CustomerPagedList", paremeters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
