
using MTechneTeste.Application.ViewModels;
using System.Collections.Generic;

namespace MTechneTeste.Application.Interfaces
{
    public interface IContatoApplication
    {
        ContatoViewModel Salvar(ContatoViewModel contato);
        IList<ContatoViewModel> GetContatos();
    }
}
