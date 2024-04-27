namespace SGE.Aplicacion;

class ValidadorUsuario
{
    public static void ValidarUsuario(int i)
    {
        if (i != 1)
        {
            string mensaje="A fallado la validacion";
            throw new ValidacionException(mensaje);
        }
    }
}