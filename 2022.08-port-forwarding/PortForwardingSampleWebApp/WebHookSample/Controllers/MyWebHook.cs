using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebHookSample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MyWebHook : ControllerBase {

        [HttpPost]
        public async Task PostHookAsync([FromBody] object body) {
            var foo = Request;
            Console.WriteLine($"PostHook called.\nRequest.Headers:\n{GetRequestString(Request)}");

            //throw new NullReferenceException();
            //Console.WriteLine($"going to sleep forever");
            //while (true) {
            //    Console.Write(".");
            //    await Task.Delay(5000);
            //}
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
