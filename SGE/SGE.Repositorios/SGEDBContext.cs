namespace SGE.Repositorios;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class SGEDBContext:DbContext
{
    #nullable disable
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<PermisoDb> Permisos { get; set; }
    #nullable restore 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
