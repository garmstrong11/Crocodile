namespace Crocodile.UI.ViewModels
{
	public interface IBookViewModelFactory
	{
		BookViewModel Create(BookTreeViewItemViewModel bookModel);
	}
}