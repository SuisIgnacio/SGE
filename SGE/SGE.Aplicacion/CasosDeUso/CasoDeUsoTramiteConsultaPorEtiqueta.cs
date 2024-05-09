namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta (ITramiteRepositorio r)
{
    public List<Tramite> Ejecutar(EtiquetaTramite i)
    {
        return r.TramiteConsultaPorEtiqueta(i);
    }
}