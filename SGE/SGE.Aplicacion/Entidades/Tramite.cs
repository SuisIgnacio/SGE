namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; set; }
    public int IDExpediente { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string? Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public int IDUsuario { get; set; }
    public Tramite()
    {

    }
    public Tramite(int _id_tramite,int id_Expediente,EtiquetaTramite etiqueta,string? contenido,DateTime fechaCreacion,DateTime fechaActual,int idUsuario)
    {
        Id=_id_tramite;
        IDExpediente=id_Expediente;
        Etiqueta=etiqueta;
        Contenido=contenido;
        FechaCreacion=fechaCreacion;
        FechaActualizacion=fechaActual;
        IDUsuario=idUsuario;
    }
}