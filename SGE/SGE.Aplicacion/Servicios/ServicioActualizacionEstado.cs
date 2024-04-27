namespace SGE.Aplicacion;

class ServicioActualizacionEstado
{
    public void ActualizacionEstado(Expediente e)
    {
        switch (e.Tramites.Last().Etiqueta.ToString())
        {
            case "Resolucion":
                e.Estado = EstadoExpediente.ConResolucion;
                break;
            case "PaseAEstudio":
                e.Estado = EstadoExpediente.ParaResolver; 
                break;
            case "PaseAlArchivo":
                e.Estado = EstadoExpediente.Finalizado;
                break;
            case "Notificacion":
                e.Estado = EstadoExpediente.EnNotificacion;
                break;
        }
    }
}
