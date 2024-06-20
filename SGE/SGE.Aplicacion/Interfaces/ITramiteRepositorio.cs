namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    public void TramiteBaja(int IDTramite);
    public void TramiteAlta(Tramite t);
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i);
    public void TramiteModificacion(Tramite t);
    public List<Tramite> TramiteConsultaPorTodos();
    public Tramite TramiteConsultaPorID (int t) ;
}
