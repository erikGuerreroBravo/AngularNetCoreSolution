using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Northwind.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISuplierRepository
    {
        public SupplierRepository(string connectionString):base(connectionString)
        {
                
        }
        public IEnumerable<Supplier> SupplierPageList(int page, int rows)
        {
            var paremeters = new DynamicParameters();
            paremeters.Add("@page", page);
            paremeters.Add("@rows", rows);

            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.Query<Supplier>("dbo.SupplierPagedList", paremeters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
