using System.Net.NetworkInformation;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MediatR;

namespace CQRS_1step
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
            ConfigureMediatR(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void ConfigureMediatR(ContainerBuilder builder)
        {
            var mediatrOpenTypes = new[]
             {
                typeof(IRequestHandler<,>),
                typeof(IAsyncRequestHandler<,>),
                typeof(ICancellableAsyncRequestHandler<,>),
                typeof(INotificationHandler<>),
                typeof(IAsyncNotificationHandler<>),
                typeof(ICancellableAsyncNotificationHandler<>)
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(WebApiApplication).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

        }
    }
}
