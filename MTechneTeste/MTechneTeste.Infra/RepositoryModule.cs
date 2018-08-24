using Autofac;
using NHibernate;
using MTechneTeste.Infra.Mapping;
using System;
using System.Configuration;
using MTechneTeste.Infra.Repository.Base;
using MTechneTeste.Infra.Repository;
using MTechneTeste.Domain.Interfaces.Repository;

namespace MTechneTeste.Infra
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (ConfigurationManager.AppSettings["StarkDb"] == null) throw new ApplicationException("Tipo do Banco não informado.");
            if (ConfigurationManager.ConnectionStrings["StarkDb"] == null) throw new ApplicationException("ConnectionString StarkDB não informads.");

            builder.Register(x => NHibernateSessionHelper.GetFactory(typeof(ClassificacaoMapping), ConfigurationManager.AppSettings["StarkDb"], ConfigurationManager.ConnectionStrings["StarkDb"].ConnectionString)).As<ISessionFactory>().SingleInstance();
            builder.RegisterType<ContatoRepository>().As<IContatoRepository>();
            builder.RegisterType<ClassificacaoRepository>().As<IClassificacaoRepository>();
            builder.RegisterType<EmailContatoRepository>().As<IEmailContatoRepository>();
            builder.RegisterType<TelefoneContatoRepository>().As<ITelefoneContatoRepository>();
            base.Load(builder);
        }
    }
}
