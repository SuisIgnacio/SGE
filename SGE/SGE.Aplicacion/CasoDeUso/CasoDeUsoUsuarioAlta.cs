namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario user)
    {
        repo.UsuarioAlta(user);
    }
}