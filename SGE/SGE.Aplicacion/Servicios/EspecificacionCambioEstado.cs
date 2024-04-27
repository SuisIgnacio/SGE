namespace SGE.Aplicacion;

class EspecificacionCambioEstado
{
    public static void CambiarEstado(Expediente e,EstadoExpediente i )
    {
        e.Estado= i;
    }
}
