using AutoMapper;
using MTechneTeste.Application.ViewModels;
using MTechneTeste.Domain.Entities;

namespace MTechneTeste.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Classificacao, ClassificacaoViewModel>();
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<TelefoneContato, TelefoneContatoViewModel>();
            CreateMap<EmailContato, EmailContatoViewModel>();
        }
    }
}
