using System;
namespace CodeChallenge.Models
{
	public class Category
	{
		public string CategoryName {get; set;}
		public List<Product> Products { get; set; }
	}
}

