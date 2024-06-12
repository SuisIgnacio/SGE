namespace SGE.Repositorios;
using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion;

public class RepositorioUsuario: IUsuarioRepositorio
{
    public SGEDBContext context=new SGEDBContext();
    public void UsuarioAlta(Usuario u)
    {
        using (SHA256 mySHA256 = SHA256.Create())
        {
            u.Contraseña=mySHA256.ComputeHash(u.Contraseña);
        }
        context.Add(u);
        context.SaveChanges();
        u=context.Usuarios.OrderBy(u=>u.Id).Last();
        foreach(Permiso p in u.permisos)
        {
            PermisoDb peron= new PermisoDb(){permiso=p,IdUsuario=u.Id};
            context.Add(peron);
        }
        context.SaveChanges();
    }
    public void UsuarioBaja(int IdBorrar)
    {
        var userBorrar=context.Usuarios.Where(a=>a.Id == IdBorrar).SingleOrDefault();
        if(userBorrar != null){context.Remove(userBorrar);}
        else Console.WriteLine("El usuario no existe");
        context.SaveChanges();
    }
    public void UsuarioModificacion(Usuario u)
    {

    } // un usuario se modifica a si mismo
    public void UsuarioModificacionAdmin(Usuario u)
    {

    } // un usuario trata de modificar a otro
}