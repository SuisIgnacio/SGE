namespace SGE.Aplicacion ;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
    public void Ejecutar (DarDeAltaExpediente e) 
    {
        repo.AltaExpediente(e) ;
    } 
}
