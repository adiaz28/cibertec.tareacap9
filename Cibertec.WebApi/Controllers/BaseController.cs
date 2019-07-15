using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cibertec.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public readonly IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            this._unit = unit;
        }
    }
}
