using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Serverless.eats
{
    public static class Menus
    {
        [FunctionName("Menus")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Fetching menu's"); 

            try{ 
                string dummyResponse =" { \"restaurant\":{ \"name\": \"Casa Calvo\", \"Cuisine\": \"Latin\", \"openHours\":[{\"Day\": \"Saturday\", \"open\":\"4pm\", \"close\":\"11pm\"},{\"Day\": \"Sunday\", \"open\":\"4pm\", \"close\":\"10pm\"}] },\"menu\":[{ \"name\": \"Mains\", \"description\":\"Epic meals that hit the spot just right\", \"items\":[{ \"Name\":\"Gallo Pinto\", \"Description”:Rice, beans, eggs: Mas tico que el gallo pinto!\", \"price\": 10.00 },{ \"Name\":\"Arroz con Pollo\", \"Description\":\"Chicken, fried rice, spices. Is a dinner without Arroz con pollo really a dinner?\", \"price\": 15.00 }] }] } "; 
                
                return new OkObjectResult(dummyResponse); 
            } catch (Exception ex){ 
                log.LogError("Problem accepting the request."); 
                log.LogError(ex.ToString()); 
                return new BadRequestObjectResult("Problem accepting the request"); 
            } 
        }
    }
}
