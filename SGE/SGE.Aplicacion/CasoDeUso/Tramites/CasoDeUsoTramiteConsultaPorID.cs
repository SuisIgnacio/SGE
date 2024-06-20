namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorID (ITramiteRepositorio repo)
{
    public Tramite Ejecutar(int t)
    {
        return repo.TramiteConsultaPorID(t);
    }
}