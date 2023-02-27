using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WebHookSample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MyWebHook : ControllerBase {

        [HttpPost]
        public async Task PostHookAsync([FromBody] object body) {
            Console.WriteLine($"PostHook2 called.\nRequest.Headers:\n{GetRequestString(Request)}");

            JsonElement foo = (JsonElement)body;

            string? jsonStr = null;
            JsonNode? issueDetailsNode = null;

            if(body is object) {
                jsonStr = body.ToString();
            }
            if(jsonStr is object && jsonStr.Length > 0) {
                issueDetailsNode = JsonNode.Parse(jsonStr);
            }

            if(issueDetailsNode is object) {
                var details = new IssueDetails(issueDetailsNode);
                Console.WriteLine(GetStringForIssueDetails(Request,details));
            }
        }

        private string GetStringForIssueDetails(HttpRequest request, IssueDetails issueDetails) =>
            $@"Event: {Request.Headers["x-github-event"].ToString()}
Action: {issueDetails.Action}
Issue Url: {issueDetails.IssueUrl}
Issue Title: {issueDetails.IssueTitle}
Issue Body: {issueDetails.IssueBody}
Sender: {issueDetails.SenderLogin}
Comment URL: {issueDetails.CommentUrl}
Comment body: {issueDetails.CommentBody}";

        private string GetRequestString(HttpRequest request) {
            var sb = new StringBuilder();

            foreach(var key in request.Headers.Keys) {
                sb.AppendLine($"\t{key}: {Request.Headers[key]}");
            }
            return sb.ToString();
        }

        public class IssueDetails {
            public IssueDetails(JsonNode jsonNode) {
                Action = jsonNode["action"]?.ToString() ?? string.Empty;
                SenderLogin = jsonNode["sender"]?["login"]?.ToString() ?? string.Empty;
                IssueUrl = jsonNode["issue"]?["url"]?.ToString() ?? string.Empty;
                IssueTitle = jsonNode["issue"]?["title"]?.ToString() ?? string.Empty;
                IssueBody = jsonNode["issue"]?["body"]?.ToString() ?? string.Empty;
                CommentUrl = jsonNode["comment"]?["url"]?.ToString() ?? string.Empty;
                CommentBody = jsonNode["comment"]?["body"]?.ToString() ?? string.Empty;
            }
            public string? Action { get; set; }
            public string? SenderLogin { get; set; }
            public string? IssueUrl { get; set; }
            public string? IssueBody { get; set; }
            public string? IssueTitle { get; set; }
            public string? CommentUrl { get; set; }
            public string? CommentBody { get; set; }
        }
    }
}
