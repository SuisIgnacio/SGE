namespace SGE.Aplicacion;

public class CasoDeUsoAltaUsuario (IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario user)
    {
        repo.UsuarioAlta(user);
    }
}