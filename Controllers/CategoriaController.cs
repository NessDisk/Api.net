
namespace Api.net.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using webapi.Models;


    [ Route("api/[Controller]")]
    public class CategoriaController: ControllerBase
    {
        ICategoriaSerices categoriaSerices;

            public CategoriaController(ICategoriaSerices categoriaServicesInyection)
            {
                    categoriaSerices = categoriaServicesInyection;
            }

            [HttpGet]
            public IActionResult GetCategoria()
            {
                return Ok(categoriaSerices.GetCategoria());
            }

            [HttpPost]
            public IActionResult PostCategoria([FromBody] Categoria   categoria)
            {
                categoriaSerices.Save(categoria);
                return Ok();

            }   
            [HttpPut("{id}")]
            public IActionResult UpdateCategoria( Guid id ,[FromBody] Categoria   categoria)
            {
                categoriaSerices.Update(categoria,id);
                return Ok();

            }   

            [HttpDelete("{id}")]
            public IActionResult DeleteCategoria(Guid id)
            {
                categoriaSerices.Delete(id);
                return Ok();
            }



    }
}