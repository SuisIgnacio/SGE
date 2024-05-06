namespace SGE.Repositorios;
using SGE.Aplicacion;
using System.Reflection.PortableExecutable;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    private string path = "expediente.txt";
    public void BajaExpediente(int IDExpediente)
    {
        string archAux="temp.txt";
        File.CreateText(archAux);
        using var sr=new StreamReader(_nombreArch);
        using var sw=new StreamWriter(archAux,false);
        int IDactual;
        bool found = false;
        while (!sr.EndOfStream && !found)
        {
            IDactual = Convert.ToInt32(sr.ReadLine()); ;
            if (IDactual == IDExpediente)
            {
                found = true;
                for (int i = 0; i < 5; i++) sr.ReadLine();
            }
            else
            {
                sw.WriteLine(IDactual);
                for (int i = 0; i < 5; i++) sw.WriteLine(sr.ReadLine());
            }
        }
        sr.Close();
        sw.Close();
        File.Delete(path);
        File.Move(pathaux, path);
    }
    public void AltaExpediente(Expediente e)
    {
        using var sw = new StreamWriter(path, true);
        sw.WriteLine(e.IDExpediente);
        sw.WriteLine(e.FechaInicio);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaActualizacion);
        sw.WriteLine(e.IDUsuario);
        sw.WriteLine(Convert.ToInt32(e.Estado));
        se.Close();
    }
    public Expediente ConsultaPorID(int IDExpediente)
    {
        using var sr = new StreamReader(path);
        Expediente expedienteRetorno = new Expediente();
        int IDactual;
        bool found = false;
        while (!sr.EndOfStream)
        {
            IDactual = Convert.ToInt32(sr.ReadLine()); ;
            if (IDactual == IDExpediente)
            {
                found = true;
                Console.WriteLine("El Expediente fue encontrado");
                expedienteRetorno.IDExpediente = IDactual;
                expedienteRetorno.FechaInicio = Convert.ToDateTime(sr.ReadLine());
                expedienteRetorno.Caratula = sr.ReadLine();
                expedienteRetorno.FechaActualizacion = Convert.ToDateTime(sr.ReadLine());
                expedienteRetorno.IDUsuario = Convert.ToInt32(sr.ReadLine());
                expedienteRetorno.Estado = (EstadoExpediente) Convert.ToInt32(sr.ReadLine());
            }
        }
        sr.Close();
        if (!found) Console.WriteLine("El Expediente no fue encontrado");
        return expedienteRetorno;
    }
    public List<Expediente> ConsultaPorTodos()
    {
        using var sr = new StreamReader(path);
        List<Expediente> listaExpedientes = new List<Expediente>();
        Expediente expedienteRetorno = new Expediente();
        while (!sr.EndOfStream)
        {
            expedienteRetorno.IDExpediente = Convert.ToInt32(sr.ReadLine());
            expedienteRetorno.FechaInicio = Convert.ToDateTime(sr.ReadLine());
            expedienteRetorno.Caratula = sr.ReadLine();
            expedienteRetorno.FechaActualizacion = Convert.ToDateTime(sr.ReadLine());
            expedienteRetorno.IDUsuario = Convert.ToInt32(sr.ReadLine());
            expedienteRetorno.Estado =(EstadoExpediente) Convert.ToInt32 (sr.ReadLine());
            listaExpedientes.Add(expedienteRetorno);
        }
        se.Close();
        return listaExpedientes;
    }
    public void ModificarExpediente(Expediente e)
    {
        using var sr = new StreamReader(path);
        using var sw = new StreamWriter(pathaux, false);
        int IDactual;
        bool found = false;
        while (!sr.EndOfStream && !found)
        {
            IDactual = Convert.ToInt32(sr.ReadLine()); ;
            if (IDactual == e.IDExpediente)
            {
                found = true;
                Console.WriteLine("El Expediente fue encontrado");
                sw.WriteLine(IDactual);
                sw.WriteLine(e.FechaInicio);
                sw.WriteLine(e.Caratula);
                sw.WriteLine(e.FechaActualizacion);
                sw.WriteLine(e.IDUsuario);
                sw.WriteLine(e.Estado); 
            }
            else
            {
                sw.WriteLine(IDactual);
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(sr.ReadLine());
                }
            }
        }
        sr.Close();
        sw.Close();
        File.Delete(path);
        File.Move(pathaux, path);
    }
}
