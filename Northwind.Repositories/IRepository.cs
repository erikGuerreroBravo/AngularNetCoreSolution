using System.Collections.Generic;

namespace Northwind.Repositories
{
    public interface IRepository<T> where T:class
    {
        /// <summary>
        /// Firma del metodo generico para eliminar
        /// </summary>
        /// <param name="entity">una entidad generica</param>
        /// <returns>un valor true/false</returns>
        bool Delete(T entity);
        /// <summary>
        /// Firma del metodo generico actualizar
        /// </summary>
        /// <param name="entity">una entidad generica</param>
        /// <returns>una respuesta booleana true/false</returns>
        bool Update(T entity);
        /// <summary>
        /// Firma del metodo generico para insertar
        /// </summary>
        /// <param name="entity">una entidad generica</param>
        /// <returns>un valor del tipo entero</returns>
        int Insert(T entity);
        /// <summary>
        /// Firma del metodo generico para obtener una lista de elementos
        /// </summary>
        /// <returns>regresa una lista del tipo ienumerable generica</returns>
        IEnumerable<T> GetList();
        /// <summary>
        /// Firma del metodo que se encarga de buscar una entidad por id
        /// </summary>
        /// <param name="id">el identificador a buscar</param>
        /// <returns>regresa una entidad generica</returns>
        T GetById(int id);

    }
}
