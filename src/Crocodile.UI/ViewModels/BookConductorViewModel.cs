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
			var bvm = new BookViewModel
				{
				Id = message.ItemId, 
				ArtFilesSource = message.ProjectPath,
				ArtFiles = message.ArtFiles
				};

			if (!message.IsSelected) {
				DeactivateItem(bvm, true);
				ActiveItem = null;
				return;
			}

			ActivateItem(bvm);
		}
	}
}