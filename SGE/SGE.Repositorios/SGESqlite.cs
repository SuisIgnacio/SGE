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
            context.Tramites.Add(new Tramite() { IDExpediente = 1, Etiqueta = EtiquetaTramite.Notificacion,Contenido = "ahsbd",
                                                FechaCreacion= DateTime.Now,FechaActualizacion= DateTime.Now,IDUsuario = 1 });
            context.Expedientes.Add(new Expediente(){Caratula = "Ingles", FechaActualizacion=DateTime.Now, FechaInicio=DateTime.Now,
                                    IDUsuario=1,Estado= EstadoExpediente.RecienIniciado});
            Usuario admin=new Usuario() { Id = 1,Nombre= "juan",Apellido= "Perez",Correo="sos"};
            admin.setAdmin();
            context.Add(admin);
            foreach(Permiso p in admin.permisos)
            {
                PermisoDb PermisoTabla= new PermisoDb(){permiso=p,IdUsuario=admin.Id};
                context.Add(PermisoTabla);
            }
            context.SaveChanges(); 
        }
    }
}