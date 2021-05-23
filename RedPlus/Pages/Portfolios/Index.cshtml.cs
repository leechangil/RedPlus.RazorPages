using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedPlus.Models;
using RedPlus.Services;

namespace RedPlus.Pages.Portfolios
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioServiceJsonFile _service;

        public IndexModel(PortfolioServiceJsonFile service)
        {
            this._service = service;
            Console.WriteLine("Porfolios Index.cshtml.cs »ý¼ºÀÚ");
        }
        public IEnumerable<Portfolio> Portfolios { get; private set; }
        public void OnGet()
        {
            Portfolios = _service.GetPortfolios();
        }
    }
}
