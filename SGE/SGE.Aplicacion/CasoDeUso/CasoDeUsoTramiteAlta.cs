namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta (ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tr,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        ValidadorTramites v=new ValidadorTramites();
        if(s.autoriza(u.permisos,Permiso.TramiteAlta)&&v.ValidarTramite(tr))
        {repo.TramiteAlta(tr);}
        else throw new AutorizacionException("El usuario no cuenta con permisos");
    }
}