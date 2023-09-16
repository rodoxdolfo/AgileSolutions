using CodeChallenge.Data.Model;
using CodeChallenge.Data.Repository;

namespace CodeChallenge.UseCase
{
	public class CodeChallengeAPIUseCase
	{
        private ICodeChallengeAPIRepository _codeChallengeAPIRepository;
        public CodeChallengeAPIUseCase(ICodeChallengeAPIRepository codeChallengeAPIRepository)
        {
            _codeChallengeAPIRepository = codeChallengeAPIRepository;
        }

        public List<string> getBrand(string product)
        {
            return _codeChallengeAPIRepository.getBrand(product);
        }

        public List<string> getCategory()
        {
            return _codeChallengeAPIRepository.getCategory();
        }

        public List<string> getProduct(string category)
        {
            return _codeChallengeAPIRepository.getProduct(category);
        }

        public List<MonthResult> getSalesResults(string category, string product, string brand)
        {
            return _codeChallengeAPIRepository.getSalesResults(category, product, brand);
        }
    }
}

