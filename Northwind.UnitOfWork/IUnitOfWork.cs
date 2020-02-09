using Northwind.Repositories;


namespace Northwind.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// repositorio para customer solo se utiliza la propiedad get
        /// </summary>
         ICustomerRepository Customer{ get;}
    }
}
