namespace Crocodile.Domain
{
	using System.IO;
	using System.Text.RegularExpressions;

	public class ArtFile
	{
		private readonly int _index;
		private readonly int _id;
		private readonly string _name;
		private readonly FileInfo _fileInfo;
		private readonly BookType _bookType;
		private readonly ArtFileType _artFileType;

		static readonly Regex ValidRegex = new Regex(@"^(\d+) +(.*)[ -]+[Pp]g? ?0?(\d+).*\.(PDF|TIF)",
			RegexOptions.IgnoreCase | RegexOptions.Compiled);

		static readonly Regex SuffixRegex = new Regex(@"\b(ak|sk|ap)\b", 
			RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public ArtFile(string path)
		{
			_fileInfo = new FileInfo(path);
			var match = ValidRegex.Match(_fileInfo.Name);
			var suffMatch = SuffixRegex.Match(_fileInfo.FullName);

			var idString = match.Groups[1].Value;
			var indexString = match.Groups[3].Value;
			int refInt;

			_id = int.TryParse(idString, out refInt) ? refInt : 0;
			_index = int.TryParse(indexString, out refInt) ? refInt : 0;
			_name = match.Groups[2].Value.ToUpper();
			_bookType = GetBookType(suffMatch.Groups[1].Value);
			_artFileType = GetArtFileType(match.Groups[4].Value);
		}

		public int Id
		{
			get { return _id; }
		}

		public int Index
		{
			get { return _index; }
		}

		public string Name
		{
			get { return _name; }
		}

		public BookType BookType
		{
			get { return _bookType; }
		}

		public ArtFileType ArtFileType
		{
			get { return _artFileType; }
		}

		public string ParentPath 
		{
			get { return _fileInfo.DirectoryName; }
		}

		//public string BookPath { get; set; }

		private static BookType GetBookType(string match)
		{
			switch (match.ToUpper()) {
				case "AK":
					return BookType.AnswerKey;
				case "AP":
					return BookType.ActivityPack;
				case "SK":
					return BookType.ScoreKey;
			}

			return BookType.Pace;
		}

		private static ArtFileType GetArtFileType(string match)
		{
			return match.ToUpper() == "TIF" ? ArtFileType.Tif : ArtFileType.Pdf;
		}
	}
}