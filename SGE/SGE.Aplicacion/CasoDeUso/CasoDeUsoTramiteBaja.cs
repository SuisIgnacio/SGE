namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja (ITramiteRepositorio repo)
{
    public void Ejecutar(int idTramite,Usuario u)
    {
        ServicioAutorizacion s=new ServicioAutorizacion();
        if(s.autoriza(u.permisos,Permiso.TramiteBaja)){repo.TramiteBaja(idTramite);}
        else throw new AutorizacionException("El usuario no cuenta con permisos");
    }
}