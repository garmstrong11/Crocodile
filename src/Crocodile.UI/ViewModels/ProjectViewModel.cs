namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Domain;

	public class ProjectViewModel : TreeViewItemViewModel
	{
		private static readonly string pathTrailer1 = @"UserDefinedFolders\Customer Originals";
		private static readonly string pathTrailer2 = @"UserDefinedFolders\PartsMaster\Customer Originals";

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

		protected override void LoadChildren()
		{
			IEnumerable<string> paths = new[]
				{
				Path.Combine(_path, pathTrailer1),
				Path.Combine(_path, pathTrailer2)
				};

			var searchPaths = paths.Where(Directory.Exists);

			// Find all the art files under the paths, and group them by ID, BookType, and Name.
			// This complex key will allow us to use the key to populate and sort the books in one step.
			var books = searchPaths
				.SelectMany(f => Directory.GetFiles(f, "*.*", SearchOption.AllDirectories))
				.Where(n => ValidRegex.IsMatch(Path.GetFileName(n)))
				.Select(n => new ArtFile(n))
				.GroupBy(f => new {ItemId = f.Id, f.BookType, f.Name});

			var sortedBooks = books
				.Select(v => new BookViewModel(this)
					{ BookType = v.Key.BookType, Name = v.Key.Name, ItemId = v.Key.ItemId })
				.OrderBy(v => v.BookType);

			foreach (var bookViewModel in sortedBooks) {
				Children.Add(bookViewModel);
			}

			//foreach (var book in books) {
			//	var firstArtFile = book.First();
			//	var vm = new BookViewModel(this)
			//		{
			//		BookType = firstArtFile.BookType,
			//		ItemId = firstArtFile.Id,
			//		Name = firstArtFile.Name
			//		};
			//	Children.Add(vm);
			//}

		}
	}
}