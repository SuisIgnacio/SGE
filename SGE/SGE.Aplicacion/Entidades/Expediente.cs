namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; }
    public string? Caratula { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public int IDUsuario { get; set; }
    public EstadoExpediente Estado { get; set; }
    public List<Tramite> Tramites {get;set;} =new List<Tramite>();
    public Expediente()
    {
        this.Caratula = "No existo";
    }
    public Expediente (int _id_expediente,string? caratula,DateTime fechaInicio,DateTime fechaAct,int idUsuario,EstadoExpediente estado)
    {
        Id=_id_expediente;
        Caratula = caratula;
        FechaInicio = fechaInicio;
        FechaActualizacion = fechaAct;
        IDUsuario = idUsuario;
        Estado=estado;
        Tramites=new List<Tramite>();
    }
    public void AgregarTramite(Tramite t)
    {
        Tramites.Add(t);
        var actualizacion=new ServicioActualizacionEstado();
        actualizacion.ActualizacionEstado(this);
    }
}