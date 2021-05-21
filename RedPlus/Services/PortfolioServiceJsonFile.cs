using RedPlus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedPlus.Services
{
    public class PortfolioServiceJsonFile
    {
        public IEnumerable<Portfolio> GetPortfolios() {
            //var jsonFileName = @"C:\Users\CL\Desktop\CL\.net\Razorpages\RedPlus.RazorPages\Razor\RedPlus.RazorPages\RedPlus\wwwroot\Portfolios\portfolios.json";
            var jsonFileName = @"C:\Users\CL\Desktop\VisualAcademy\RedPlus.RazorPages\RedPlus\wwwroot\Portfolios\portfolios.json";
            using (var jsonFileReader = File.OpenText(jsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var portfolios = JsonSerializer.Deserialize<Portfolio[]>(jsonFileReader.ReadToEnd(), options);
                return portfolios;
            }
        }

    }
}
