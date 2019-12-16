using Autofac;
using Autofac.Integration.Mvc;
using BookStore.Core;
using BookStore.Core.Interfaces;
using BookStore.DB;
using BookStore.DB.Interfaces;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookStore.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<Store>().As<IStore>().InstancePerRequest();
            builder.RegisterType<MyDB>().As<IMyDB>().SingleInstance();
            builder.RegisterType<CatalogService>().As<ICatalogService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CommonService>().As<ICommonService>();
            builder.RegisterType<NotEnoughInventoryRule>().As<ICalculatePriceRule>();
            builder.RegisterType<SinglePriceRule>().As<ICalculatePriceRule>();
            builder.RegisterType<SeveralBooksRule>().As<ICalculatePriceRule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
