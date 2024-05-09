namespace Api.net.Controllers
{

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
    public class HelloWorldController: ControllerBase
    {
         private readonly ILogger<WeatherForecastController> _logger;
         IHelloWorldService helloWorldService;

        public HelloWorldController(ILogger<WeatherForecastController> logger, IHelloWorldService helloWorld)
        {       
             _logger = logger;

                helloWorldService = helloWorld;
        }


        [HttpGet]
        public IActionResult Get()
        {

            _logger.LogInformation("llegue a hola mundo");
            return Ok(helloWorldService.GetHelloWorld());

        }
    }
}