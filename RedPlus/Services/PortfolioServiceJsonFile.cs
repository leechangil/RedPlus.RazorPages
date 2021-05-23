using Microsoft.AspNetCore.Hosting;
using RedPlus.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RedPlus.Services
{
    public class PortfolioServiceJsonFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioServiceJsonFile(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Console.WriteLine("PortfolioServiceJsonFile 생성자");
        }

        private string JsonFileName
        {
            get
            {
                return Path.Combine(_webHostEnvironment.WebRootPath, "Portfolios", "portfolios.json");
            }
        }

        public IEnumerable<Portfolio> GetPortfolios()
        {
            //var jsonFileName = @"C:\Users\CL\Desktop\CL\.net\Razorpages\RedPlus.RazorPages\Razor\RedPlus.RazorPages\RedPlus\wwwroot\Portfolios\portfolios.json";
            //var jsonFileName = @"C:\Users\CL\Desktop\VisualAcademy\RedPlus.RazorPages\RedPlus\wwwroot\Portfolios\portfolios.json";
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var portfolios = JsonSerializer.Deserialize<Portfolio[]>(jsonFileReader.ReadToEnd(), options);
                return portfolios;
            }
        }

    }
}
