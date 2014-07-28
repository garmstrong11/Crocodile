namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;

	public interface IProgressViewModel
	{
		int Progress { get; }
		string CurrentFilename { get; }
		int FileCount { get; }
		void ProcessFilesAsync();
		IEnumerable<PageViewModel> Items { get; set; } 
	}
}