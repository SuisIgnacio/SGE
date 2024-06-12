namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
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
            var tramitesBorrar=context.Tramites.Where(t=>t.IDExpediente==IDExpediente);
            foreach(Tramite t in tramitesBorrar){context.Remove(t);}
        }
        else Console.WriteLine("El expediente no existe");
        context.SaveChanges();
    }
    public void AltaExpediente(Expediente e)
    {
        context.Add(e);
        context.SaveChanges();
    }
    public Expediente ConsultaPorID(int ID)
    {
        Expediente? exp = context.Expedientes.Where(e => e.Id == ID).SingleOrDefault();
        if(exp!=null)
        {
            exp.Tramites=context.Tramites.Where(t=>t.IDExpediente==exp.Id).ToList();
            return exp;
        }
        else throw new RepositorioException();
    }
    public List<Expediente> ConsultaPorTodos()
    {
        List<Expediente> lista = context.Expedientes.ToList();
        if(lista!=null)
        {
            foreach(Expediente exp in lista)
            {
                exp.Tramites=context.Tramites.Where(t=>t.IDExpediente==exp.Id).ToList();
            }
            return lista;
        }
        else throw new RepositorioException();
    }
    public void ModificarExpediente(Expediente e)
    {
        Expediente? objetivo = context.Expedientes.Where(E => E.Id == e.Id).SingleOrDefault();
        if (objetivo != null) objetivo = e;
        context.SaveChanges();
    }
}