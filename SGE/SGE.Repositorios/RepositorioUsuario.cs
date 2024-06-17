using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion;

namespace SGE.Repositorios;
public class RepositorioUsuario: IUsuarioRepositorio
{
    public SGEDBContext context=new SGEDBContext();
    public void UsuarioAlta(Usuario u)
    {
        using (SHA256 mySHA256 = SHA256.Create())
        {
            if(u.Contraseña!=null)
            {
                u.Contraseña=mySHA256.ComputeHash(u.Contraseña);
            }
        }
        context.Add(u);
        context.SaveChanges();
        Usuario aux=context.Usuarios.OrderBy(u=>u.Id).Last();
        if(aux.Id==1)aux.setAdmin();
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
        Usuario? objetivo = context.Usuarios.Where(uS => uS.Id == u.Id).SingleOrDefault();
        if (objetivo != null) objetivo = u;
        context.SaveChanges();
    } 
    public void UsuarioModificacionAdmin(Usuario u)
    {
        Usuario? objetivo = context.Usuarios.Where(uS => uS.Id == u.Id).SingleOrDefault();
        if (objetivo != null) 
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                if(u.Contraseña!=null)
                {
                    u.Contraseña=mySHA256.ComputeHash(u.Contraseña);
                }
            }
            objetivo = u;
            foreach(Permiso p in u.permisos)
            {
                PermisoDb PermisoTabla= new PermisoDb(){permiso=p,IdUsuario=u.Id};
                context.Add(PermisoTabla);
            }
            context.SaveChanges();
        }
    } 
    public Usuario LogIn(string correo,string contraseña)
    {
        byte[]? Contra= Encoding.UTF8.GetBytes(contraseña);
        Usuario? u=context.Usuarios.Where(u=>u.Correo == correo).SingleOrDefault();
        if(u!=null)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                Contra=mySHA256.ComputeHash(Contra);
                for (int i = 0; i<Contra.Length;i++){
                    if (Contra[i]!= u.Contraseña[i]) return null;
                }
                return u;
            }
            
        }
        else throw new MailException("");
    }
    public List<Usuario> ConsultarPorTodos ()
    {
        List<Usuario> lista = context.Usuarios.ToList();
        List <PermisoDb> listPermisos = context.Permisos.ToList();
        foreach (Usuario u in lista)
        {
            foreach (PermisoDb unPermiso in listPermisos){
                if (unPermiso.IdUsuario == u.Id)
                {
                    u.permisos.Add(unPermiso.permiso);
                }
            }
        } 
        return lista; 
    }
    public Usuario ConsultarPorId(int Id)
    {
        Usuario? user=context.Usuarios.Where(u=>u.Id==Id).FirstOrDefault();
        if(user!=null)
        {
            var lista=context.Permisos.Where(p=>p.IdUsuario==user.Id).ToList();
            foreach(PermisoDb p in lista)
            {
                user.permisos.Add(p.permiso);
            }
            return user;
        }
        else throw new RepositorioException("El usuario no Existe");
    }
}