namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorID (IExpedienteRepositorio repo) 
{
    public Expediente Ejecutar (in id) 
    {
        repo.ConsultarPorID(id) ;
    }
}
