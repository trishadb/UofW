﻿using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using UoW.Data.Infrastructure;
using UoW.Data.Infrastructure.Interfaces;
using UoW.Data.Repositories;
using UoW.Service;

namespace UoW.App_Start
{
    public class IoCConfig
    {
        /// <summary>
        /// For more info see 
        /// :http://docs.autofac.org/en/latest/integration/mvc.html
        /// </summary>
        public static void RegisterDependencies()
        {
            #region Create the builder

            var builder = new ContainerBuilder();

            #endregion

            #region Setup a common pattern

            // placed here before RegisterControllers as last one wins
            builder.RegisterAssemblyTypes(typeof(GadgetRepo).Assembly)
                .Where(t => t.Name.EndsWith("Repo"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            #endregion

            #region Register all controllers for the assembly

            // Note that ASP.NET MVC requests controllers by their concrete types, 
            // so registering them As<IController>() is incorrect. 
            // Also, if you register controllers manually and choose to specify 
            // lifetimes, you must register them as InstancePerDependency() or 
            // InstancePerHttpRequest() - ASP.NET MVC will throw an exception if 
            // you try to reuse a controller instance for multiple requests. 
            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            #endregion

            builder.RegisterApiControllers(typeof(Global).Assembly);

            #region Register modules

            builder.RegisterAssemblyModules(typeof(Global).Assembly);

            #endregion

            #region Model binder providers - excluded - not sure if need

            //builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            //builder.RegisterModelBinderProvider();

            #endregion

            #region Inject HTTP Abstractions

            /*
                         The MVC Integration includes an Autofac module that will add HTTP request 
                         lifetime scoped registrations for the HTTP abstraction classes. The 
                         following abstract classes are included: 
                        -- HttpContextBase 
                        -- HttpRequestBase 
                        -- HttpResponseBase 
                        -- HttpServerUtilityBase 
                        -- HttpSessionStateBase 
                        -- HttpApplicationStateBase 
                        -- HttpBrowserCapabilitiesBase 
                        -- HttpCachePolicyBase 
                        -- VirtualPathProvider 
            
                        To use these abstractions add the AutofacWebTypesModule to the container 
                        using the standard RegisterModule method. 
                        */
            builder.RegisterModule<AutofacWebTypesModule>();



            #endregion

            #region Others

            // OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            #endregion

            #region Set the MVC dependency resolver to use Autofac

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion
        }
    }
}