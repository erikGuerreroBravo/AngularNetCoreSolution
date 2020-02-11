using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Repositories
{
    public interface ISuplierRepository:IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPageList(int page, int rows);
    }
}
