using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using CQRS_step3.Database;
using CQRS_step3.Database.Repositories;
using CQRS_step3.Domain.ProductsManagememt.Models;
using CQRS_step3.Domain.Store;
using CQRS_step3.Infrastructure;
using Dapper;
using MediatR;
using Newtonsoft.Json;

namespace CQRS_step3
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureAutofac();
        }

        private static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            // Configurations
            ConfigureMediatR(builder);
            ConfigureDapper();
            ConfigureJsonConvert();
            ConfigureDependencies(builder);
            
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void ConfigureDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<CqrsDatabase>().AsSelf().InstancePerRequest();
            builder.RegisterType<ProductReadModelRepository>().As<IProductReadModelRepository>();
        }

        private static void ConfigureJsonConvert()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new NonPublicPropertiesResolver()
            };
        }

        private static void ConfigureDapper()
        {
            SqlMapper.AddTypeHandler(typeof(Dictionary<int, object>), new JsonObjectTypeHandler());
            SqlMapper.AddTypeHandler(typeof(Category), new JsonObjectTypeHandler());
        }

        private static void ConfigureMediatR(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
             {
                typeof(IRequestHandler<,>),
                typeof(IRequestHandler<>),
                typeof(INotificationHandler<>)
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(WebApiApplication).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return c.TryResolve(t, out o) ? o : null;
                };
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            builder.RegisterGeneric(typeof(TransactionBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
        }
    }
}
