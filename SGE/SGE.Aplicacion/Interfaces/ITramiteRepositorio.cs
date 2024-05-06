namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteBaja(int IDTramite);
    void TramiteAlta(Tramite t);
    List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i);
    void TramiteModificacion(Tramite t);
}
