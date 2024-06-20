namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaId(IUsuarioRepositorio repo)
{
    public Usuario Ejecutar(int Id)
    {
        return repo.ConsultarPorId(Id);
    }
}
