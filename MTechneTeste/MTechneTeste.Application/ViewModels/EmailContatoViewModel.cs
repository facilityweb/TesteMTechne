namespace MTechneTeste.Application.ViewModels
{
    public class EmailContatoViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ClassificacaoId { get; set; }
        public int ContatoId { get; set; }
        public ClassificacaoViewModel Classificacao { get; set; }
        public ContatoViewModel Contato { get; set; }
    }
}
