using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion;

namespace SGE.Repositorios;
public class RepositorioUsuario: IUsuarioRepositorio
{
    public SGEDBContext context=new SGEDBContext();
    public void UsuarioAlta(Usuario u)
    {
        Usuario? usuarioAuxiliar=context.Usuarios.Where(a=>a.Correo==u.Correo).SingleOrDefault();
        if(usuarioAuxiliar==null)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                u.Contraseña=mySHA256.ComputeHash(u.Contraseña);
            }
            context.Add(u);
            context.SaveChanges();
            Usuario aux=context.Usuarios.OrderBy(u=>u.Id).Last();
            if(aux.Id==1)aux.setAdmin();
            context.SaveChanges();
        }
        else throw new MailException();
    }
    public void UsuarioBaja(int IdBorrar)
    {
        var userBorrar=context.Usuarios.Where(a=>a.Id == IdBorrar).SingleOrDefault();
        if(userBorrar != null)
        {
            context.Remove(userBorrar);
        }
        else throw new RepositorioException();
        context.SaveChanges();
    }
    public void UsuarioModificacion(Usuario u)
    {
        Usuario? objetivo = context.Usuarios.Where(uS => uS.Id == u.Id).SingleOrDefault();
        if (objetivo != null)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                u.Contraseña=mySHA256.ComputeHash(u.Contraseña);
            }
            objetivo = u;
            context.SaveChanges();
        }
    } 
    public void UsuarioModificacionAdmin(Usuario u)
    {
        Usuario? objetivo = context.Usuarios.Where(uS => uS.Id == u.Id).SingleOrDefault();
        if (objetivo != null) 
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                u.Contraseña=mySHA256.ComputeHash(u.Contraseña);
            }
            objetivo = u;
            context.SaveChanges();
        }
    }
    public void ModificarPermiso(Usuario u)
    {
        Usuario? objetivo = context.Usuarios.Where(uS => uS.Id == u.Id).SingleOrDefault();
        objetivo.permisos=u.permisos;
        context.SaveChanges();
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
                    if (Contra[i]!= u.Contraseña[i]) throw new RepositorioException("");
                }
                return u;
            }
        }
        else throw new MailException("");
    }
    public List<Usuario> ConsultarPorTodos ()
    {
        return context.Usuarios.ToList(); 
    }
    public Usuario ConsultarPorId(int Id)
    {
        Usuario? user=context.Usuarios.Where(u=>u.Id==Id).FirstOrDefault();
        if(user!=null)
        {
            return user;
        }
        else throw new RepositorioException("El usuario no Existe");
    }
}