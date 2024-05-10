namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{
    public void Ejecutar (Tramite modificado)
    {
        repo.TramiteModificacion(modificado);
    }
}
