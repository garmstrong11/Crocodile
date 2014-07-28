namespace Crocodile.UI.ViewModels
{
	using Caliburn.Micro;
	using Infrastructure;

	public class BookConductorViewModel : Conductor<BookViewModel>, IHandle<BookSelectedEvent>
	{
		private readonly IProgressViewModel _progressViewModel;
		private readonly IWindowManager _windowManager;
		
		public BookConductorViewModel(
			IEventAggregator events, 
			IProgressViewModel progressViewModel, 
			IWindowManager windowManager)
		{
			events.Subscribe(this);
			_progressViewModel = progressViewModel;
			_windowManager = windowManager;
		}
		
		public void Handle(BookSelectedEvent message)
		{
			UiServices.SetBusyState();

			var bvm = new BookViewModel(_progressViewModel, _windowManager, message.BookTreeViewItemViewModel);

			if (!message.IsSelected) {
				DeactivateItem(bvm, true);
				ActiveItem = null;
				return;
			}

			ActivateItem(bvm);
		}
	}
}