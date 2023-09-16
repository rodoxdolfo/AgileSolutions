using Microsoft.AspNetCore.Mvc;
using CodeChallengeAPI.Data.Model;
using CodeChallengeAPI.Data.Repository;
using CodeChallengeAPI.UseCases;
using Unity;

namespace CodeChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesResultController : ControllerBase
{
    private UnityContainer _IU;

    public SalesResultController()
    {
        _IU = new UnityContainer();
        _IU.RegisterType<SalesResultUseCase>();
        _IU.RegisterType<SalesRepository>();
        _IU.RegisterType < ISalesRepository, SalesRepository>();

    }

 
    [HttpGet]
    public List<MonthResult> Get(string categoryName, string productName, string brandName)
    {
        SalesResultUseCase salesResultUseCase = _IU.Resolve<SalesResultUseCase>();
        return salesResultUseCase.GetSalesResults(categoryName, productName, brandName);
    }
}

