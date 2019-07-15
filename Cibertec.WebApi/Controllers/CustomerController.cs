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
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
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
            return Ok(_unit.Customers.GetById(id));
        }

        [Route("")]
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _unit.Customers.Insert(customer);
            return Ok(new { id = id});
        }

        [Route("")]
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_unit.Customers.Update(customer)) return BadRequest("customer data");
            return Ok(new { status = true});
        }

        public IHttpActionResult Delete(int id)
        {
            if (id < 0) return BadRequest("Incorrect Id");
            var result = _unit.Customers.Delete(new Customer { Id = id });
            return Ok(result);
        }

        public IHttpActionResult List(int id)
        {
            if (id < 0) return BadRequest(ModelState);
            var result = _unit.Customers.Delete(new Customer { Id = id });
            return Ok(result);
        }

    }
}
