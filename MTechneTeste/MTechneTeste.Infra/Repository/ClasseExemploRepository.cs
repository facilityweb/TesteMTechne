using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Infra.Repository.Base;
using NHibernate;

namespace MTechneTeste.Infra.Repository
{
    public class ClasseExemploRepository : BaseDB<ClasseExemplo>, IClasseExemploRepository
    {
        public ClasseExemploRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {

        }
    }
}
