using FluentValidation;
using MTechneTeste.Domain.Entities.Base;
using System.Collections.Generic;

namespace MTechneTeste.Domain.Entities
{
    public class Contato : Entity, IBaseId
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Empresa { get; set; }
        public virtual IList<EmailContato> Emails { get; set; }
        public virtual IList<TelefoneContato> Telefones { get; set; }
    }

    public class ContatoValidation : AbstractValidator<Contato>
    {
        public ContatoValidation()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            this.RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        }
    }
}
