using .Application.Interfaces;
using .Application.ViewModels;
using .Domain.Entities;
using .Domain.Interfaces.Services;
using Stark.Application.AppServices;

namespace .Application.AppServices
{
    public class ClasseExemploApplication : BaseApplication<ClasseExemplo, ClasseExemploViewModel>, IClasseExemploApplication
    {
        private readonly IClasseExemploService classeExemploService;
        public ClasseExemploApplication(IClasseExemploService classeExemploService)
        {
            this.classeExemploService = classeExemploService;
        }
    }
}
