using System;
using CodeChallengeAPI.Data.Repository;
using CodeChallengeAPI.Data.Model;

namespace CodeChallengeAPI.UseCases
{
	public class SalesResultUseCase
	{
		private ISalesRepository _salesRepository;
        public SalesResultUseCase(ISalesRepository salesRepository)
		{
			_salesRepository = salesRepository;
        }

		public Category? GetSalesResults(string categoryName, string productName, string brandName)
		{
			var categoryResults = _salesRepository.GetSalesReport();
            if (categoryResults != null)
            {
                var result = from cat in categoryResults
                             where cat.CategoryName == categoryName &&
                                   cat.Products.Any(p =>
                                                        p.ProductName == productName &&
                                                        p.Brands.Any(b => b.BrandName == brandName))
                             select cat;

                return result.FirstOrDefault();
            }

            return null;

        }

    }
}

