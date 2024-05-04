namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT:ITramiteRepositorio
{
    readonly string _nombreArch="tramites.txt";
    public void TramiteBaja(Tramite t)
    {

    }
    public void TramiteAlta(Tramite t)
    {
        using var sw=new StreamWriter(_nombreArch,true);
        sw.WriteLine(t.IDTramite);
        sw.WriteLine(t.IDExpediente);
        sw.WriteLine(t.Etiqueta);
        sw.WriteLine(t.FechaCreacion);
        sw.WriteLine(t.Contenido);
        sw.WriteLine(t.FechaFinalizacion);
        sw.WriteLine(t.IDUsuario);
    }
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i)
    {

    }
    public void TramiteModificacion(Tramite t)
    {

    }
}