namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{
    public void Ejecutar (Tramite modificado,Usuario u)
    {
        ValidadorTramites v=new ValidadorTramites();
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(u.permisos,Permiso.TramiteModificacion)){
            if (v.ValidarTramite(modificado)){
                repo.TramiteModificacion(modificado);
            }
            else
            {
                throw new ValidacionException () ;
            }
        }
        else throw new AutorizacionException("El usuario no contaba con permisos");

    }
}
