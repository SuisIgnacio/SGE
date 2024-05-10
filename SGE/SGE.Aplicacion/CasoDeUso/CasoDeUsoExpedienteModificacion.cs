namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente e)
    {
        repo.ModificarExpediente(e);
    }
}