namespace GestaoLivrosAPI.Communication
{
    public class RequestUpdateLivroJson
    {
        public Guid Id { get; set; }
        public RequestCreateLivroJson LivroJson { get; set; } = default!;
    }
}
