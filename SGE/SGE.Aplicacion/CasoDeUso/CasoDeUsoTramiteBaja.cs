namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja (ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite t)
    {
        repo.TramiteBaja(t);
    }
}
