using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace FabioTavaresDev.ApimFunctionManagedIdentity.Function
{
    public static class HttpTrigger1
    {
        private static HttpClient httpClient = new HttpClient();

        [FunctionName("HttpTrigger1")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var endpoitToCall = System.Environment.GetEnvironmentVariable("TargetEndPoint", System.EnvironmentVariableTarget.Process);

            await httpClient.GetAsync(endpoitToCall);

            return new OkResult();
        }
    }
}
