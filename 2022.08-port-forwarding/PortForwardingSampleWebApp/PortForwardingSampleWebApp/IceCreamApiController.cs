using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortForwardingSampleWebApp {
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamApiController : ControllerBase {
        private int vanilla = 0;
        private int chocolate = 0;
        private int strawberry = 0;
        private int unknown = 0;
        [HttpPost]
        public ActionResult AddVote(string flavor) {
            if (string.IsNullOrEmpty(flavor)) {
                return NotFound();
            }

            Console.WriteLine($"incoming vote for: {nameof(vanilla)}");

            if(string.Equals(nameof(vanilla), flavor, StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine($"incoming vote for: {nameof(vanilla)}");
                vanilla++;
            }
            else if(string.Equals(nameof(chocolate), flavor, StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine($"incoming vote for: {nameof(chocolate)}");
                chocolate++;
            }
            else if(string.Equals(nameof(strawberry), flavor, StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine($"incoming vote for: {nameof(strawberry)}");
                strawberry++;
            }
            else {
                return NotFound(flavor);
            }

            Console.WriteLine($"");

            return CreatedAtAction(nameof(AddVote), new { flavor = flavor });
        }
    }
}
