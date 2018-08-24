using System;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTechneTeste.Application.AutoMapper;
using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;

namespace MTechneTeste.Test
{
    [TestClass]
    public class ClassificacaoTest
    {
        private readonly IContainer container;
        public ClassificacaoTest()
        {
            container = ContainerConfig.Configure();
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
            var existente = container.Resolve<IClassificacaoRepository>().Find(x => x.Nome == classificacao.Nome).FirstOrDefault();
            if (existente == null)
            {
                var entidadeSalva = container.Resolve<IClassificacaoRepository>().Save(classificacao);
                Assert.AreNotEqual(0, entidadeSalva.Id);
            }
        }

        [TestMethod]
        public void GetAllClassificacoesTest()
        {
            var classificacoes = container.Resolve<IClassificacaoRepository>().GetAll();
        }
    }
}
