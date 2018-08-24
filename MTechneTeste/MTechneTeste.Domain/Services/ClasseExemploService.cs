using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Domain.Services.Base;

namespace MTechneTeste.Domain.Services
{
    public class ClasseExemploService : BaseService<ClasseExemplo>
    {
        private readonly IClasseExemploRepository classeExemploRepository;
        public ClasseExemploService(IClasseExemploRepository classeExemploRepository)
        {
            this.classeExemploRepository = classeExemploRepository;
        }
    }
}
