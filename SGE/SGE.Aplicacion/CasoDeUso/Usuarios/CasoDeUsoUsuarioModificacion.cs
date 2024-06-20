namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario u,string contra)
    {
        ValidadorUsuario Validador=new ValidadorUsuario();
        if(Validador.ValidarContraseña(contra))
        {
            repo.UsuarioModificacion(u);
        }else throw new ValidacionException();
        
    }
}
