using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Infra.Repository.Base;
using NHibernate;

namespace MTechneTeste.Infra.Repository
{
    public class ClassificacaoRepository : BaseDB<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {

        }
    }
}
