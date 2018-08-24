using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Infra.Repository.Base;
using NHibernate;

namespace MTechneTeste.Infra.Repository
{
    public class EmailContatoRepository : BaseDB<EmailContato>, IEmailContatoRepository
    {
        public EmailContatoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {

        }
    }
}


