namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Domain;

	public class ProjectViewModel : TreeViewItemViewModel
	{
		static readonly Regex ValidRegex = new Regex(@"^(\d+) +(.*)[ -]+[Pp]g? ?0?(\d+).*\.(PDF|TIF)",
			RegexOptions.IgnoreCase | RegexOptions.Compiled);

		private readonly string _name;
		private readonly string _path;

		public ProjectViewModel(string path, TreeViewItemViewModel parent)
			: base(parent)
		{
			_path = path;
			_name = _path.Split(new[] {'\\'})[5].Replace("_cd", "");
		}

		public string Name
		{
			get { return _name; }
		}

		//public string ProjectPath
		//{
		//	get { return _path; }
		//}

		public string ArtFilesSourcePath
		{
			get
			{
				const string pathTrailer1 = @"UserDefinedFolders\Customer Originals";
				const string pathTrailer2 = @"UserDefinedFolders\PartsMaster\Customer Originals";

				return new[]
					{
					Path.Combine(_path, pathTrailer1),
					Path.Combine(_path, pathTrailer2)
					}
					.FirstOrDefault(Directory.Exists) ?? _path;
			}
		}

		protected override void LoadChildren()
		{
			var artFiles = Directory.GetFiles(ArtFilesSourcePath, "*.*", SearchOption.AllDirectories)
				.Where(n => ValidRegex.IsMatch(Path.GetFileName(n) ?? ""))
				.Select(n => new ArtFile(n))
				.ToList();

			//var books = Directory.GetFiles(ArtFilesSourcePath, "*.*", SearchOption.AllDirectories)
			//	.Where(n => ValidRegex.IsMatch(Path.GetFileName(n) ?? ""))
			//	.Select(n => new ArtFile(n))
			//	.GroupBy(f => new { ItemId = f.Id, f.BookType, f.Name });

			// Find all the pdf files under the paths, and group them by ID, BookType, and Name.
			// This complex key will allow us to use the key to populate and sort the books in one step.
			var books = artFiles.GroupBy(f => new {ItemId = f.Id, f.BookType, f.Name});

			var sortedBooks = books
				.Select(v => new BookTreeViewItemViewModel(this)
					{ BookType = v.Key.BookType, 
						Name = v.Key.Name, 
						ItemId = v.Key.ItemId,
						PageSourcePath = ArtFilesSourcePath,
						ArtFiles = new List<ArtFile>(artFiles.Where(f => f.Id == v.Key.ItemId).ToList())
					})
				.OrderBy(v => v.BookType);

			foreach (var bookViewModel in sortedBooks) {
				Children.Add(bookViewModel);
			}
		}

		public void OpenProjectFolder()
		{
			Process.Start(ArtFilesSourcePath);
		}
	}
}