namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja (IUsuarioRepositorio repo)
{
    public void Ejecutar(Usuario pedido, Usuario victima)
    {
        if (pedido.Admin){repo.UsuarioBaja(victima.Id);}
        else throw new AutorizacionException("Solo el admin puede dar de baja usuarios");
    }
}