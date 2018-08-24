using FluentNHibernate.Mapping;
using MTechneTeste.Domain.Entities;

namespace MTechneTeste.Infra.Mapping
{
    public class ContatoMapping : ClassMap<Contato>
    {
        public ContatoMapping()
        {
            this.Id(x => x.Id).Column("Id");
            this.Map(x => x.Nome).Column("Nome");
            this.Map(x => x.Endereco).Column("Endereco");
            this.Map(x => x.Empresa).Column("Empresa");
        }
    }
}
