namespace Api.net.Controllers
{

using Microsoft.AspNetCore.Mvc;
    using webapi;

    [ApiController]
[Route("api/[controller]")]
    public class HelloWorldController: ControllerBase
    {
         private readonly ILogger<WeatherForecastController> _logger;

          TareasContext dbcontext;

         IHelloWorldService helloWorldService;

        public HelloWorldController(ILogger<WeatherForecastController> logger, IHelloWorldService helloWorld, TareasContext db)
        {       
             _logger = logger;
                dbcontext = db;
                helloWorldService = helloWorld;
        }


        [HttpGet]
        public IActionResult Get()
        {

            _logger.LogInformation("llegue a hola mundo");
            return Ok(helloWorldService.GetHelloWorld());

        }

        
    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
    }
}