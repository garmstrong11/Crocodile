namespace Crocodile.UI.ViewModels
{
	using System.Linq;
	using Caliburn.Micro;

	public class BookViewModel : Screen
	{
		private readonly BookTreeViewItemViewModel _bookModel;
		private BindableCollection<PageViewModel> _pages;

		public BookViewModel(BookTreeViewItemViewModel bookModel)
		{
			_bookModel = bookModel;
		}

		public int Id
		{
			get { return _bookModel.ItemId; }
		}

		public string ArtFilesSource
		{
			get { return _bookModel.PageSourcePath; }
		}

		public BindableCollection<PageViewModel> Pages
		{
			get { return _pages; }
			set
			{
				if (Equals(value, _pages)) return;
				_pages = value;
				NotifyOfPropertyChange(() => Pages);
			}
		}

		protected override void OnViewLoaded(object view)
		{
			Pages = new BindableCollection<PageViewModel>();

			var pageGroups = _bookModel.ArtFiles
				.GroupBy(f => f.Index)
				.OrderBy(f => f.Key);

			foreach (var pageGroup in pageGroups)
			{
				Pages.Add(new PageViewModel(pageGroup));
			}
			
		}
	}
}