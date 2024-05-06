namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT
{
    readonly string _nombreArch="tramites.txt";
    public void TramiteBaja(int IDTramite)
    {
        string archAux="temp.txt";
        File.CreateText(archAux);
        using var sr=new StreamReader(_nombreArch);
        using var sw=new StreamWriter(archAux,false);
        int IDactual;
        bool found=false;
        while(!sr.EndOfStream)
        {
            IDactual = Convert.ToInt32(sr.ReadLine()); ;
            if (IDactual == IDTramite)
            {
                found = true;
                for (int i = 0;i<6;i++) sr.ReadLine();
            }
            else
            {
                sw.WriteLine(IDactual);
                for (int i = 0; i<6; i++) sw.WriteLine(sr.ReadLine());
            }
        }
        sw.Close();
        sr.Close();
        if(!found)
        {
            Console.WriteLine("El Tramite no se encontro");
            File.Delete(archAux);
        }
        else
        {
            Console.WriteLine("El Tramite fue eliminado correctamente");
            File.Delete(_nombreArch);
            File.Move(archAux, _nombreArch);
        }
    }
    public void TramiteAlta(Tramite t)
    {
        using var sw=new StreamWriter(_nombreArch,true);
        sw.WriteLine(t.IDTramite);
        sw.WriteLine(t.IDExpediente);
        sw.WriteLine(Convert.ToInt32(t.Etiqueta));
        sw.WriteLine(t.FechaCreacion);
        sw.WriteLine(t.Contenido);
        sw.WriteLine(t.FechaActualizacion);
        sw.WriteLine(t.IDUsuario);
        sw.Close();
    }
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i)
    {
        List<Tramite> lista = new List<Tramite>();
        return lista;
    }
    public void TramiteModificacion(Tramite t)
    {
        string archAux="temp.txt";
        File.CreateText(archAux);
        using var sr=new StreamReader(_nombreArch);
        using var sw=new StreamWriter(archAux,false);
        int IDactual;
        bool found=false;
        while(!sr.EndOfStream)
        {
            IDactual = Convert.ToInt32(sr.ReadLine());
            sw.WriteLine(IDactual);
            if (IDactual == t.IDTramite)
            {
                found = true;
                sw.WriteLine(t.IDExpediente);
                sw.WriteLine(t.Etiqueta);
                sw.WriteLine(t.FechaCreacion);
                sw.WriteLine(t.Contenido);
                sw.WriteLine(t.FechaActualizacion);
                sw.WriteLine(t.IDUsuario);
            }
            else
            {
                for (int i = 0; i<6; i++) sw.WriteLine(sr.ReadLine());
            }
        }
        sw.Close();
        sr.Close();
        if(!found)
        {
            Console.WriteLine("El Tramite no se encontro");
            File.Delete(archAux);
        }
        else
        {
            Console.WriteLine("El Tramite fue modificado correctamente");
            File.Delete(_nombreArch);
            File.Move(archAux, _nombreArch);
        }
    }
}
