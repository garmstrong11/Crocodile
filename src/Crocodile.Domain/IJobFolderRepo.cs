namespace Crocodile.Domain
{
	using System.Collections.Generic;

	public interface IJobFolderRepo
	{
		IList<string> JobFolders { get; } 
	}
}