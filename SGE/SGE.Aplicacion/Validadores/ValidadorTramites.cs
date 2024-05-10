namespace SGE.Aplicacion;

public class ValidadorTramites
{
    public void ValidarTramite(Tramite t)
    {
        if(t.Contenido == "")
        {
            string mensaje="A fallado la validacion";
            throw new ValidacionException(mensaje);
        }
    }
}