using System;
namespace CodeChallengeAPI.Data.Model
{
	public class Brand
	{
		public required string BrandName { get; set; }
		public required List<MonthResult>  Results {get; set;}
	}
}

