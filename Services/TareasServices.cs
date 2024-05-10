using webapi;
using webapi.Models;

namespace Api.net.Services
{
    public class TareasServices: ITareasServices
    {
        TareasContext tareasContext;

        public  TareasServices(TareasContext context){
                this.tareasContext = context;
        }

    
    public IEnumerable<Tarea> GetTareas()
    {

        return tareasContext.Tareas;
    }

    public async Task Save(Tarea tarea)
    {   
        tareasContext.Tareas.Add(tarea);
        await tareasContext.SaveChangesAsync();
    }

    public async Task Update(Tarea tarea, Guid id)
    {
         var CurrenTarea  = tareasContext.Tareas.Find(id);
    
    if(CurrenTarea != null )
    {
        
            CurrenTarea.Titulo = tarea.Titulo;
            CurrenTarea.Descripcion = tarea.Descripcion;
            CurrenTarea.FechaCreacion = tarea.FechaCreacion;
            CurrenTarea.PrioridadTarea = tarea.PrioridadTarea;
            

            await tareasContext.SaveChangesAsync();
    }

    }


    public async Task Delete(Guid id)
    {
    var CurrenTarea  = tareasContext.Tareas.Find(id);

    if(CurrenTarea != null )
    {
        tareasContext.Tareas.Remove(CurrenTarea);
         await tareasContext.SaveChangesAsync();
    }

    }


    }

 public interface ITareasServices
    {
        IEnumerable<Tarea> GetTareas();
        Task Save(Tarea tarea);
        Task Update(Tarea tarea, Guid id);
       Task Delete(Guid id);
    }

}

