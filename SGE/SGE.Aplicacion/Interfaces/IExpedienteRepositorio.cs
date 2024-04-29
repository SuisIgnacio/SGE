namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    public void BajaExpediente(Expediente e);
    public void AltaExpediente(Expediente e);
    public Expediente ConsultaPorID(int ID);
    public List<Expediente> ConsultaPorTodos();
    public void ModificarExpediente(Expediente e);
}
