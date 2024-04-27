namespace SGE.Aplicacion;

interface ITramiteRepositorio
{
    void TramiteBaja(Tramite t);
    void TramiteAlta(Tramite t);
    Tramite TramiteConsultaPorEtiqueta(EtiquetaTramite i);
    void TramiteModificacion(Tramite t);
}
