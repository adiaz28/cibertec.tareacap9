using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cibertec.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigurationInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultLifestyle = new AsyncScopedLifestyle();
            var conn = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString();
            container.Register<IUnitOfWork>(() => new NorthwindUnitOfWork(conn));

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
