using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MTechneTeste.Application.Interfaces;
using MTechneTeste.Application.ViewModels;
using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;

namespace MTechneTeste.Application.AppServices
{
    public class ContatoApplication : IContatoApplication
    {
        private readonly IContatoRepository contatoRepository;
        private readonly IEmailContatoRepository emailContatoRepository;
        private readonly ITelefoneContatoRepository telefoneContatoRepository;
        public ContatoApplication(IContatoRepository contatoRepository,
            IEmailContatoRepository emailContatoRepository,
            ITelefoneContatoRepository telefoneContatoRepository)
        {
            this.contatoRepository = contatoRepository;
            this.emailContatoRepository = emailContatoRepository;
            this.telefoneContatoRepository = telefoneContatoRepository;
        }

        public IList<ContatoViewModel> GetContatos()
        {
            return Mapper.Map<IList<ContatoViewModel>>(this.contatoRepository.GetAll().OrderBy(x => x.Nome));
        }
        public ContatoViewModel Salvar(ContatoViewModel contatoViewModel)
        {
            try
            {
                var contato = Mapper.Map<Contato>(contatoViewModel);

                contatoRepository.OpenTransaction();
                // validar
                contatoRepository.SaveInTransaction(contato);
                contatoRepository.Flush();

                foreach (var email in contato.Emails)
                {
                    email.ContatoId = contato.Id;
                    // validar
                    emailContatoRepository.SaveInTransaction(email);
                    emailContatoRepository.Flush();
                }
                foreach (var telefone in contato.Telefones)
                {
                    telefone.ContatoId = contato.Id;
                    // validar
                    telefoneContatoRepository.SaveInTransaction(telefone);
                    telefoneContatoRepository.Flush();
                }
                contatoRepository.CommitTransaction();
                return Mapper.Map<ContatoViewModel>(contato);
            }
            catch (ValidationException)
            {
                contatoRepository.RoolbackTransaction();
                throw;
            }
            catch (System.Exception)
            {
                contatoRepository.RoolbackTransaction();
                throw;
            }
        }
    }
}
