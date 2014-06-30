namespace Crocodile.Domain
{
	using System.Collections.Generic;
	using System.IO;

	public class Project
	{
		public Project(DirectoryInfo info)
		{
			Name = info.FullName.Split(new[] {'\\'})[5];
			DirectoryInfo = info;

			Books = new List<Book>();
		}
		
		public string Name { get; private set;}
		public DirectoryInfo DirectoryInfo { get; private set; }
		public IList<Book> Books { get; set; }
		public Category Category { get; set; }
	}
}