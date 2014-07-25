namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;
	using Caliburn.Micro;

	public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
	{
		//private IEnumerable<IScreen> _items;

		public ShellViewModel()
		{
			Items.Add(IoC.Get<LibraryViewModel>());
			DisplayName = "Crocodile!";
		}

		//public IEnumerable<IScreen> Items
		//{
		//	get { return _items; }
		//	set { _items = value; }
		//}
	}
}