namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente e,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(u.permisos,Permiso.ExpedienteModificacion)){repo.ModificarExpediente(e);}
        else throw new AutorizacionException("El usuario no contaba con permisos");
    }
}