namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModPerm(IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario u)
    {
        repo.ModificarPermiso(u);
    }
}