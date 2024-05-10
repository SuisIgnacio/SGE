namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja (ITramiteRepositorio repo)
{
    public void Ejecutar(int idTramite)
    {
        repo.TramiteBaja(idTramite);
    }
}