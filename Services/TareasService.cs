using webapi.Models;
namespace webapi.Services;

public class TareasService : ITareasService
{
    TareasContext context;

    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;

    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;

    }

    public async Task Save (Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update (Guid id, Tarea tarea)
    {
        var taraeActual = context.Tareas.Find(id);

        if (taraeActual != null)
        {
            taraeActual.Titulo = tarea.Titulo;
            taraeActual.Descripcion = tarea.Descripcion;
            taraeActual.PrioridadTarea = tarea.PrioridadTarea;
            await context.SaveChangesAsync();
        }
        
    }

    public async Task Delete (Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
        
    }

}

public interface ITareasService {
     IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete (Guid id);

}