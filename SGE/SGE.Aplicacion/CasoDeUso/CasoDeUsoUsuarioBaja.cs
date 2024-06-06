namespace SGE.Aplicacion;

public class CasoDeUsoBajaUsuario (IUsuarioRepositorio repo)
{
    public void Ejecurar(Usuario pedido, Usuario victima)
    {
        if (pedido.Admin){repo.UsuarioBaja(victima);}
        else throw new AutorizacionException("Solo el admin puede dar de baja usuarios");
    }
}