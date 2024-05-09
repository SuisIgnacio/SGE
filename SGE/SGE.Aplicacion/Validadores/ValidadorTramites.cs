namespace SGE.Aplicacion;

class ValidadorTramites
{
    public static void ValidarTramite(Tramite t)
    {
        if(t.Contenido == null)
        {
            string mensaje="A fallado la validacion";
            throw new ValidacionException(mensaje);
        }
    }
}