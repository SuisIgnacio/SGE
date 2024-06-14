namespace SGE.Aplicacion;

public class CasoDeUsoLogIn(IUsuarioRepositorio repo)
{
    public bool Ejecutar(string correo,string contraseña)
    {
        if(correo !=null)
        {
            if(contraseña !=null)
            {
                return repo.LogIn(correo,contraseña);
            }
            else throw new MailException("Ingrese su contraseña");
        }
        else throw new MailException("Ingrese su correo");
        
    }
}