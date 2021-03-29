using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Persistence;
using EasyBus.Shared.Repository.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork unitOfWork;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork context)
        {
            unitOfWork = context;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var bus = new Bus()
            {
                Capacity = 100,
                Description = "No",
                Operator = "Lala",
                SeatsBooked = 1,
                VehicleNumber = "sdssd"
            };
            unitOfWork.Buses.Add(bus);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
