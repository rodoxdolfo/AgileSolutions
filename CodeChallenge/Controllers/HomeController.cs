using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string[] categories = new string[] { "" , "", ""};
        string[] products = new string[] { "", "", "" };
        string[] brands = new string[] { "", "", "" };
        Category chartData = new Category();

        var viewModel = new HomeViewModel
        {
            Categories = categories,
            Products = products,
            Brands = brands,
            ChartData = (chartData != null && chartData.Products.Count > 0 && chartData.Products.First().Brands.Count > 0) ? chartData.Products.First().Brands.First().Results : null
        };

        return View(viewModel);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

