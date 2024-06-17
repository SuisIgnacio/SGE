namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacionAdmin(IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario admin,Usuario usuarioMod)
    {
        if(admin.Id==1){repo.UsuarioModificacionAdmin(usuarioMod);}
        else throw new ValidacionException("Usted no tiene permisos para modificar otros usuarios");
    }
}