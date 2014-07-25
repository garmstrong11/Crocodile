namespace Crocodile.UI.ViewModels
{
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Domain;

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

		protected async override void LoadChildren()
		{
			Cursor = Cursors.Wait;

			await GetProjectDirectories();

			Cursor = Cursors.Arrow;
		}

		private async Task GetProjectDirectories()
		{
			await Task.Run(() => {
				var projectDirs = JobFolderRepo.JobFolders
					.Where(d => _catRegex.IsMatch(Path.GetFileName(d) ?? ""))
					.OrderBy(Path.GetFileName)
					.ToList();

				foreach (var projectDir in projectDirs) {
					string dir = projectDir;
					Caliburn.Micro.Execute.OnUIThread(() => Children.Add(new ProjectViewModel(dir, this)));
				}
			});
		}
	}
}