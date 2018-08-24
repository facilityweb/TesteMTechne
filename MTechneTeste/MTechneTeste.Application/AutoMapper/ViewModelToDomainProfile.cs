using AutoMapper;
using .Application.ViewModels;
using .Domain.Entities;

namespace  .Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ClasseExemploViewModel, ClasseExemplo>();
        }
    }
}
