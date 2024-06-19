namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacionAdmin(IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario admin,Usuario usuarioMod,string contra)
    {
        if(admin.Id==1)
        {
            ValidadorUsuario Validador=new ValidadorUsuario();
            if(Validador.ValidarContraseña(contra))
            {
                repo.UsuarioModificacionAdmin(usuarioMod);
            }else throw new ValidacionException(); 
        }
        else throw new AdminException("Usted no tiene permisos para modificar otros usuarios");
    }
}