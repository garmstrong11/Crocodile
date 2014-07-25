namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.Linq;
	using Caliburn.Micro;
	using Domain;

	public class PageViewModel : PropertyChangedBase
	{
		private bool _isSelected;

		public PageViewModel(IEnumerable<ArtFile> artfiles)
		{
			var files = artfiles.ToList();
			PdfArtFile = files.FirstOrDefault(f => f.ArtFileType == ArtFileType.Pdf);
			TifArtFile = files.FirstOrDefault(f => f.ArtFileType == ArtFileType.Tif);
			IsSelected = TifArtFile == null;
		}
		
		public ArtFile PdfArtFile { get; private set; }
		public ArtFile TifArtFile { get; set; }

		public string PdfFileName
		{
			get
			{
				return PdfArtFile == null ? string.Empty : PdfArtFile.FileInfo.Name;
			}
		}

		public string TifFileName
		{
			get { return TifArtFile != null ? TifArtFile.FileInfo.Name : string.Empty; }
		}

		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				if (value.Equals(_isSelected)) return;
				_isSelected = value;
				NotifyOfPropertyChange();
			}
		}
	}
}