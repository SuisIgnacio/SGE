namespace SGE.Aplicacion;

public class Usuario
{
    public string? Nombre { get; set;}
    public string? Apellido { get; set;}
    public string? Correo { get; set;}
    public string? Contraseña { get; set;}
    public List<Permiso> permisos { get;private set;}=new List<Permiso>();
    public bool Admin {get; private set;} =false;
    public void setAdmin()
    {
        Admin = true;
    }
}