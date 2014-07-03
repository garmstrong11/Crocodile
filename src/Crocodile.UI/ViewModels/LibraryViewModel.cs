namespace Crocodile.UI.ViewModels
{
	using System;
	using System.Collections.ObjectModel;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Caliburn.Micro;

	public class LibraryViewModel : CrocScreen 
	{
		private readonly ReadOnlyCollection<CategoryViewModel> _categories;

		public LibraryViewModel(BookConductorViewModel bookConductor)
		{
			_categories = new ReadOnlyCollection<CategoryViewModel>(CategoryRepo.GetCategories());
			BookConductor = bookConductor;
		}

		public ReadOnlyCollection<CategoryViewModel> Categories
		{
			get { return _categories; }
		}

		public BookConductorViewModel BookConductor { get; private set; }
			
	}
}