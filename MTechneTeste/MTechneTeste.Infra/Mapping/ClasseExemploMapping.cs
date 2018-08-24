using FluentNHibernate.Mapping;
using MTechneTeste.Domain.Entities;

namespace MTechneTeste.Infra.Mapping
{
    public class ClasseExemploMapping : ClassMap<ClasseExemplo>
    {
        public ClasseExemploMapping()
        {
            this.Table("Tabela");
            this.Id(x => x.Id).Column("Id");
            this.Map(x => x.Nome).Column("Nome");
        }
    }
}
