using AutoMapper;
using .Application.ViewModels;
using .Domain.Entities;

namespace .Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<ClasseExemplo, ClasseExemploViewModel>();
        }
    }
}
