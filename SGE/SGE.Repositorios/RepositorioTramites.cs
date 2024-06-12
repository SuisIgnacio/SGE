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
            Console.WriteLine("se elimino el tramite");
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
        if (objetivo != null) objetivo = t;
        context.SaveChanges(); 
    }
}