namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaId(IUsuarioRepositorio repo)
{
    public Usuario Ejecutar(int Id)
    {
        try
        {
            return repo.ConsultarPorId(Id);
        }
        catch
        {
            return null;
        }
    }
}