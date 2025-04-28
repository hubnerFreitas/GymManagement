using GestaoLivrosAPI.Communication;

namespace GestaoLivrosAPI.UseCases.CaseLivro
{
    public class UpdateLivroUseCase
    {
        public ResponseCreteLivroJson Execute(Guid id, RequestUpdateLivroJson request)
        {
            /*
             * Valida para ver se o livro existe, se sim atualiza
             */

            // var livro = BuscaLivr(id);

            var livro = new ResponseCreteLivroJson()
            {
                Id = id,
                Titulo = request.LivroJson.Titulo,
            };

            return livro;
        }
    }
}
