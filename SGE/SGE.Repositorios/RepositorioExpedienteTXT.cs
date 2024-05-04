namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT: IExpedienteRepositorio
{
    readonly string _nombreArch="expedientes.txt";
    public void BajaExpediente(int IDExpediente)
    {
        using var sr=new StringReader(_nombreArch);
        using var sw=new StreamWriter(_nombreArch,true);
        int IDactual;
        bool found=false;
        while(!sr.EndOfStream && !found)
        {
            IDactual= Convert.ToInt32(reader.ReadLine());;
            if(IDactual==IDExpediente)
            {
                found=true;
                
            }else{
                for(int i=0;i<5;i++)
                {
                    sr.ReadLine();   
                }
            }
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

    }
    public List<Expediente> ConsultaPorTodos()
    {

    }
    public void ModificarExpediente(Expediente e)
    {

    }
}