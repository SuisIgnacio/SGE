namespace SGE.Aplicacion;

public class LoggedUser
{
    public Usuario? user;
    public void loggear(Usuario u) 
    {
        user = u;
    }
}
