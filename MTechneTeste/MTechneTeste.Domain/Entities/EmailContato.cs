using FluentValidation;
using MTechneTeste.Domain.Entities.Base;

namespace MTechneTeste.Domain.Entities
{
    public class EmailContato : Entity, IBaseId
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual int ClassificacaoId { get; set; }
        public virtual int ContatoId { get; set; }
        public virtual Classificacao Classificacao { get; set; }
        public virtual Contato Contato { get; set; }
    }

    public class EmailContatoValidation : AbstractValidator<EmailContato>
    {
        public EmailContatoValidation()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            this.RuleFor(x => x.Email).NotEmpty().WithMessage("Nome é obrigatório");
            this.RuleFor(x => x.ContatoId).NotEmpty().WithMessage("Contato é obrigatório");
            this.RuleFor(x => x.ClassificacaoId).NotEmpty().WithMessage("Classificacao é obrigatório");
        }
    }
}

