namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repo) 
{
    public void Ejecutar (int IDExpediente) 
    {
        repo.BajaExpediente(IDExpediente); 
    }
} 