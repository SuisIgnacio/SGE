using System.Text;

namespace SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set;}
    public string? Nombre { get; set;}
    public string? Apellido { get; set;}
    public string? Correo { get; set;}
    public byte[]? Contraseña { get; set;}
    public List<Permiso> permisos { get; set;}=new List<Permiso>();
    public bool Admin {get; private set;} =false;
    public Usuario(string cont)
    {
        this.Contraseña= Encoding.UTF8.GetBytes(cont);
    }
    public Usuario():this("sjndajklsnd")
    {

    }
    public void setAdmin()
    {
        Admin = true;
        permisos.Add(Permiso.ExpedienteModificacion);permisos.Add(Permiso.ExpedienteBaja);permisos.Add(Permiso.ExpedienteAlta);
        permisos.Add(Permiso.TramiteModificacion);permisos.Add(Permiso.TramiteBaja);permisos.Add(Permiso.TramiteAlta);
    }
}