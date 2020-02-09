using Dapper.Contrib.Extensions;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Northwind.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected string _connectionString;

        public Repository(string connectionString)
        {
            ///mapeamos el nombre de la tabal de base ded atos
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name }"; };
            _connectionString = connectionString;
        }

        public bool Delete(T entity)
        {
            //agregamos la conexion con sql-server este metodo durara lo que invoque dentro del proceso
            using (var conection = new SqlConnection(_connectionString))
            {
                ///utilizamos dapper para eliminar la entidad a traves de la conexion de base de datos
                return conection.Delete(entity);
            }
        }

        public T GetById(int id)
        {
            //agregamos la conexion con sql-server este metodo durara lo que invoque dentro del proceso
            using (var conection = new SqlConnection(_connectionString))
            {
                ///utilizamos dapper para buscar la entidad a traves de la conexion de base de datos por el 
                ///parametro del id
                return conection.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            //agregamos la conexion con sql-server este metodo durara lo que invoque dentro del proceso
            using (var conection = new SqlConnection(_connectionString))
            {
                ///utilizamos dapper para buscar las entidades a traves de la conexion de base de datos 
                return conection.GetAll<T>();
            }
        }

        public int Insert(T entity)
        {
            //agregamos la conexion con sql-server este metodo durara lo que invoque dentro del proceso
            using (var conection = new SqlConnection(_connectionString))
            {
                ///utilizamos dapper para  insertar una entidad a traves de la conexion de base de datos 
                return (int)conection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            //agregamos la conexion con sql-server este metodo durara lo que invoque dentro del proceso
            using (var conection = new SqlConnection(_connectionString))
            {
                ///utilizamos dapper para actualizar una entidad a traves de la conexion de base de datos 
                return conection.Update<T>(entity);
            }
        }
    }
}
