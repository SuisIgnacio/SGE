namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorID (IExpedienteRepositorio repo) 
{
    public Expediente Ejecutar (int id) 
    {
        return repo.ConsultaPorID(id);
    }
}