public class CasoDeUsoTramiteAlta (ITramiteRepositorio inter)
{
    public void Ejecutar(Tramite tr)
    {
        inter.TramiteAlta(tr);
    }
}