namespace Crocodile.Domain
{
	using System.Collections;
	using System.Collections.Generic;

	public class Book
	{
		public string Name { get; set; }
		public int ItemId { get; set; }
		public IList<Page> Pages { get; set; }
		public Project Project { get; set; }
	}
}