using System;
namespace CodeChallengeAPI.Data.Model
{
	public class Category
	{
		public required string CategoryName {get; set;}
		public required List<Product> Products { get; set; }
	}
}

