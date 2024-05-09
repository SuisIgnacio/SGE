namespace SGE.Repositorios;
using SGE.Aplicacion;
using System.Reflection.PortableExecutable;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly string path = "expediente.txt";
    readonly string _id_expediente="IDExpediente.txt";
    public void BajaExpediente(int IDExpediente)
    {
        string pathaux="temp.txt";
        File.CreateText(pathaux);
        using var sr=new StreamReader(path);
        using var sw=new StreamWriter(pathaux,false);
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
        sw.Close();
    }
    public int asignarID()
    {
        using var sr=new StreamReader(_id_expediente);
        using var sw=new StreamWriter(_id_expediente,false);
        int aux=Convert.ToInt32(sr.ReadLine());
        sw.WriteLine(aux++);
        sw.Close();
        sr.Close();
        return aux;
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
        sr.Close();
        return listaExpedientes;
    }
    public void ModificarExpediente(Expediente e)
    {
        string pathaux="temp.txt";
        File.CreateText(pathaux);
        using var sr=new StreamReader(path);
        using var sw=new StreamWriter(pathaux,false);
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
}
