namespace ControleEstoque.Shared;

public class Result<T>
{
    public bool Sucesso { get; }
    public string? Mensagem { get; }
    public T? Dados { get; }

    private Result(bool sucesso, T? dados, string? mensagem)
    {
        Sucesso = sucesso;
        Dados = dados;
        Mensagem = mensagem;
    }

    public static Result<T> Ok(T dados, string? mensagem = null)
        => new(true, dados, mensagem);

    public static Result<T> Fail(string mensagem)
        => new(false, default, mensagem);
}
