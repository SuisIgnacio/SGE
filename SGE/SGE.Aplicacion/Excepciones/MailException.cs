namespace SGE.Aplicacion;

public class MailException : System.Exception
{
    public MailException() { }
    public MailException(string message) : base(message) { }
    public MailException(string message, System.Exception inner) : base(message, inner) { }
}