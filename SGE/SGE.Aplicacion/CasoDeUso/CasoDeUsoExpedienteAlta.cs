namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
    public void Ejecutar (Expediente e,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        ValidadorExpedientes v= new ValidadorExpedientes();
        if(s.autoriza(u.permisos,Permiso.ExpedienteAlta) && v.ValidarExpediente(e))
        {repo.AltaExpediente(e);}
        else throw new AutorizacionException("El usuario no cuenta con permisos");
    } 
}