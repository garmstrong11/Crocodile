namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using Domain;

	public class BookViewModel : TreeViewItemViewModel
	{
		
		public BookViewModel(TreeViewItemViewModel parent)
			: base(parent)
		{
			
		}
		
		public string Name { get; set; }
		public int ItemId { get; set; }
		public BookType BookType { get; set; }
	}
}