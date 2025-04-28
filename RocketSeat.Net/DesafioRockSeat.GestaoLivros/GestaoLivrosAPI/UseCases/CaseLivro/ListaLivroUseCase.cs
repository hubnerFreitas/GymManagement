using GestaoLivrosAPI.Communication;

namespace GestaoLivrosAPI.UseCases.CaseLivro
{
    public class ListaLivroUseCase
    {
        public List<ResponseListaLivroJson> Execute()
        {
            List<ResponseListaLivroJson> listaLivros = new List<ResponseListaLivroJson>();

            var livroUM = new ResponseListaLivroJson() 
            { Autor = "J.K Rolling", Quantidade = 3, Titulo = "Harry Potter e a Pedra filosofal" };

            var livroDOIS = new ResponseListaLivroJson()
            { Autor = "Tolkien", Quantidade = 3, Titulo = "Senhor dos Aneis. O retorno do Rei" };

            var livroTRES = new ResponseListaLivroJson()
            { Autor = "Suzanne Collins ", Quantidade = 3, Titulo = "Jogos Vorazes 1" };

            listaLivros.Add(livroUM);
            listaLivros.Add(livroDOIS);
            listaLivros.Add(livroTRES);
            return listaLivros;
        }
    }
}
