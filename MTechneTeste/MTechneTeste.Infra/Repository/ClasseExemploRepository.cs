using NHibernate;
using Stark.Infra.Repository;
using .Domain.Entities;
using .Domain.Interfaces.Repository;

namespace MTechneTeste.Infra.Repository
{
    public class ClasseExemploRepository : StarkDB<ClasseExemplo>, IClasseExemploRepository
    {
        public ClasseExemploRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {

        }
    }
}
