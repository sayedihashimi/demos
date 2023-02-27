using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebHookSample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MyWebHook : ControllerBase {

        [HttpPost]
        public async Task PostHookAsync([FromBody] object body) {
            Console.WriteLine($"PostHook2 called.\nRequest.Headers:\n{GetRequestString(Request)}");
        }

        private string GetRequestString(HttpRequest request) {
            var sb = new StringBuilder();

            foreach(var key in request.Headers.Keys) {
                sb.AppendLine($"\t{key}: {Request.Headers[key]}");
            }
            return sb.ToString();
        }
    }
}
