namespace SGE.Aplicacion;

public class CasoDeUsoLogIn(IUsuarioRepositorio repo)
{
    public bool Ejecutar(string correo,string contraseña)
    {
        return repo.LogIn(correo,contraseña);
    }
}