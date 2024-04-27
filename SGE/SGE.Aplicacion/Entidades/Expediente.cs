namespace SGE.Aplicacion;

class Expediente
{
    public static int IDExpediente=0;
    public string? Caratula;
    public DateTime FechaInicio;
    public DateTime FechaActualizacion;
    public int IDUsuario;
    public EstadoExpediente Estado;
    public List<Tramite>? Tramites;
}
