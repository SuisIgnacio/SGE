namespace SGE.Repositorios;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepositorioTramites:DbContext, ITramiteRepositorio
{
    public void TramiteBaja(int IDTramite)
    {

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
