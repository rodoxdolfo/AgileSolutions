using CodeChallengeAPI.Controllers;
using CodeChallengeAPI.Data.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodeChallengeAPI.Data.Repository
{
    public interface ISalesRepository
    {
        public List<Category>? GetSalesReport();
    }

    public class SalesRepository : ISalesRepository
    {
        public List<Category>? GetSalesReport()
        {
                //Estou usando um json para representar o banco de dados para focar na implementação de backend
                //mas aqui poderia estar o codigo de acesso ao banco
                using (StreamReader r = new StreamReader(@"Data/DataSource/JsonDataBase.json"))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Category>>(json);

                }
        }
    }
}

