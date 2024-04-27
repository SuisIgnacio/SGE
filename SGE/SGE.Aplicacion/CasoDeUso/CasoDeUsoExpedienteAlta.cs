namespace SGE.Aplicacion;
public class DarDeBajaExpediente (IExpedienteRepositorio repo) 
{
    public void Ejecutar (Expediente e) 
    {
        repo.BajaExpediente (e); 
    }
} 
