using Autofac;
using MTechneTeste.Application;

namespace MTechneTeste.Agenda
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApplicationModule());
            return builder.Build();
        }
    }

}