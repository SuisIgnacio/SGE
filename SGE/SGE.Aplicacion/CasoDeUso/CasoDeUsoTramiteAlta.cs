namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta (ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tr,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(u.permisos,Permiso.TramiteAlta)){repo.TramiteAlta(tr);}
        else throw new AutorizacionException("El usuario no cuenta con permisos");
    }
}