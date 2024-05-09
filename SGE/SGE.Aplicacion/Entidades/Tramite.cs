namespace SGE.Aplicacion;

public class Tramite
{
    public int IDTramite;
    public int IDExpediente;
    public EtiquetaTramite Etiqueta;
    public string? Contenido;
    public DateTime FechaCreacion;
    public DateTime FechaActualizacion;
    public int IDUsuario;
    public Tramite()
    {

    }
    public Tramite(int _id_tramite,int id_Expediente,EtiquetaTramite etiqueta,string? contenido,DateTime fechaCreacion,DateTime fechaActual,int idUsuario)
    {
        IDTramite=_id_tramite;
        IDExpediente=id_Expediente;
        Etiqueta=etiqueta;
        Contenido=contenido;
        FechaCreacion=fechaCreacion;
        FechaActualizacion=fechaActual;
        IDUsuario=idUsuario;
    }
}