using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/supplier")]
    [Authorize]
    public class SupplierController:Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            //realizamos la busqueda del customer por id
            return Ok(_unitOfWork.Supplier.GetById(id));
        }
        [HttpGet]
        [Route("GetPaginatedSupplier/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page, int rows)
        {
            //realizamos la busqueda del customer por id
            return Ok(_unitOfWork.Supplier.SupplierPageList(page, rows));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
                return Ok(_unitOfWork.Supplier.Insert(supplier));
        }
        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (ModelState.IsValid && _unitOfWork.Supplier.Update(supplier))
            {
                return Ok(new { Message = "El Proveedor fue Actualizado" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_unitOfWork.Supplier.Delete(supplier));
            return BadRequest();
        }

    }
}
