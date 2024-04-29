namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja (ITramiteRepositorio r)
{
    public void Ejecutar(Tramite t)
    {
        r.TramiteBaja(t);
    }
}
