using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace Appsx.Pages
{
    public class Index2Model : PageModel
    {
        public string Message { get; private set; } = "PageModel em C#";

        public void OnGet()
        {
            Message += $" Hora do servidor { DateTime.Now }";
        }
    }
}
