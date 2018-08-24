using MTechneTeste.Domain.Entities;
using MTechneTeste.Domain.Interfaces.Repository;
using MTechneTeste.Infra.Repository.Base;
using NHibernate;

namespace MTechneTeste.Infra.Repository
{
    public class ContatoRepository : BaseDB<Contato>, IContatoRepository
    {
        public ContatoRepository() : base()
        {

        }
    }
}
