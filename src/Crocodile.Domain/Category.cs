namespace Crocodile.Domain
{
	using System.Text.RegularExpressions;

	public class Category
	{
		public string Name { get; set; }
		public Regex CatRegex { get; set; }
	}
}