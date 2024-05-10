

using webapi;
using webapi.Models;

class CategoriaServices : ICategoriaSerices
{
     TareasContext tareasContext;


   public CategoriaServices(TareasContext Context)
   {

    tareasContext = Context;
   }


    public IEnumerable<Categoria> GetCategoria()
    {

        return tareasContext.Categorias;
    }

    public async Task Save(Categoria categoria)
    {   
        tareasContext.Categorias.Add(categoria);
        await tareasContext.SaveChangesAsync();
    }

    public async Task Update(Categoria categoria, Guid id)
    {
         var CurrentCategoria  = tareasContext.Categorias.Find(id);
    
    if(CurrentCategoria != null )
    {
        
            CurrentCategoria.Nombre = categoria.Nombre;
            CurrentCategoria.Descripcion = categoria.Descripcion;
            // CurrentCategoria.Peso = categoria.Peso;

            await tareasContext.SaveChangesAsync();
    }

    }


    public async Task Delete(Guid id)
    {
    var CurrentCategoria  = tareasContext.Categorias.Find(id);

    if(CurrentCategoria != null )
    {
        tareasContext.Categorias.Remove(CurrentCategoria);
         await tareasContext.SaveChangesAsync();
    }

    }


}

public interface ICategoriaSerices
{
    IEnumerable<Categoria> GetCategoria();
    Task Save(Categoria categoria);
    Task Update(Categoria categoria, Guid id);
    Task Delete(Guid id);
}