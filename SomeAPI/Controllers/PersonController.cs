using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace SomeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger)
        {
            //_logger = logger;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        }


        [HttpGet(Name = "GetPerson")]
        public Person Get()
        {
            //_logger.LogInformation("Сбор данных");
            Log.Information("Сбор данных");
            Person outp;
            try
            {
                outp = new Person() { Name = "Иван", LastName = "Иванов" };
                Thread.Sleep(1000);
                Log.Information($"Сбор данных завершен: {outp.Name} {outp.LastName}.");
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Произошла ошибка.");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
            //_logger.LogInformation("Сбор данных завершен: " + outp.Name + " " + outp.LastName + ".");
            return outp;
            
        }
    }
}
