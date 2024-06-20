namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
    public void Ejecutar (Expediente e,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        ValidadorExpedientes v= new ValidadorExpedientes();
        if(s.autoriza(u.permisos,Permiso.ExpedienteAlta) ){
              if ( v.ValidarExpediente(e) ){
                 repo.AltaExpediente(e);
              }
              else
              {
                throw new ValidacionException () ;
              }
        }
        else throw new AutorizacionException("El usuario no cuenta con permisos");
    } 
}
