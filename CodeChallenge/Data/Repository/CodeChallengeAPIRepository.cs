using System;
using System.Net;

namespace CodeChallenge.Data.Repository
{
	public interface ICodeChallengeAPIRepository {
		public List<string> getCategory();
        public List<string> getProduct(string category);
        public List<string> getBrand(string product);
        public List<string> getSalesResults(string category, string product, string brand);
    }

    public class CodeChallengeAPIRepository : ICodeChallengeAPIRepository
    {
        private HttpClient client = new HttpClient();

        public CodeChallengeAPIRepository()
		{
            client.BaseAddress = new Uri(@"http://localhost:5194");
        }

        public List<string> getBrand(string product)
        {
            throw new NotImplementedException();
        }

        public List<string> getCategory()
        {
            throw new NotImplementedException();
        }

        public List<string> getProduct(string category)
        {
            throw new NotImplementedException();
        }

        public List<string> getSalesResults(string category, string product, string brand)
        {
            throw new NotImplementedException();
        }
    }
}

