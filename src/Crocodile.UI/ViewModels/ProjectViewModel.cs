namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.IO;
	using Caliburn.Micro;
	using Domain;

	public class ProjectViewModel : PropertyChangedBase
	{
		private string _name;
		private DirectoryInfo _directoryInfo;
		private IList<BookViewModel> _books;
		private CategoryViewModel _category;

		public ProjectViewModel(DirectoryInfo info)
		{
			Name = info.FullName.Split(new[] {'\\'})[5];
			DirectoryInfo = info;

			Books = new List<BookViewModel>();
		}

		public string Name
		{
			get { return _name; }
			set
			{
				if (value == _name) return;
				_name = value;
				NotifyOfPropertyChange(() => Name);
			}
		}

		public DirectoryInfo DirectoryInfo
		{
			get { return _directoryInfo; }
			set
			{
				if (Equals(value, _directoryInfo)) return;
				_directoryInfo = value;
				NotifyOfPropertyChange(() => DirectoryInfo);
			}
		}

		public IList<BookViewModel> Books
		{
			get { return _books; }
			set
			{
				if (Equals(value, _books)) return;
				_books = value;
				NotifyOfPropertyChange(() => Books);
			}
		}

		public CategoryViewModel Category
		{
			get { return _category; }
			set { _category = value; }
		}
	}
}