using Autofac;
using MTechneTeste.Application.AppServices;
using MTechneTeste.Application.Interfaces;
using MTechneTeste.Infra;

namespace MTechneTeste.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterType<ContatoApplication>().As<IContatoApplication>();
        }
    }
}
