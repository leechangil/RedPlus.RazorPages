using Microsoft.AspNetCore.Hosting;
using RedPlus.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void AddRating(int portfolioId, int rarting)
        {
            var portfolios = GetPortfolios();
            if (portfolios.First(p => p.Id == portfolioId).Ratings == null)
            {
                portfolios.First(p => p.Id == portfolioId).Ratings = new int[] { rarting };
            }
            else
            {
                var rarings = portfolios.First(p => p.Id == portfolioId).Ratings.ToList();
                rarings.Add(rarting);
                portfolios.First(p => p.Id == portfolioId).Ratings = rarings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<Portfolio>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions 
                { 
                    SkipValidation = true, Indented = true 
                }), portfolios);

        }

    }
}
