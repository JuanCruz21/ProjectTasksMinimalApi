using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectTasks1;
using projectTasks1.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareaContext>(p=>p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TareaContext>(
    "Server=127.0.0.1;Port=5432;Database=TareasDB;User Id=prueba;Password=prueba;"
);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", ([FromServices] TareaContext DbContext) => 
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ DbContext.Database.IsNpgsql());
});
app.MapGet("/categorias", ([FromServices] TareaContext DbContext) => 
{
    return Results.Ok(DbContext.categorias.Include(p=>p.Tareas).ToList());
});
app.MapGet("/tareas", ([FromServices] TareaContext DbContext) => 
{
    return Results.Ok(DbContext.tareas.Include(p=>p.categoria).ToList());
});
app.MapPost("/tarea", async ([FromServices] TareaContext DbContext, Tarea tarea) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.UtcNow;
    await DbContext.tareas.AddAsync(tarea);
    await DbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapPut("/tarea/{id}", async ([FromServices] TareaContext DbContext,[FromBody] Tarea tarea,[FromRoute] Guid id) =>
{
    var tareaActual = await DbContext.tareas.FindAsync(id);

    if (tareaActual == null)
    {
        return Results.NotFound();
    }
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.Descripcion = tarea.Descripcion;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;
    await DbContext.SaveChangesAsync();
    return Results.Ok(tareaActual);
});
app.MapDelete("/tarea/{id}", async ([FromServices] TareaContext DbContext,[FromRoute] Guid id) =>
{
    var tareaActual = await DbContext.tareas.FindAsync(id);
    if (tareaActual!=null)
    {
        DbContext.tareas.Remove(tareaActual);
        await DbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});
app.Run();
