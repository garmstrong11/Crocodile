namespace Crocodile.UI.ViewModels
{
	using Caliburn.Micro;

	public class JobFileViewModel : PropertyChangedBase
	{
		private string _fileName;

		public JobFileViewModel(string path)
		{
			Path = path;
		}

		public string Path { get; private set; }	

		public string FileName
		{
			get { return _fileName; }
		}
	}
}