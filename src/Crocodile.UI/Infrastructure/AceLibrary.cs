namespace Crocodile.UI.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text.RegularExpressions;
	using Domain;
	using System.Linq;

	public class AceLibrary
	{
		public IList<Category> Categories { get; set; }

		public AceLibrary()
		{
			Categories = BuildCategoryList();
		}

		public void FindProjects()
		{
			const string pathTrailer1 = @"UserDefinedFolders\Customer Originals";
			const string pathTrailer2 = @"UserDefinedFolders\PartsMaster\Customer Originals\Copydot";
			var sourceDir = Properties.Settings.Default.SourceDir;

			var projectRootDirs = new DirectoryInfo(sourceDir)
				.EnumerateDirectories("*_cd", SearchOption.TopDirectoryOnly)
				.Where(p => !p.Name.StartsWith("COPYDOT", StringComparison.CurrentCultureIgnoreCase))
				.ToList();

			var folders1 = projectRootDirs
			.Select(g => new DirectoryInfo(Path.Combine(g.FullName, pathTrailer1)))
			.Where(g => g.Exists)
			.ToList();

			var folders2 = projectRootDirs
				.Select(g => new DirectoryInfo(Path.Combine(g.FullName, pathTrailer2)))
				.Where(g => g.Exists)
				.ToList();

			var projects = (folders1.Union(folders2))
				.Select(f => new Project(f))
				.ToList();

			var miscCat = new Category {Name = "Misc"};
			Categories.Add(miscCat);

			foreach (var project in projects) {
				var cat = Categories.FirstOrDefault(c => c.CatRegex.IsMatch(project.Name)) ?? miscCat;

				project.Category = cat;
				cat.Projects.Add(project);
			}
		}

		static IList<Category> BuildCategoryList()
		{
			return new List<Category>
			{
			new Category
				{
				Name = "ABC", 
				CatRegex = new Regex(@"^ABC", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Accounting", 
				CatRegex = new Regex(@"^Acc", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Algebra", 
				CatRegex = new Regex(@"^Alg", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Art", 
				CatRegex = new Regex(@"^Art", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Animal Science",
				CatRegex = new Regex(@"^AS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Bible Reading", 
				CatRegex = new Regex(@"^BR", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Business Math",
				CatRegex = new Regex(@"^BUS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Christian Growth",
				CatRegex = new Regex(@"^CHR", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Collectivism", 
				CatRegex = new Regex(@"^COL", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Constitution", 
				CatRegex = new Regex(@"^CON", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Coordination Development",
				CatRegex = new Regex(@"^COO", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "English",
				CatRegex = new Regex(@"^ENG", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "French", 
				CatRegex = new Regex(@"^FRE", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "General Business",
				CatRegex = new Regex(@"^GEN", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Geometry", 
				CatRegex = new Regex(@"^GEO", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Health", 
				CatRegex = new Regex(@"^HEA", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "History of Civilization",
				CatRegex = new Regex(@"^HIS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Intermediate Math",
				CatRegex = new Regex(@"^INTM", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Literature & Creative Writing",
				CatRegex = new Regex(@"^LCW", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Basic Literature",
				CatRegex = new Regex(@"^LIT", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Life of Christ",
				CatRegex = new Regex(@"^LOC", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "College Math",
				CatRegex = new Regex(@"^Math\d+Coll", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Math",
				CatRegex = new Regex(@"^Math(Key|RR)?\d{2}(?!Coll)", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Missions", 
				CatRegex = new Regex(@"^MIS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Music", 
				CatRegex = new Regex(@"^MUS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "New Testament", 
				CatRegex = new Regex(@"^NT", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Old Testament", 
				CatRegex = new Regex(@"^OT", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Physical Science",
				CatRegex = new Regex(@"^PHY", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Science", 
				CatRegex = new Regex(@"^SCI", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Spanish", 
				CatRegex = new Regex(@"^SPA", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Speech", 
				CatRegex = new Regex(@"^SPE", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Social Studies",
				CatRegex = new Regex(@"^SS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Typing", 
				CatRegex = new Regex(@"^Typ", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Videophonics",
				CatRegex = new Regex(@"^Vid", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new Category
				{
				Name = "Word Building", 
				CatRegex = new Regex(@"^WB", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				}
			};
		} 
	}
}