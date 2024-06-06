namespace SGE.Aplicacion; 

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool autoriza (List<Permiso> lista,Permiso p)
    {
        foreach (Permiso permiso in lista)
        {
            if(permiso == p){return true;}
        }
        return false;
    }
}