namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{
    public void Ejecutar (Tramite modificado,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(u.permisos,Permiso.TramiteModificacion)){repo.TramiteModificacion(modificado);}
        else throw new AutorizacionException("El usuario no contaba con permisos");

    }
}
