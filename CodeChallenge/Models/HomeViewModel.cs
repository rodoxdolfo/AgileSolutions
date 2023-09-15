using System;
namespace CodeChallenge.Models
{
    public class HomeViewModel
    {
        public string[] Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string[] Products { get; set; }
        public string SelectedProduct { get; set; }
        public string[] Brands { get; set; }
        public string SelectedBrand { get; set; }
        public List<MonthResult> ChartData { get; set; }

    }
}

