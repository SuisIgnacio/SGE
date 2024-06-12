namespace SGE.Repositorios;
using SGE.Aplicacion;

public class PermisoDb
{
    public int Id { get; set; }
    public Permiso permiso{ get; set; }
    public int IdUsuario { get; set; }
}