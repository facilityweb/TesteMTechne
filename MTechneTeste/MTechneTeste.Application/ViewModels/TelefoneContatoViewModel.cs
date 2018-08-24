namespace MTechneTeste.Application.ViewModels
{
    public class TelefoneContatoViewModel
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public int ClassificacaoId { get; set; }
        public int ContatoId { get; set; }
        public ClassificacaoViewModel Classificacao { get; set; }
        public ContatoViewModel Contato { get; set; }
    }
}
