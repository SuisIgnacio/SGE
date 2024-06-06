namespace SGE.Aplicacion; 

public interface IServicioAutorizacion 
{
    public Boolean autoriza(List<Permiso> lista,Permiso p);
}