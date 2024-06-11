namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpediente: IExpedienteRepositorio
{
    public void BajaExpediente(int IDExpediente)
    {

    }
    public void AltaExpediente(Expediente e)
    {

    }
    public Expediente ConsultaPorID(int ID)
    {
        return null;
    }
    public List<Expediente> ConsultaPorTodos()
    {
        return null;
    }
    public void ModificarExpediente(Expediente e)
    {
        Expediente? objetivo = contexto.Expedientes.Where(E => E.Id == e.Id).SingleOrDefault();
        if (objetivo != null) objetivo = e;
        contexto.SaveChanges();
    }
}
