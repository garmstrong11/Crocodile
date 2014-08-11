namespace Crocodile.UI.ViewModels
{
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Infrastructure;

	public class CategoryViewModel : TreeViewItemViewModel
	{
		private readonly string _name;
		private readonly Regex _catRegex;

		public CategoryViewModel(string name, string regex)
			: base(null)
		{
			_name = name;
			_catRegex = new Regex(regex, RegexOptions.IgnoreCase);
		}

		public string Name
		{
			get { return _name; }
		}

		protected override void LoadChildren()
		{
			UiServices.SetBusyState();

			var projectDirs = JobFolderRepo.JobFolders
					.Where(d => _catRegex.IsMatch(Path.GetFileName(d) ?? ""))
					.OrderBy(Path.GetFileName)
					.ToList();

			foreach (var projectDir in projectDirs)
			{
				Children.Add(new ProjectViewModel(projectDir, this));
			}
		}
	}
}