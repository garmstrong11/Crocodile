namespace Crocodile.UI.Infrastructure
{
	using ViewModels;

	public class BookSelectedEvent
	{
		public BookSelectedEvent(BookTreeViewItemViewModel viewModel)
		{
			BookTreeViewItemViewModel = viewModel;
		}

		public BookTreeViewItemViewModel BookTreeViewItemViewModel { get; private set; }
		public bool IsSelected { get; set; }
	}
}