namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
    public void Ejecutar (Expediente e,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(u.permisos,Permiso.ExpedienteAlta)){repo.AltaExpediente(e);}
        else throw new AutorizacionException("El usuario no cuenta con permisos");
    } 
}