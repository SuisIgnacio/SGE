namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario user,string contra)
    {
        ValidadorUsuario Validador=new ValidadorUsuario();
        if(Validador.ValidarContraseña(contra))
        {
            repo.UsuarioAlta(user);
        }else throw new ValidacionException();
        
    }
}