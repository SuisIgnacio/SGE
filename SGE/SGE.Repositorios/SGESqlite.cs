namespace SGE.Repositorios;
using SGE.Aplicacion;

public class SGESqlite
{
    public static void Inicializar()
    {
        using var context = new SGEDBContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
            context.SaveChanges(); 
        }
    }
}