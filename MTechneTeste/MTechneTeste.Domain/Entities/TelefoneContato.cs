using FluentValidation;
using MTechneTeste.Domain.Entities.Base;

namespace MTechneTeste.Domain.Entities
{
    public class TelefoneContato : Entity, IBaseId
    {
        public virtual int Id { get; set; }
        public virtual string Telefone { get; set; }
        public virtual int ClassificacaoId { get; set; }
        public virtual int ContatoId { get; set; }
        public virtual Classificacao Classificacao { get; set; }
        public virtual Contato Contato { get; set; }
    }

    public class TelefoneContatoValidation : AbstractValidator<TelefoneContato>
    {
        public TelefoneContatoValidation()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            this.RuleFor(x => x.Telefone).NotEmpty().WithMessage("Nome é obrigatório");
            this.RuleFor(x => x.ContatoId).NotEmpty().WithMessage("Contato é obrigatório");
            this.RuleFor(x => x.ClassificacaoId).NotEmpty().WithMessage("Classificacao é obrigatório");
        }
    }
}


