namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio original)
{
    public void Ejecutar (Tramite modificado)
    {
        original.TramiteModificacion(modificado);
    }
}