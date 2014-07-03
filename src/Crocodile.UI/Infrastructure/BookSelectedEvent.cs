namespace Crocodile.UI.Infrastructure
{
	using System.Collections.Generic;
	using Domain;

	public class BookSelectedEvent
	{
		public bool IsSelected { get; set; }
		public int ItemId { get; set; }
		public string ProjectPath { get; set; }
		public IList<ArtFile> ArtFiles { get; set; }
	}
}