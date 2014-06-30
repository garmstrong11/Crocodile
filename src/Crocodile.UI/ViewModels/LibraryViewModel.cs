namespace Crocodile.UI.ViewModels
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Caliburn.Micro;

	public class LibraryViewModel : CrocScreen 
	{
		public LibraryViewModel()
		{
			BuildCategoryList();
			FindProjects();
		}
		
		public BindableCollection<CategoryViewModel> Categories { get; set; }

		private static BindableCollection<CategoryViewModel> BuildCategoryList()
		{
			return new BindableCollection<CategoryViewModel>
			{
			new CategoryViewModel
				{
				Name = "ABC", 
				CatRegex = new Regex(@"^ABC", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Accounting", 
				CatRegex = new Regex(@"^Acc", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Algebra", 
				CatRegex = new Regex(@"^Alg", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Art", 
				CatRegex = new Regex(@"^Art", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Animal Science",
				CatRegex = new Regex(@"^AS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Bible Reading", 
				CatRegex = new Regex(@"^BR", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Business Math",
				CatRegex = new Regex(@"^BUS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Christian Growth",
				CatRegex = new Regex(@"^CHR", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Collectivism", 
				CatRegex = new Regex(@"^COL", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Constitution", 
				CatRegex = new Regex(@"^CON", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Coordination Development",
				CatRegex = new Regex(@"^COO", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "English",
				CatRegex = new Regex(@"^ENG", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "French", 
				CatRegex = new Regex(@"^FRE", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "General Business",
				CatRegex = new Regex(@"^GEN", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Geometry", 
				CatRegex = new Regex(@"^GEO", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Health", 
				CatRegex = new Regex(@"^HEA", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "History of Civilization",
				CatRegex = new Regex(@"^HIS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Intermediate Math",
				CatRegex = new Regex(@"^INTM", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Literature & Creative Writing",
				CatRegex = new Regex(@"^LCW", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Basic Literature",
				CatRegex = new Regex(@"^LIT", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Life of Christ",
				CatRegex = new Regex(@"^LOC", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "College Math",
				CatRegex = new Regex(@"^Math\d+Coll", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Math",
				CatRegex = new Regex(@"^Math(Key|RR)?\d{2}(?!Coll)", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Missions", 
				CatRegex = new Regex(@"^MIS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Music", 
				CatRegex = new Regex(@"^MUS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "New Testament", 
				CatRegex = new Regex(@"^NT", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Old Testament", 
				CatRegex = new Regex(@"^OT", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Physical Science",
				CatRegex = new Regex(@"^PHY", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Science", 
				CatRegex = new Regex(@"^SCI", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Spanish", 
				CatRegex = new Regex(@"^SPA", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Speech", 
				CatRegex = new Regex(@"^SPE", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Social Studies",
				CatRegex = new Regex(@"^SS", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Typing", 
				CatRegex = new Regex(@"^Typ", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Videophonics",
				CatRegex = new Regex(@"^Vid", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				},
			new CategoryViewModel
				{
				Name = "Word Building", 
				CatRegex = new Regex(@"^WB", RegexOptions.Compiled | RegexOptions.IgnoreCase)
				}
			};
		}

		private void FindProjects()
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
				.Select(f => new ProjectViewModel(f))
				.ToList();

			var miscCat = new CategoryViewModel { Name = "Misc" };
			Categories.Add(miscCat);

			foreach (var project in projects)
			{
				var cat = Categories.FirstOrDefault(c => c.CatRegex.IsMatch(project.Name)) ?? miscCat;

				project.Category = cat;
				cat.Projects.Add(project);
			}
		}
	}
}