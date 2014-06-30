namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using Caliburn.Micro;
	using Domain;

	public class BookViewModel : PropertyChangedBase
	{
		public string Name { get; set; }
		public int ItemId { get; set; }
		public IList<Page> Pages { get; set; }
		public Project Project { get; set; }
	}
}