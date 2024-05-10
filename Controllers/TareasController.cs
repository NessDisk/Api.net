using Api.net.Services;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;


namespace webapi.Controllers;

[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    ITareasServices tareaService;

    public TareasController(ITareasServices service) {
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get() {
        return Ok(tareaService.GetTareas());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea) {
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea) {
        tareaService.Update(tarea, id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
        tareaService.Delete(id);
        return Ok();
    }
}
