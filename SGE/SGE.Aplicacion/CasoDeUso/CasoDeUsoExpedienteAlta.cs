namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
    public void Ejecutar (Expediente e) 
    {
        repo.AltaExpediente(e) ;
    } 
}
