using FluentNHibernate.Mapping;
using MTechneTeste.Domain.Entities;

namespace MTechneTeste.Infra.Mapping
{
    public class TelefoneContatoMapping : ClassMap<TelefoneContato>
    {
        public TelefoneContatoMapping()
        {
            this.Id(x => x.Id).Column("Id");
            this.Map(x => x.Telefone).Column("Telefone");
            this.Map(x => x.ClassificacaoId).Column("ClassificacaoId");
            this.Map(x => x.ContatoId).Column("ContatoId");
            this.References(x => x.Classificacao).Column("ClassificacaoId").Not.Insert().Not.Update().Cascade.None();
            this.References(x => x.Contato).Column("ContatoId").Not.Insert().Not.Update().Cascade.None();
        }
    }
}
