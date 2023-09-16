using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;
using CodeChallenge.Data.Model;
using CodeChallenge.UseCase;
using CodeChallenge.Data.Repository;
using Unity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeChallenge.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private CodeChallengeAPIUseCase codeChallengeAPIUseCase;
    private HomeViewModel viewModel;
    private UnityContainer _IU;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _IU = new UnityContainer();
        _IU.RegisterType<CodeChallengeAPIUseCase>();
        _IU.RegisterType<CodeChallengeAPIRepository>();
        _IU.RegisterType<ICodeChallengeAPIRepository, CodeChallengeAPIRepository>();
    }

    public IActionResult Index()
    {
        codeChallengeAPIUseCase = _IU.Resolve<CodeChallengeAPIUseCase>();

        List<string> categories = codeChallengeAPIUseCase.getCategory();
        List<string> products = codeChallengeAPIUseCase.getProduct(categories.First());
        List<string> brands = codeChallengeAPIUseCase.getBrand(products.First());
        List<MonthResult> chartData = codeChallengeAPIUseCase.getSalesResults(categories.First(), products.First(), brands.First());

        viewModel = new HomeViewModel
        {
            Categories = categories,
            SelectedCategory = categories.First(),
            Products = products,
            SelectedProduct = products.First(),
            Brands = brands,
            SelectedBrand = brands.First(),
            ChartData = chartData
        };

        return View(viewModel);

    }

    [HttpGet]
    public ActionResult GetProductsByCategory(string categoryName)
    {
        codeChallengeAPIUseCase = _IU.Resolve<CodeChallengeAPIUseCase>();
        return Json(codeChallengeAPIUseCase.getProduct(categoryName));
    }

    [HttpGet]
    public ActionResult GetBrandsByProduct(string productName)
    {
        codeChallengeAPIUseCase = _IU.Resolve<CodeChallengeAPIUseCase>();
        return Json(codeChallengeAPIUseCase.getBrand(productName));
    }

    [HttpGet]
    public ActionResult getSalesResults(string categoryName, string productName, string brandName)
    {
        codeChallengeAPIUseCase = _IU.Resolve<CodeChallengeAPIUseCase>();
        return Json(codeChallengeAPIUseCase.getSalesResults(categoryName, productName, brandName));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

