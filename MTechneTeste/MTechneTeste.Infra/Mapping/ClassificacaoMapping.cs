using FluentNHibernate.Mapping;
using MTechneTeste.Domain.Entities;

namespace MTechneTeste.Infra.Mapping
{
    public class ClassificacaoMapping : ClassMap<Classificacao>
    {
        public ClassificacaoMapping()
        {
            this.Table("Classificacao");
            this.Id(x => x.Id).Column("Id");
            this.Map(x => x.Nome).Column("Nome");
        }
    }
}
