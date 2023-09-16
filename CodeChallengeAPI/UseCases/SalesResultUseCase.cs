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

		public List<MonthResult> GetSalesResults(string categoryName, string productName, string brandName)
		{
			var categoryResults = _salesRepository.GetSalesReport();
            if (categoryResults != null)
            {
                var result = from cat in categoryResults
                             from prod in cat.Products
                             from bar in prod.Brands
                             from res in bar.Results
                             where cat.CategoryName == categoryName &&
                                   prod.ProductName == productName &&
                                   bar.BrandName == brandName
                             select res;

                return result.ToList();
            }

            return new List<MonthResult>();

        }

    }
}

