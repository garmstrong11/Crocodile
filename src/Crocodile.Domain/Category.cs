namespace Crocodile.Domain
{
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	public class Category
	{
		public Category()
		{
			Projects = new List<Project>();
		}
		
		public string Name { get; set; }
		public Regex CatRegex { get; set; }
		public IList<Project> Projects { get; set; }
	}
}