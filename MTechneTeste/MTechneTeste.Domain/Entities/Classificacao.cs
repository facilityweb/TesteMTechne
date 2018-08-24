using FluentValidation;
using MTechneTeste.Domain.Entities.Base;

namespace MTechneTeste.Domain.Entities
{
    public class Classificacao : Entity, IBaseId
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
    }

    public class ClassificacaoValidation : AbstractValidator<Classificacao>
    {
        public ClassificacaoValidation()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            this.RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        }
    }
}
