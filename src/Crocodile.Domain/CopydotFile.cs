namespace Crocodile.Domain
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;

	public class CopydotFile
	{
		private readonly List<string> _pathParts;
		private readonly FileInfo _fileInfo;
		public static Regex DescreenedRegex = new Regex( @"descreened" );
		
		public CopydotFile( string path )
		{
			Path = path.Trim();
			_fileInfo = new FileInfo(path);
			_pathParts = path.Split(new[] {'\\'}).ToList();
			_pathParts.RemoveRange(0, 2);
		}

		public string Path { get; set; }

		public string PrinergyJobName
		{
			get { return _pathParts[3]; }
		}

		public string ParentPath
		{
			get { return _fileInfo.DirectoryName; }
		}

		public string ParentName
		{
			get
			{
				return _fileInfo.Directory == null ? string.Empty : _fileInfo.Directory.Name;
			}
		}

		public bool HasDescreenedCousin
		{
			get
			{
				if (_fileInfo.Directory == null) {
					return false;
				}
				if (_fileInfo.Directory.Parent == null) {
					return false; 
				}

				var tifName = _fileInfo.Name.Replace(".PDF", ".TIF");
				var custOrig = _fileInfo.Directory.Parent;
				return custOrig.EnumerateFiles(tifName, SearchOption.AllDirectories).Any();
			}
		}
	}
}