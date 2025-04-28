using GestaoLivrosAPI.Communication;
using GestaoLivrosAPI.Entities;

namespace GestaoLivrosAPI.UseCases.CaseLivro
{
    public class CreateLivroUseCase
    {
        public ResponseCreteLivroJson Execute(RequestCreateLivroJson request)
        {
            /* Por hora não implementei nenhuma validação do request.*/
            var livro = new Livro()
            {
                Id = Guid.NewGuid(),
                Titulo = request.Titulo,
                Autor = request.Autor,
                Genero = request.Genero,
                Preco = request.Preco,
                Quantidade = request.Quantidade
            };

            var response = new ResponseCreteLivroJson() { Titulo = livro.Titulo, Id = livro.Id };

            return response;
        }
    }
}
