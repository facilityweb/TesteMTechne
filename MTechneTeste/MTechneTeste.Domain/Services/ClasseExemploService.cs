using Stark.Domain.Services;
using .Domain.Interfaces.Repository;
using .Domain.Entities;

namespace MTechneTeste.Domain.Services
{
    public class ClasseExemploService : StarkService<ClasseExemplo>
    {
        private readonly IClasseExemploRepository classeExemploRepository;
        public ClasseExemploService(IClasseExemploRepository classeExemploRepository)
        {
            this.classeExemploRepository = classeExemploRepository;
        }
    }
}
