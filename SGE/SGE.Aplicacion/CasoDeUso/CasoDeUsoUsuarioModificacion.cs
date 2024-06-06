namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario u)
    {
        repo.UsuarioModificacion(u);
    }
}