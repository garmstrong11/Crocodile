namespace Crocodile.CleanupConsole
{
	using System.IO;
	using System.Text.RegularExpressions;
	using System.Linq;

	class Program
	{
		static void Main(string[] args)
		{
			const string lookupFilePath = @"F:\ACE\Copydot\ProjectFolders.txt";
			const string binPath = @"\\SAN\AraxiVolume_Hort\Jobs\ACE_ScannedBooks_New\BIN";
			const string cleanerPattern = @"(.+pg?\d+).p1.1A(\.K)?";

			var folderLookup = File.ReadAllLines(lookupFilePath)
				.Select(f =>
				{
					var split = f.Split(new[] { '\t' });
					return new { ItemId = split[0], Path = split[1] };
				})
				.ToDictionary(k => k.ItemId, v => v.Path);

			var binDirInfo = new DirectoryInfo(binPath);
			var fileInfos = binDirInfo.EnumerateFiles("*.TIF");

			foreach (var fileInfo in fileInfos)
			{
				var itemId = fileInfo.Name.Split(new[] { ' ' })[0];
				var pdfPath = folderLookup[itemId];

				//Remove Prinergy characters from file name:
				var destName = Regex.Replace(fileInfo.Name, cleanerPattern, "$1");

				var destDir = pdfPath + " Descreened";

				if (!Directory.Exists(destDir)) {
					Directory.CreateDirectory(destDir);
				}

				var destPath = Path.Combine(destDir, destName);

				fileInfo.MoveTo(destPath);
			}
		}
	}
}
