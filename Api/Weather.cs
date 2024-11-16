using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Weather
    {
        private readonly ILogger<Weather> _logger;

        public Weather(ILogger<Weather> logger)
        {
            _logger = logger;
        }

        [Function("Weather")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            var returnObject = """
                                [
                  {
                    "date": "2022-01-06",
                    "temperatureC": 1,
                    "summary": "Freezing"
                  },
                  {
                    "date": "2022-01-07",
                    "temperatureC": 14,
                    "summary": "Bracing"
                  },
                  {
                    "date": "2022-01-08",
                    "temperatureC": -13,
                    "summary": "Freezing"
                  },
                  {
                    "date": "2022-01-09",
                    "temperatureC": -16,
                    "summary": "Balmy"
                  },
                  {
                    "date": "2022-01-10",
                    "temperatureC": -2,
                    "summary": "Chilly"
                  }
                ]
                
                """;
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(returnObject);
        }
    }
}
