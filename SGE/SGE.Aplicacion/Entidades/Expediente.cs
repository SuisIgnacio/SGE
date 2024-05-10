namespace SGE.Aplicacion;

public class Expediente
{
    public int IDExpediente;
    public string? Caratula;
    public DateTime FechaInicio;
    public DateTime FechaActualizacion;
    public int IDUsuario;
    public EstadoExpediente Estado;
    public List<Tramite>? Tramites=new List<Tramite>();
    public Expediente()
    {
        this.Caratula = "No existo";
    }
    public Expediente (int _id_expediente,string? caratula,DateTime fechaInicio,DateTime fechaAct,int idUsuario,EstadoExpediente estado)
    {
        IDExpediente=_id_expediente;
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