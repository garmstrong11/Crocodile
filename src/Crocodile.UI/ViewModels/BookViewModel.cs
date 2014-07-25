namespace Crocodile.UI.ViewModels
{
	using System.Linq;
	using Caliburn.Micro;

	public class BookViewModel : Screen
	{
		private readonly BookTreeViewItemViewModel _bookModel;

		public BookViewModel(BookTreeViewItemViewModel bookModel)
		{
			_bookModel = bookModel;
			Pages = new BindableCollection<PageViewModel>();

			var pageGroups = _bookModel.ArtFiles
				.GroupBy(f => f.Index)
				.OrderBy(f => f.Key);

			foreach (var pageGroup in pageGroups) {
				Pages.Add(new PageViewModel(pageGroup));
			}
		}

		public int Id
		{
			get { return _bookModel.ItemId; }
		}

		public string ArtFilesSource
		{
			get { return _bookModel.PageSourcePath; }
		}

		public BindableCollection<PageViewModel> Pages { get; private set; }

		protected override void OnActivate()
		{
		}
	}
}