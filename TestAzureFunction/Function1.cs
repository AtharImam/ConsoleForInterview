using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctionServices;

namespace TestAzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function1 processed a request.");

            string snum1 = req.Query["num1"];
            string snum2 = req.Query["num2"];

            int num1 = 0;
            int.TryParse(snum1, out num1);

            int num2 = 0;
            int.TryParse(snum2, out num2);

            int result = new Calculator().Add(num1, num2);

            return new OkObjectResult(new { result });
        }
    }
}
