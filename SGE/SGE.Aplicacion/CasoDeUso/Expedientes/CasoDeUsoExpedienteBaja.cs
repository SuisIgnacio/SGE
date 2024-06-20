namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repo) 
{
    public void Ejecutar (int IDExpediente,Usuario U) 
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(U.permisos,Permiso.ExpedienteBaja))
            repo.BajaExpediente(IDExpediente); 
        else throw new AutorizacionException("el usuario no cuenta con permisos");
    }
} 
