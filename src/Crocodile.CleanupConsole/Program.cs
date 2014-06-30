namespace Crocodile.CleanupConsole
{
	using System;
	using System.IO;
	using System.Text.RegularExpressions;
	using System.Linq;

	class Program
	{
		static void Main(string[] args)
		{
			const string allPdfFilesPath = @"F:\ACE\Copydot\AllPdfFiles.txt";
			const string binPath = @"\\SAN\AraxiVolume_Hort\Jobs\ACE_ScannedBooks_New\BIN";
			const string cleanerPattern = @"(.+pg?\d+.*).p1.1A(\.[KMCY1P])?";
			var date = DateTime.Now;
			var logFileName = string.Format("copydot_log_{0}.txt", date.ToString("yyyy-MM-dd hh-mm tt"));
			var logFilePath = Path.Combine(binPath, logFileName);

			var folderLookup = File.ReadAllLines(allPdfFilesPath)
				.Select(f => new
					{
					Key = Path.GetFileNameWithoutExtension(f),
					Dir = Path.GetDirectoryName(f)
					})
				.ToLookup(k => k.Key, v => v.Dir);

			var binDirInfo = new DirectoryInfo(binPath);
			var fileInfos = binDirInfo.EnumerateFiles("*.TIF").ToList();
			var fileCount = fileInfos.Count();
			var iteration = 1;

			using (var logFile = File.CreateText(logFilePath)) {

				foreach (var fileInfo in fileInfos) {
					var destName = Regex.Replace(fileInfo.Name, cleanerPattern, "$1");
					var key = destName.Replace(".TIF", "");
					string outString;

					var found = folderLookup[key].ToList();

					// Continue if ambiguous lookup result:
					if (found.Count() > 1) {
						outString = string.Format("File {0} ({1} of {2}) has multiple lookup matches; Skipping the file.",
							fileInfo.Name, iteration, fileCount);
						logFile.WriteLine(outString);
						Console.WriteLine(outString);

						continue;
					}
					var pdfPath = found.FirstOrDefault();

					// Continue if lookup fails.
					if (pdfPath == null) {
						outString = string.Format("File {0} ({1} of {2}) has no lookup matches; Skipping the file.",
							fileInfo.Name, iteration, fileCount);
						logFile.WriteLine(outString);
						Console.WriteLine(outString);

						continue;
					}

					var destDir = pdfPath + " Descreened";

					if (!Directory.Exists(destDir)) {
						Directory.CreateDirectory(destDir);
					}

					var destPath = Path.Combine(destDir, destName);

					outString = string.Format("Moving {0}, ({1} of {2}) to {3}", fileInfo.Name, iteration, fileCount, destPath);
					Console.Write(outString);
					logFile.WriteLine(outString);

					fileInfo.MoveTo(destPath);

					Console.WriteLine(" done");
					iteration++;
				}
			}

			Console.WriteLine("\nFinished. Press any key to exit...");
			Console.ReadLine();
		}
	}
}
