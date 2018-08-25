using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTechneTeste.Application.AutoMapper;
using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Domain.IOC;
using System.Linq;

namespace MTechneTeste.Test
{
    [TestClass]
    public class ClassificacaoTest
    {
        public ClassificacaoTest()
        {
            MTechneContainer.Container = ContainerConfig.Configure();
        }
        [AssemblyInitialize]
        public static void Inicializar(TestContext context)
        {
            AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void InsereNovaClassificacao()
        {
            var classificacao = new Classificacao()
            {
                Nome = "Outro"
            };
            var existente = MTechneContainer.Container.Resolve<IClassificacaoRepository>().Find(x => x.Nome == classificacao.Nome).FirstOrDefault();
            if (existente == null)
            {
                var entidadeSalva = MTechneContainer.Container.Resolve<IClassificacaoRepository>().Save(classificacao);
                Assert.AreNotEqual(0, entidadeSalva.Id);
            }
        }

        [TestMethod]
        public void GetAllClassificacoesTest()
        {
            var classificacoes = MTechneContainer.Container.Resolve<IClassificacaoRepository>().GetAll();
        }
    }
}
