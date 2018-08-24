using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTechneTeste.Application.Interfaces;
using MTechneTeste.Application.ViewModels;
using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;

namespace MTechneTeste.Test
{
    [TestClass]
    public class ContatoTest
    {
        private readonly IContainer container;
        public ContatoTest()
        {
            container = ContainerConfig.Configure();
        }
        [TestMethod]
        public void SalvarContatoTest()
        {
            var classificacoes = container.Resolve<IClassificacaoRepository>().GetAll();
            var contato = new ContatoViewModel()
            {
                Nome = "Igor de Andrade Monteiro",
                Empresa = "Empresa teste",
                Endereco = "Rua teste 21, bairro teste São Paulo -SP",
                Emails = new List<EmailContatoViewModel>()
                {
                    // order by new guid para deixar embaralhado as classficacoes
                    new EmailContatoViewModel(){ ClassificacaoId = classificacoes.OrderBy(x=> new Guid()).FirstOrDefault().Id,Email = "igorandrademonteiro@gmail.com"}
                },
                Telefones = new List<TelefoneContatoViewModel>()
                {
                    new TelefoneContatoViewModel(){ClassificacaoId = classificacoes.OrderBy(x=> new Guid()).FirstOrDefault().Id, Telefone = "11 4447-5153" }
                }
            };

            ContatoViewModel contatoSalvo = container.Resolve<IContatoApplication>().Salvar(contato);

            Assert.AreNotEqual(0, contatoSalvo.Id);
            Assert.AreNotEqual(0, contatoSalvo.Telefones[0].Id);
            Assert.AreNotEqual(0, contatoSalvo.Telefones[0].ContatoId);
            Assert.AreNotEqual(0, contatoSalvo.Emails[0].Id);
            Assert.AreNotEqual(0, contatoSalvo.Emails[0].ContatoId);

        }
    }
}
