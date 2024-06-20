namespace SGE.Repositorios;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepositorioTramite:DbContext, ITramiteRepositorio 
{
    public SGEDBContext context=new SGEDBContext();
    public void TramiteBaja(int IDTramite)
    {
        var tramiteBorrar=context.Tramites.Where(a=>a.Id == IDTramite).SingleOrDefault();
        if(tramiteBorrar!=null)
        {
            Expediente? expObj = context.Expedientes.Where(e => e.Id == tramiteBorrar.IDExpediente).FirstOrDefault();
            context.Remove(tramiteBorrar);
            Console.WriteLine("se elimino el tramite");
            if (expObj != null && expObj.Tramites.Last()== tramiteBorrar) new ServicioActualizacionEstado().ActualizacionEstado(expObj); 
        }
        else Console.WriteLine("El tramite no existe");
        context.SaveChanges();
    }
    public void TramiteAlta(Tramite t)
    {
        var e=context.Expedientes.Where(e=> e.Id == t.IDExpediente).SingleOrDefault();
        if(e != null)
        {
            context.Add(t);
            e.AgregarTramite(t);
            new ServicioActualizacionEstado().ActualizacionEstado(e);
            context.SaveChanges();
        }
    }
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i)
    {
        List<Tramite> listaTramites = context.Tramites.Where(t => t.Etiqueta == i).ToList();
        return listaTramites ;
    }
    public void TramiteModificacion(Tramite t)
    {
        Tramite? objetivo = context.Tramites.Where(T => T.Id == t.Id).SingleOrDefault();
        if (objetivo != null) 
        {
            objetivo = t;
            Expediente? objetivoE = context.Expedientes.Where(T => T.Id == t.IDExpediente && t.Id ==objetivo.Id).FirstOrDefault();
            if (objetivoE != null && objetivoE.Tramites.Last()==objetivo) new ServicioActualizacionEstado().ActualizacionEstado(objetivoE);
            context.SaveChanges();
        }
    }
    public List<Tramite> TramiteConsultaPorTodos ()
    {
        List<Tramite> listaTram = context.Tramites.ToList() ;
        return listaTram ;
    }
     public Tramite TramiteConsultaPorID (int id) 
    {
        Tramite? tram = context.Tramites.Where(tr => tr.Id == id).SingleOrDefault();
        if (tram!= null) { return tram ;}
        else throw new RepositorioException();
    }
}
