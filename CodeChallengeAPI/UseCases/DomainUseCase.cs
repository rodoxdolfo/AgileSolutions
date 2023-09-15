using System;
using CodeChallengeAPI.Data.Repository;

namespace CodeChallengeAPI.UseCases
{
	public class DomainUseCase
	{
        private ISalesRepository _salesRepository;
        public DomainUseCase(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public List<string> GetCategories()
        {
            var categoryResults = _salesRepository.GetSalesReport();
            if (categoryResults != null)
            {
                var result = from cat in categoryResults
                             select cat.CategoryName;

                return result.ToList();
            }

            return new List<string>();
        }
        public List<string>? GetProducts(string category)
        {
            {
                var categoryResults = _salesRepository.GetSalesReport();
                if (categoryResults != null)
                {
                    var result = from cat in categoryResults
                                 from prod in cat.Products
                                 where cat.CategoryName == category
                                 select prod.ProductName;

                    return result.ToList();
                }

                return new List<string>();
            }
        }
        public List<string>? GetBrands(string product)
        {
            {
                var categoryResults = _salesRepository.GetSalesReport();
                if (categoryResults != null)
                {
                    var result = from cat in categoryResults
                                 from prod in cat.Products
                                 from bra in prod.Brands
                                 where prod.ProductName == product
                                 select bra.BrandName;

                    return result.ToList();
                }

                return new List<string>();
            }
        }
    }
}

