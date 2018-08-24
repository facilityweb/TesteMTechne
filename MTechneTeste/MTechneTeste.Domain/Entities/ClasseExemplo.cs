using FluentValidation;
using Stark.Domain;
using Stark.Domain.Entities.Base;

namespace .Domain.Entities
{
    public class ClasseExemplo : Entity, IBaseId
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
    }

    public class ClasseExemploValidation : AbstractValidator<ClasseExemplo>
    {
        public ClasseExemploValidation()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            this.RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        }
    }
}
