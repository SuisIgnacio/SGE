namespace SGE.Aplicacion; 

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool autoriza (int num)
    {
        if (num == 1){ return true;}
        else {return false; }
    }
}