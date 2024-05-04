namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT: IExpedienteRepositorio
{
    readonly string _nombreArch="expedientes.txt";
    public void BajaExpediente(int IDExpediente)
    {
        readonly string archAux="temp.txt";
        using var sr=new StringReader(_nombreArch);
        using var sw=new StreamWriter(File.CreateText(archAux),true);
        int IDactual;
        bool found=false;
        while(!sr.EndOfStream)
        {
            IDactual= Convert.ToInt32(reader.ReadLine());;
            if(IDactual==IDExpediente)
            {
                found=true;
                Console.WriteLine("El Expediente fue eliminado");
            }else{
                for(int i=0;i<5;i++)
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
    public void AltaExpediente(Expediente e)
    {
        using var sw=new StreamWriter(_nombreArch,true);
        sw.WriteLine(e.ID);
        sw.WriteLine(e.FechaInicio);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaFinalizacion);
        sw.WriteLine(e.IDUsuario);
        sw.WriteLine(e.Estado);
    }
    public Expediente ConsultaPorID(int ID)
    {
        using var sr=new StringReader(_nombreArch);
        Expediente expedienteRetorno=new Expediente();
        int IDactual;
        bool found=false;
        while(!sr.EndOfStream)
        {
            IDactual= Convert.ToInt32(sr.ReadLine());;
            if(IDactual==IDExpediente)
            {
                found=true;
                Console.WriteLine("El Expediente fue encontrado");
                expedienteRetorno.ID=IDactual;
                expedienteRetorno.FechaInicio=Convert.DateTime(sr.ReadLine());
                expedienteRetorno.Caratula=sr.ReadLine();
                expedienteRetorno.FechaFinalizacion=Convert.DateTime(sr.ReadLine());
                expedienteRetorno.IDUsuario=Convert.DateTime(sr.ReadLine());
                expedienteRetorno.Estado=sr.ReadLine();
            }
        }
        if(!found) Console.WriteLine("El Expediente no fue encontrado");
        return expedienteRetorno;
    }
    public List<Expediente> ConsultaPorTodos()
    {
        using var sr=new StringReader(_nombreArch);
        List<Expediente> listaExpedientes=new List<Expediente>();
        while(!sr.EndOfStream)
        {
            expedienteRetorno.ID=IDactual;
            expedienteRetorno.FechaInicio=Convert.DateTime(sr.ReadLine());
            expedienteRetorno.Caratula=sr.ReadLine();
            expedienteRetorno.FechaFinalizacion=Convert.DateTime(sr.ReadLine());
            expedienteRetorno.IDUsuario=Convert.DateTime(sr.ReadLine());
            expedienteRetorno.Estado=sr.ReadLine();
        }
    }
    public void ModificarExpediente(Expediente e)
    {

    }
}