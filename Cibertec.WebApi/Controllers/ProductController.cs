using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Cibertec.Models;
using Cibertec.UnitOfWork;

namespace Cibertec.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id < 0) return BadRequest("Incorrect Id");
            return Ok(_unit.Products.GetById(id));
        }

        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _unit.Products.Insert(product);
            return Ok(new { id = id });
        }

        [Route("")]
        public IHttpActionResult Put(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_unit.Products.Update(product)) return BadRequest("product data");
            return Ok(new { status = true });
        }

        public IHttpActionResult Delete(int id)
        {
            if (id < 0) return BadRequest("Incorrect Id");
            var result = _unit.Products.Delete(new Product { Id = id });
            return Ok(result);
        }

        public IHttpActionResult List(int id)
        {
            if (id < 0) return BadRequest(ModelState);
            var result = _unit.Products.Delete(new Product { Id = id });
            return Ok(result);
        }
    }
}