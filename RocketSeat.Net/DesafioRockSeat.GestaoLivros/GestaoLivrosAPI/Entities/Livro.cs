namespace GestaoLivrosAPI.Entities
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Titulo{ get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; } = 0;
    }
}
