namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using Caliburn.Micro;

	public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
	{
		//private IEnumerable<IScreen> _items;

		public ShellViewModel()
		{
			Items.Add(new JobsViewModel());
		}

		//public IEnumerable<IScreen> Items
		//{
		//	get { return _items; }
		//	set { _items = value; }
		//}
	}
}