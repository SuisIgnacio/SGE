namespace SGE.Aplicacion;

public class ValidadorExpedientes
{
    public void ValidarExpediente(Expediente e)
    {
        if(e.Caratula == "")
        {
            string mensaje="A fallado la validacion";
            throw new ValidacionException(mensaje);
        }
    }
}