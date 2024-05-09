namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio inter)
{
    public void Ejecutar(Expediente e)
    {
        inter.ModificarExpediente(e);
    }
}