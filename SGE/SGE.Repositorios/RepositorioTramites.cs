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
            context.Remove(tramiteBorrar);
            
        }
        else throw new RepositorioException("");
        context.SaveChanges();
    }
    public void TramiteAlta(Tramite t)
    {
        var e=context.Expedientes.Where(e=> e.Id == t.IDExpediente).SingleOrDefault();
        if(e != null)
        {
            context.Add(t);
            e.AgregarTramite(t);
            context.SaveChanges();
        } else throw new RepositorioException(); 
    }
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i)
    {
        List<Tramite> listaTramites = context.Tramites.Where(t => t.Etiqueta == i).ToList();
        return listaTramites ;
    }
    public void TramiteModificacion(Tramite t)
    {
        Tramite? objetivo = context.Tramites.Where(T => T.Id == t.Id).SingleOrDefault();
        if (objetivo != null) objetivo = t;
        context.SaveChanges(); 
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
