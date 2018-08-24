using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Domain.Services.Base;

namespace MTechneTeste.Domain.Services
{
    public class ClassificacaoService : BaseService<Classificacao>
    {
        private readonly IClassificacaoRepository classeExemploRepository;
        public ClassificacaoService(IClassificacaoRepository classeExemploRepository)
        {
            this.classeExemploRepository = classeExemploRepository;
        }
    }
}
