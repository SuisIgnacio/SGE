namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta (ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(EtiquetaTramite i)
    {
        return repo.TramiteConsultaPorEtiqueta(i);
    }
}
