using Microsoft.EntityFrameworkCore;
using projectTasks1.Models;

namespace projectTasks1
{
    public class TareaContext: DbContext
    {
        public DbSet<Categoria> categorias {get; set;}
        public DbSet<Tarea> tareas {get; set;}
        public TareaContext(DbContextOptions<TareaContext> options): base(options){}
        //Un metodo override se debe llamar protected
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //Datos de prueba
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria()
            { CategoriaId = Guid.Parse("ffaca5fa-db0c-4acc-8300-dda804df4177"),
                Nombre = "Tecnologia", 
                Descripcion = "Desarrollo",
                Peso = 1
            });
            categoriasInit.Add(new Categoria()
            { CategoriaId = Guid.Parse("bdb76bbc-7604-422c-9717-e735eb233290"), 
                Nombre = "Tecnologia",
                Descripcion = "Logistica",
                Peso = 2
            });
            categoriasInit.Add(new Categoria()
            { CategoriaId = Guid.Parse("ff2e1696-e1c6-43c7-a789-152dcc93deef"), 
                Nombre = "Tecnologia",
                Descripcion = "Administracion",
                Peso = 1

            });
            //Datos de prueba
            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea()
            { TareaId = Guid.Parse("a30569a5-ab8f-4d17-8b46-013eca1d77c2"), 
                Titulo = "Desarrollo de software",
                PrioridadTarea = Prioridad.media,
                FechaCreacion = DateTime.UtcNow,
                Descripcion = "Desarrollo de software para la empresa",
                CategoriaId = Guid.Parse("ffaca5fa-db0c-4acc-8300-dda804df4177")
            });
            tareasInit.Add(new Tarea()
            { TareaId = Guid.Parse("2ec0f884-d423-4f7c-ab22-88ac8f61882d"), 
                Titulo = "Desarrollo de aplicaciones",
                PrioridadTarea = Prioridad.baja,
                FechaCreacion = DateTime.UtcNow,
                Descripcion = "Desarrollo de aplicaciones para la empresa",
                CategoriaId = Guid.Parse("bdb76bbc-7604-422c-9717-e735eb233290")
            });
            tareasInit.Add(new Tarea()
            { TareaId = Guid.Parse("0df62d8a-30be-450a-aee8-556361fcf51f"), 
                Titulo = "Desarrollo de paginas web",
                PrioridadTarea = Prioridad.alta,
                FechaCreacion = DateTime.UtcNow,
                Descripcion = "Desarrollo de paginas web para la empresa",
                CategoriaId = Guid.Parse("ff2e1696-e1c6-43c7-a789-152dcc93deef")
                
            });
            //Configuracion de las entidades
            modelBuilder.Entity<Categoria>(categoria=>{
                categoria.ToTable("Categoria");
                categoria.HasKey(c=>c.CategoriaId);
                categoria.Property(c=>c.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(c=>c.Descripcion);
                categoria.Property(c=>c.Peso);
                categoria.HasData(categoriasInit);
            });
            modelBuilder.Entity<Tarea>(tarea=>{
                tarea.ToTable("Tarea");
                tarea.HasKey(t=>t.TareaId);
                tarea.HasOne(t=>t.categoria).WithMany(t=>t.Tareas).HasForeignKey(c=>c.CategoriaId);
                tarea.Property(t=>t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t=>t.Descripcion).IsRequired(false);
                tarea.Property(t=>t.PrioridadTarea).IsRequired();
                tarea.Property(t=>t.FechaCreacion).IsRequired();
                tarea.Ignore(t=>t.Resume);
                tarea.HasData(tareasInit);
            });
        }
    }
}