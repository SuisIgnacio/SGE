namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void UsuarioAlta(Usuario u);
    public void UsuarioBaja(int IdBorrar);
    public void UsuarioModificacion(Usuario u); // un usuario se modifica a si mismo
    public void UsuarioModificacionAdmin(Usuario u); // un usuario trata de modificar a otro
    public void ModificarPermiso(Usuario u);
    public Usuario LogIn(string correo,string contraseña);
    public List<Usuario> ConsultarPorTodos();
    Usuario ConsultarPorId(int id);
}