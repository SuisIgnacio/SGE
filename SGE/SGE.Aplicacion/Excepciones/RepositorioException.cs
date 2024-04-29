namespace SGE.Aplicacion;

public class RepositorioException : Exception
{
    public RepositorioException() { }
    public RepositorioException(string message) : base(message) { }
    public RepositorioException(string message, System.Exception inner) : base(message, inner) { }
}
