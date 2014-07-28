namespace Crocodile.UI.Infrastructure
{
	using ViewModels;

	public class PageSelectionChangedEvent
	{
		public PageSelectionChangedEvent(PageViewModel page)
		{
			Page = page;
		}
		
		public PageViewModel Page { get; private set; } 
	}
}