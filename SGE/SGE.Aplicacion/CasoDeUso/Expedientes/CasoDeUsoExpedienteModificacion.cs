namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente e,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        ValidadorExpedientes v=new ValidadorExpedientes();
        if(s.autoriza(u.permisos,Permiso.ExpedienteModificacion))
        {
            if(v.ValidarExpediente(e))
            {
                repo.ModificarExpediente(e);
            }
            else throw new ValidacionException();
        }
        else throw new AutorizacionException("El usuario no contaba con permisos");
    }
}
