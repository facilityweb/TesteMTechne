
using System.Collections.Generic;

namespace MTechneTeste.Application.ViewModels
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Empresa { get; set; }
        public IList<EmailContatoViewModel> Emails { get; set; }
        public IList<TelefoneContatoViewModel> Telefones { get; set; }
    }
}
