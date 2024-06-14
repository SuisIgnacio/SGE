namespace SGE.Aplicacion;
public class CasoDeUsoUsuarioConsulta(IUsuarioRepositorio repo)
{

    public List<Usuario> Ejecutar(Usuario u){
        if (u.Admin)
        {
            return repo.ConsultarPorTodos(); 
        }
        else return new List<Usuario>();
    }
}