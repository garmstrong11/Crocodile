namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using Caliburn.Micro;

	public class CategoryViewModel : PropertyChangedBase
	{
		private string _name;
		private Regex _catRegex;
		private IList<ProjectViewModel> _projects;

		public CategoryViewModel()
		{
			Projects = new List<ProjectViewModel>();
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

		public Regex CatRegex
		{
			get { return _catRegex; }
			set
			{
				if (Equals(value, _catRegex)) return;
				_catRegex = value;
				NotifyOfPropertyChange(() => CatRegex);
			}
		}

		public IList<ProjectViewModel> Projects
		{
			get { return _projects; }
			set
			{
				if (Equals(value, _projects)) return;
				_projects = value;
				NotifyOfPropertyChange(() => Projects);
			}
		}
	}
}