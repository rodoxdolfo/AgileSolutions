using System;
using CodeChallengeAPI.Data.Repository;
using CodeChallengeAPI.UseCases;
using Microsoft.AspNetCore.Mvc;
using Unity;

namespace CodeChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController
	{
        private UnityContainer _IU;

        public BrandController()
        {
            _IU = new UnityContainer();
            _IU.RegisterType<DomainUseCase>();
            _IU.RegisterType<SalesRepository>();
            _IU.RegisterType<ISalesRepository, SalesRepository>();

        }


        [HttpGet]
        public List<string> Get(string productName)
        {
            DomainUseCase domainUseCase = _IU.Resolve<DomainUseCase>();
            return domainUseCase.GetBrands(productName);
        }
    }
}

