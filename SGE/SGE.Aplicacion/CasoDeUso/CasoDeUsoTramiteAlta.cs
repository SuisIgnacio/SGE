namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta (ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tr)
    {
        repo.TramiteAlta(tr);
    }
}