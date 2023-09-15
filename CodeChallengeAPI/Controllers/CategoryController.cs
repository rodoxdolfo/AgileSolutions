using System;
using CodeChallengeAPI.Data.Repository;
using CodeChallengeAPI.UseCases;
using Microsoft.AspNetCore.Mvc;
using Unity;

namespace CodeChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController
	{
        private UnityContainer _IU;

        public CategoryController()
        { 
            _IU = new UnityContainer();
            _IU.RegisterType<DomainUseCase>();
            _IU.RegisterType<SalesRepository>();
            _IU.RegisterType<ISalesRepository, SalesRepository>();

        }


        [HttpGet]
        public List<string> Get()
        {
            DomainUseCase domainUseCase = _IU.Resolve<DomainUseCase>();
            return domainUseCase.GetCategories();
        }
    }
}

