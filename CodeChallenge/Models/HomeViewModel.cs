using System;
namespace CodeChallenge.Models
{
    public class HomeViewModel
    {
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public List<string> Products { get; set; }
        public string SelectedProduct { get; set; }
        public List<string> Brands { get; set; }
        public string SelectedBrand { get; set; }
        public List<Data.Model.MonthResult> ChartData { get; set; }

    }
}

