using AutoMapper;
using MTechneTeste.Application.ViewModels;
using MTechneTeste.Domain.Entities;

namespace MTechneTeste.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ClasseExemploViewModel, ClasseExemplo>();
        }
    }
}
