namespace SGE.Aplicacion;

public class ValidadorExpedientes
{
    public bool ValidarExpediente(Expediente e)
    {
        if((e.Caratula==null) || (e.Caratula == ""))
        {
            string mensaje="A fallado la validacion";
            return false;
            throw new ValidacionException(mensaje);
        }
        else return true;
    }
}
