using SGE.Repositorios;
using SGE.Aplicacion;
namespace Escuela;

public class SGESqlite
{
    public static void Inicializar()
    {
        using var context = new SGEDBContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
            context.Tramites.Add(new Tramite() { IDExpediente = 1, Etiqueta = EtiquetaTramite.Notificacion,Contenido = "",
                                                FechaCreacion= DateTime.Now,FechaActualizacion= DateTime.Now,IDUsuario = 1 });
            context.Expedientes.Add(new Expediente(){Caratula = "Ingles", FechaActualizacion=DateTime.Now, FechaInicio=DateTime.Now,
                                    IDUsuario=1,Estado= EstadoExpediente.RecienIniciado});
            context.Usuarios.Add(new Usuario() { Id = 1,Nombre= "juan",Apellido= "Perez",Correo="sos"});
            context.SaveChanges(); 
        }
    }
}
