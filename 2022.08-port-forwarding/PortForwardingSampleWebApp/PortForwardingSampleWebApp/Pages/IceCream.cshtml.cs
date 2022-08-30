using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace PortForwardingSampleWebApp.Pages
{
    public class IceCreamModel : PageModel {
        private IceCreamCounter _counter;
        private int vanilla = 0;
        private int chocolate = 0;
        private int strawberry = 0;

        public IceCreamModel(IceCreamCounter iceCreamCounter) {
            _counter = iceCreamCounter;
        }

        public void OnGet() {
            if (_counter != null) {
                vanilla = _counter.Vanilla;
                chocolate = _counter.Chocolate;
                strawberry = _counter.Strawberry;
            }
        }
        public IceCreamCounter Counter {
            get { return _counter; }
        }
        public void OnPostVanilla() {
            _counter.IncrementVanilla();
            PrintRequestInfo(nameof(vanilla));
        }
        public void OnPostChocolate() {
            _counter.IncrementChacolate();
            PrintRequestInfo(nameof(chocolate));
        }
        public void OnPostStrawberry() {
            _counter.IncrementStrawberry();
            PrintRequestInfo(nameof(strawberry));
        }
        private void PrintRequestInfo(string iceCreamType) {
            var ua = Request.Headers["User-Agent"].ToString();
            Console.WriteLine($"vote for '{iceCreamType}'. UA={ua}");
        }
    }
}
