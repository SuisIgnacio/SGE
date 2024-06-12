namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpediente: IExpedienteRepositorio
{
    public SGEDBContext context=new SGEDBContext();
    public void BajaExpediente(int IDExpediente)
    {
        var expedienteBorrar=context.Expedientes.Where(a=>a.Id==IDExpediente).SingleOrDefault();
        if(expedienteBorrar!=null)
        {
            context.Remove(expedienteBorrar);
            Console.WriteLine("se elimino el expediente");
        }
        else Console.WriteLine("El expediente no existe");
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
