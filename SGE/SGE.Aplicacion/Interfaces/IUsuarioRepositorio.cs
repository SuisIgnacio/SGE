namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void UsuarioAlta(Usuario u);
    public void UsuarioBaja(int IdBorrar);
    public void UsuarioModificacion(Usuario u); // un usuario se modifica a si mismo
    public void UsuarioModificacionAdmin(Usuario u); // un usuario trata de modificar a otro
    public bool LogIn(string correo,string contraseña);
}