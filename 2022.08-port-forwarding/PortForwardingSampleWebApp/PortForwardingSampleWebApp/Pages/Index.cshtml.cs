using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortForwardingSampleWebApp.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private SingleCounter counter = SingleCounter.GetCounter();
        public int CurrentCount = 0;

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet() {
            CurrentCount = counter.GetCount();
        }
        public void OnPost() {
            counter.Increment();
            CurrentCount = counter.GetCount();
        }
    }
}