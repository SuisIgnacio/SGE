namespace SGE.Aplicacion;

public class ValidadorExpedientes
{
    public static void ValidarExpediente(Expediente e)
    {
        if(e.Caratula == null)
        {
            string mensaje="A fallado la validacion";
            throw new ValidacionException(mensaje);
        }
    }
}
