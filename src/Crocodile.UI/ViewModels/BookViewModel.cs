namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using Caliburn.Micro;
	using Domain;

	public class BookViewModel : Screen
	{
		private int _id;
		private readonly IList<ArtFile> _pdfFiles;
		private readonly IList<ArtFile> _tifFiles;

		public BookViewModel()
		{
			
		}

		public int Id
		{
			get { return _id; }
			set
			{
				if (value == _id) return;
				_id = value;
				NotifyOfPropertyChange();
			}
		}

		public string ArtFilesSource { get; set; }

		public IList<ArtFile> ArtFiles { get; set; } 

		protected override void OnActivate()
		{
			if (_id == 0) return;
			if (string.IsNullOrEmpty(ArtFilesSource)) return;
		}
	}
}