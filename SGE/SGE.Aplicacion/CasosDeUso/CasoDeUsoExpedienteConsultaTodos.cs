namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos (IExpedienteRepositorio inter)
{
    public List<Expediente> Ejecutar()
    {
        return inter.ConsultaPorTodos();
    }
}