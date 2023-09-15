using System;
namespace CodeChallengeAPI.Data.Model
{
	public class Product
	{
		public required string ProductName { get; set; }
		public required List<Brand> Brands { get; set; }
	}
}

