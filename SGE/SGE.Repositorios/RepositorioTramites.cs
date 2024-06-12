namespace SGE.Repositorios;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepositorioTramites:DbContext, ITramiteRepositorio
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
    }
    public void TramiteAlta(Tramite t)
    {

    }
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i)
    {
        return null;
    }
        public void TramiteModificacion(Tramite t)
    {
        Tramite? objetivo = contexto.Tramites.Where(T => T.Id == t.Id).SingleOrDefault();
        if (objetivo != null) objetivo = t;
        contexto.SaveChanges(); 
    }
}
