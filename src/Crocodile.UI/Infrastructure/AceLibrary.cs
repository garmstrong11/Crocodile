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
			//Categories = BuildCategoryList();
		}

		//public void FindProjects()
		//{
		//	const string pathTrailer1 = @"UserDefinedFolders\Customer Originals";
		//	const string pathTrailer2 = @"UserDefinedFolders\PartsMaster\Customer Originals\Copydot";
		//	var sourceDir = Properties.Settings.Default.SourceDir;

		//	var projectRootDirs = new DirectoryInfo(sourceDir)
		//		.EnumerateDirectories("*_cd", SearchOption.TopDirectoryOnly)
		//		.Where(p => !p.Name.StartsWith("COPYDOT", StringComparison.CurrentCultureIgnoreCase))
		//		.ToList();

		//	var folders1 = projectRootDirs
		//	.Select(g => new DirectoryInfo(Path.Combine(g.FullName, pathTrailer1)))
		//	.Where(g => g.Exists)
		//	.ToList();

		//	var folders2 = projectRootDirs
		//		.Select(g => new DirectoryInfo(Path.Combine(g.FullName, pathTrailer2)))
		//		.Where(g => g.Exists)
		//		.ToList();

		//	var projects = (folders1.Union(folders2))
		//		.Select(f => new Project(f))
		//		.ToList();

		//	var miscCat = new Category {Name = "Misc"};
		//	Categories.Add(miscCat);

		//	foreach (var project in projects) {
		//		var cat = Categories.FirstOrDefault(c => c.CatRegex.IsMatch(project.Name)) ?? miscCat;

		//		project.Category = cat;
		//		cat.Projects.Add(project);
		//	}
		//}
	}
}