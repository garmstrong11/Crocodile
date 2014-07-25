namespace Crocodile.UI.ViewModels
{
	using Caliburn.Micro;
	using Infrastructure;

	public class BookConductorViewModel : Conductor<BookViewModel>, IHandle<BookSelectedEvent>
	{
		public BookConductorViewModel(IEventAggregator events)
		{
			events.Subscribe(this);
		}
		
		public void Handle(BookSelectedEvent message)
		{
			UiServices.SetBusyState();

			var bvm = new BookViewModel(message.BookTreeViewItemViewModel);

			if (!message.IsSelected) {
				DeactivateItem(bvm, true);
				ActiveItem = null;
				return;
			}

			ActivateItem(bvm);
		}
	}
}