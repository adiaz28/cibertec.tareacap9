using Cibertec.WebApi.App_Start;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cibertec.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            DIConfig.ConfigurationInjector(config);
            RouteConfig.Register(config);
            app.UseWebApi(config);

            
        }
    }
}
