namespace SGE.Repositorios;

using System.Collections;
using SGE.Aplicacion;

public class RepositorioTramiteTXT: ITramiteRepositorio
{
    readonly string _nombreArch="tramites.txt";
    readonly string _id_tramite="IDTramite.txt";
    public void TramiteBaja(int IDTramite)
    {
        string archAux="temp.txt";
        using var sr=new StreamReader(_nombreArch);
        using StreamWriter sw=File.CreateText(archAux);
        int IDactual;
        bool found=false;
        while(sr.Peek() >= 0)
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
        if(found)
        {
            Console.WriteLine("El Tramite fue eliminado correctamente");
            File.Delete(_nombreArch);
            File.Move(archAux, _nombreArch);
        }
        else
        {
            Console.WriteLine("El Tramite no se encontro");
            File.Delete(archAux);
            throw new RepositorioException();
        }
    }
    public void TramiteAlta(Tramite t)
    {
        try
        {
            var validador=new ValidadorTramites();
            validador.ValidarTramite(t);
            var validarID= new ServicioAutorizacionProvisorio();
            if(validarID.autoriza(t.IDUsuario))
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
                var repoExpedientes=new RepositorioExpedienteTXT();
                Expediente e=repoExpedientes.ConsultaPorID(t.IDExpediente);
                e.AgregarTramite(t);
            }else Console.WriteLine("El ID de usuario no es correcto");
        }catch(ValidacionException){
            Console.WriteLine("No se pudo validar el contenido");
        }
    }
    public int asignarID()
    {
        using var sr=new StreamReader(_id_tramite);
        int aux=Convert.ToInt32(sr.ReadLine());
        sr.Close();
        using var sw=new StreamWriter(_id_tramite,false);
        sw.WriteLine(aux+1);
        sw.Close();
        return aux;
    }
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite i)
    {
        List<Tramite> lista = new List<Tramite>();
        using var sr=new StreamReader(_nombreArch);
        Tramite T = new Tramite();
        while(sr.Peek() >= 0)
        {
            T.IDTramite=Convert.ToInt32(sr.ReadLine());
            T.IDExpediente=Convert.ToInt32(sr.ReadLine());
            T.Etiqueta= (EtiquetaTramite) Convert.ToInt32(sr.ReadLine());
            T.FechaCreacion=Convert.ToDateTime(sr.ReadLine());
            T.Contenido=sr.ReadLine();
            T.FechaActualizacion=Convert.ToDateTime(sr.ReadLine());
            T.IDUsuario=Convert.ToInt32(sr.ReadLine());
            if(T.Etiqueta == i)
            {
                lista.Add(T);
            }
        }
        sr.Close();
        return lista;
    }
    public void TramiteModificacion(Tramite t)
    {
        string archAux="temp.txt";
        using var sr=new StreamReader(_nombreArch);
        using StreamWriter sw=File.CreateText(archAux);
        int IDactual;
        bool found=false;
        while(sr.Peek() >= 0)
        {
            IDactual = Convert.ToInt32(sr.ReadLine());
            if (IDactual == t.IDTramite)
            {
                found = true;
                sw.WriteLine(IDactual);
                sw.WriteLine(t.IDExpediente);
                sw.WriteLine(t.Etiqueta);
                sw.WriteLine(t.FechaCreacion);
                sw.WriteLine(t.Contenido);
                sw.WriteLine(t.FechaActualizacion);
                sw.WriteLine(t.IDUsuario);
                for (int i = 0; i < 6; i++) sr.ReadLine();
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
            Console.WriteLine("El Tramite fue modificado correctamente");
            File.Delete(_nombreArch);
            File.Move(archAux, _nombreArch);
        }
    }
}