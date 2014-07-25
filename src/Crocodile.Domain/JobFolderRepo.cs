namespace Crocodile.Domain
{
	using System.Collections.Generic;
	using System.IO;

	public static class JobFolderRepo
	{
		private static readonly string jobsPath;
		
		static JobFolderRepo()
		{
			jobsPath = Properties.Settings.Default.SourceDir;
			JobFolders = Directory.GetDirectories(jobsPath, "*_cd");
		}

		public static IList<string> JobFolders { get; private set; } 
	}
}