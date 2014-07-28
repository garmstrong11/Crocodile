namespace Crocodile.UI.ViewModels
{
	using System.Linq;
	using Caliburn.Micro;
	using Infrastructure;

	public class BookViewModel : Screen
	{
		private readonly BookTreeViewItemViewModel _bookModel;
		private readonly IProgressViewModel _progressViewModel;
		private readonly IWindowManager _windowManager;

		private BindableCollection<PageViewModel> _pages;

		public BookViewModel(
			IProgressViewModel progressViewModel, 
			IWindowManager windowManager,
			BookTreeViewItemViewModel bookModel)
		{
			_progressViewModel = progressViewModel;
			_windowManager = windowManager;
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

				foreach (var page in Pages) {
					page.PropertyChanged += PageIsSelectedPropertyChanged;
				}
			}
		}

		void PageIsSelectedPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var pg = sender as PageViewModel;
			if (pg == null) return;
			if (e.PropertyName != "IsSelected") return;

			NotifyOfPropertyChange(() => CanSelectAll);
			NotifyOfPropertyChange(() => CanDeselectAll);
		}

		protected override void OnViewLoaded(object view)
		{
			Pages = new BindableCollection<PageViewModel>();

			var pageGroups = _bookModel.ArtFiles
				.GroupBy(f => f.Index)
				.OrderBy(f => f.Key);

			foreach (var pageGroup in pageGroups) {
				var pg = new PageViewModel(pageGroup);
				pg.PropertyChanged += PageIsSelectedPropertyChanged;
				Pages.Add(pg);
			}
		}

		public bool CanDescreen()
		{
			return Pages.Any(p => p.IsSelected);
		}

		public bool CanDeselectAll
		{
			get { return Pages.Any(p => p.IsSelected); }
		}

		public void DeselectAll()
		{
			foreach (var page in Pages) {
				page.IsSelected = false;
			}
		}

		public bool CanSelectAll
		{
			get { return Pages.Any(p => p.IsSelected == false); }
		}

		public void SelectAll()
		{
			foreach (var page in Pages) {
				page.IsSelected = true;
			}
		}

		public void InvertSelection()
		{
			foreach (var page in Pages) {
				page.IsSelected = !page.IsSelected;
			}
		}

		public void Descreen()
		{
			_progressViewModel.Items = Pages.Where(p => p.IsSelected).ToList();

			_windowManager.ShowDialog(_progressViewModel);
		}
	}
}