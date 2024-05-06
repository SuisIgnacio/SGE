namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT:ITramiteRepositorio
{
    readonly string _nombreArch="tramites.txt";
    public void TramiteBaja(int IDTramite)
    {
        readonly string archAux="temp.txt";
        using var sr=new StreamReader(_nombreArch);
        using var sw=new StreamWriter(File.CreateText(archAux),true);
        int IDactual;
        bool found=false;
        while(!sr.EndOfStream)
        {
            IDactual= Convert.ToInt32(reader.ReadLine());;
            if(IDactual==IDTramite)
            {
                found=true;
                Console.WriteLine("El Expediente fue eliminado");
            }else{
                for(int i=0;i<6;i++)
                {
                    sw.WriteLine(sr.ReadLine());   
                }
            }
        }
        sw.Close();
        sr.Close();
        if(!found)
        {
            Console.WriteLine("El Expediente no se encontro");
            File.Delete(archAux);
        }
        else
        {
            File.Delete(_nombreArch);
            File.Move(archAux, _nombreArch);
        }
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