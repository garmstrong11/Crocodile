namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Caliburn.Micro;
	using Properties;

	public class ProgressViewModel : Screen, IProgressViewModel
	{
		private int _progress;
		private string _currentFilename;

		public ProgressViewModel()
		{
			Progress = 0;
		}

		protected override void OnActivate()
		{
			DisplayName = "Progress";
			ProcessFilesAsync();
			Progress = 0;
		}

		public int Progress
		{
			get { return _progress; }
			private set
			{
				if (value == _progress) return;
				_progress = value;
				NotifyOfPropertyChange();
			}
		}

		public string CurrentFilename
		{
			get { return _currentFilename; }
			private set
			{
				if (value == _currentFilename) return;
				_currentFilename = value;
				NotifyOfPropertyChange();
			}
		}

		public int FileCount
		{
			get { return Items.Count(); }
		}

		public IEnumerable<PageViewModel> Items { get; set; }


		public async void ProcessFilesAsync()
		{
			var prinergyPath = Settings.Default.PrinergyHotFolderPath;

			foreach (var info in Items.Select(page => page.PdfArtFile.FileInfo)) {
				CurrentFilename = info.Name;
				var outPath = Path.Combine(prinergyPath, CurrentFilename);

				using (var inStream = new FileStream(info.FullName, FileMode.Open)) {
					using (var outStream = new FileStream(outPath, FileMode.Create)) {
						await inStream.CopyToAsync(outStream);
					}
				}

				Progress += 1;
			}

			TryClose();
		}
	}
}