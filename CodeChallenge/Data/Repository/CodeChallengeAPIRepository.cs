using System;
using System.Net;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Data.Repository
{
	public interface ICodeChallengeAPIRepository {
		public List<string> getCategory();
        public List<string> getProduct(string category);
        public List<string> getBrand(string product);
        public List<MonthResult> getSalesResults(string category, string product, string brand);
    }

    public class CodeChallengeAPIRepository : ICodeChallengeAPIRepository
    {
        private HttpClient client = new HttpClient();

        public CodeChallengeAPIRepository()
		{
            client.BaseAddress = new Uri(@"http://localhost:5194");
        }

        public  List<string> getBrand(string product)
        {
            var response = client.GetFromJsonAsync<List<string>>(@$"Brand?productName={product}");
            response.Wait();
            return response.Result != null ? response.Result : new List<string>();
        }

        public List<string> getCategory()
        {
            var response = client.GetFromJsonAsync<List<string>>(@$"Category");
            response.Wait();
            return response.Result != null ? response.Result : new List<string>();
        }

        public List<string> getProduct(string category)
        {
            var response = client.GetFromJsonAsync<List<string>>(@$"Product?categoryName={category}");
            response.Wait();
            return response.Result != null ? response.Result : new List<string>();
        }

        public List<MonthResult> getSalesResults(string category, string product, string brand)
        {
            //Caso não tem tenha algum valor selecionado não precisa fazer o request
            if (category == null || product == null || brand == null)
                return new List<MonthResult>();

            var response = client.GetFromJsonAsync<List<MonthResult>>(@$"SalesResult?categoryName={category}&productName={product}&brandName={brand}");
            response.Wait();
            return response.Result != null ? response.Result : new List<MonthResult>();
        }
    }
}

