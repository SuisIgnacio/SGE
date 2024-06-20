namespace SGE.Aplicacion;

public class ValidadorTramites
{
    public bool ValidarTramite(Tramite t)
    {
        if((t.Contenido ==null) || (t.Contenido == ""))
        {
            string mensaje="A fallado la validacion";
            return false;
            throw new ValidacionException(mensaje);
        }
        else return true;
    }
}
