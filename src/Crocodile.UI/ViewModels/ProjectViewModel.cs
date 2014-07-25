namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Domain;
	using Infrastructure;

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
			UiServices.SetBusyState();
			
			var bookLookup = Directory
				.GetFiles(ArtFilesSourcePath, "*.*", SearchOption.AllDirectories)
				.Where(n => ValidRegex.IsMatch(Path.GetFileName(n) ?? ""))
				.Select(n => new ArtFile(n))
				.ToLookup(k => new { k.Id, k.BookType, k.Name });

			var books = bookLookup
				.Select(v => new BookTreeViewItemViewModel(this)
					{ BookType = v.Key.BookType, 
						Name = v.Key.Name, 
						ItemId = v.Key.Id,
						PageSourcePath = ArtFilesSourcePath,
						ArtFiles = bookLookup[v.Key].ToList()
					})
				.OrderBy(v => v.BookType);

			foreach (var bookViewModel in books) {
				var firstPdf = bookViewModel.ArtFiles.FirstOrDefault(b => b.ArtFileType == ArtFileType.Pdf);
				if (firstPdf != null) bookViewModel.PageSourcePath = firstPdf.ParentPath;

				Children.Add(bookViewModel);
			}
		}

		public void OpenProjectFolder()
		{
			Process.Start(ArtFilesSourcePath);
		}
	}
}