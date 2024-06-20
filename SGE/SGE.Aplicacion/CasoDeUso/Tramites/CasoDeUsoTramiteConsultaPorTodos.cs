namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorTodos (ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar()
    {
        return repo.TramiteConsultaPorTodos() ;
    }
}