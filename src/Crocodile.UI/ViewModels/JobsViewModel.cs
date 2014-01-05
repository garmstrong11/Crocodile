namespace Crocodile.UI.ViewModels
{
	using System.Collections.ObjectModel;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text.RegularExpressions;
	using Caliburn.Micro;
	using Domain;

	public class JobsViewModel : Screen
	{
		private ObservableCollection<Job> _jobs;
		private bool _isBusy;
		private Job _selectedJob;

		public JobsViewModel()
		{
			Jobs = LoadJobs();
			DisplayName = "File Chooser";
		}

		public ObservableCollection<Job> Jobs
		{
			get { return _jobs; }
			set
			{
				if (Equals(value, _jobs)) return;
				_jobs = value;
				NotifyOfPropertyChange();
			}
		}

		public Job SelectedJob
		{
			get { return _selectedJob; }
			set
			{
				if (Equals(value, _selectedJob)) return;
				_selectedJob = value;
				NotifyOfPropertyChange();
			}
		}

		public ObservableCollection<string> JobFiles { get; set; }

		public void RefreshProjects()
		{
			
		}

		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				if (value.Equals(_isBusy)) return;
				_isBusy = value;
				NotifyOfPropertyChange();
			}
		}

		//public void GetPages(string path)
		//{
		//	var pdfFiles = Directory.EnumerateFiles(path, "*.pdf", SearchOption.AllDirectories)
		//		.Where(g => Regex.IsMatch(Path.GetFileNameWithoutExtension(g) ?? "", @" pg?\d\d"))
		//		.ToArray();
		//	JobFiles = new ObservableCollection<string>(pdfFiles);
		//}


		private static ObservableCollection<Job> LoadJobs()
		{
			var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

			if (assemblyPath == null)
			{
				throw new FileNotFoundException("Unable to find Template path");
			}

			assemblyPath = assemblyPath.Replace(@"file:\", "");

			var appRoot = Path.Combine(assemblyPath, "..", "..");
			var templatePath = Path.Combine(appRoot, @"ViewModels\JobFolders.txt");

			if (!File.Exists(templatePath))
			{
				throw new FileNotFoundException("Unable to find Excel report template");
			}

			var jobs = File.ReadAllLines(templatePath)
				.Select(j => new Job(j));

			return new ObservableCollection<Job>(jobs);
		}
	}
}