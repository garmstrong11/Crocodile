namespace Crocodile.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Properties;

	public class Job
	{
		private readonly string _path;
		private const int ProjectRootDepth = 3;

		public Job()
		{
			_path = String.Empty;
		}

		public Job(string path)
		{
			_path = path;
		}

		public string JobPath
		{
			get { return _path; }
		}

		public string Name
		{
			get { 
				var dirs = _path.Substring(2).Split(new[] {'\\'});
				return dirs[ProjectRootDepth];
			}
		}

		public ObservableCollection<string> Pages
		{
			get
			{
				var files = Directory.EnumerateFiles(JobPath, "*.pdf", SearchOption.AllDirectories)
					.Where(g => Regex.IsMatch(Path.GetFileNameWithoutExtension(g) ?? "", @" pg?\d\d"))
					.Select(Path.GetFileName)
					.OrderBy(g => g)
					.ToList();
				return new ObservableCollection<string>(files);
			}
		} 

		public static IEnumerable<string> GetJobPaths()
		{
			var pathHeader = Settings.Default.SourceDir;
			const string pathTrailer1 = @"UserDefinedFolders\Customer Originals";
			const string pathTrailer2 = @"UserDefinedFolders\PartsMaster\Customer Originals\Copydot";

			var topFolders = Directory
				.GetDirectories(pathHeader, "*.*", SearchOption.TopDirectoryOnly)
				.ToList();

			var folders1 = topFolders
				.Select(g => Path.Combine(g, pathTrailer1))
				.Where(Directory.Exists);

			var folders2 = topFolders
				.Select(g => Path.Combine(g, pathTrailer2))
				.Where(Directory.Exists);

			var folders = folders1.Union(folders2).OrderBy(p => p);

			return folders
				.Where(d => Directory.EnumerateFiles(d, "*.pdf", SearchOption.AllDirectories)
					.Any(g => Regex.IsMatch(Path.GetFileNameWithoutExtension(g) ?? "", @" pg?\d\d")))
				.ToList();
		} 
	}
}