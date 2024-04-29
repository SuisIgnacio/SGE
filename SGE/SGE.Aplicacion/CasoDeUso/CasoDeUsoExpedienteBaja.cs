namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repo) 
{
    public void Ejecutar (Expediente e) 
    {
        repo.BajaExpediente(e); 
    }
} 
