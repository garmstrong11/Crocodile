namespace Crocodile.UI.ViewModels
{
	using System.Collections.Generic;

	public static class CategoryRepo
	{
		public static IList<CategoryViewModel> GetCategories()
		{
			return new List<CategoryViewModel>
			{
			new CategoryViewModel("ABC", @"^ABC"),
			new CategoryViewModel("Accounting", @"^Acc"),
			new CategoryViewModel("Algebra", @"^Alg"),
			new CategoryViewModel("Art", @"^Art"),
			new CategoryViewModel("Animal Science", @"^AS"),
			new CategoryViewModel("Bible Reading", @"^BR"),
			new CategoryViewModel("Business Math", @"^BUS"),
			new CategoryViewModel("Christian Growth", @"^CHR"),
			new CategoryViewModel("Collectivism", @"^COL"),
			new CategoryViewModel("Constitution", @"^CON"),
			new CategoryViewModel("Coordination Development", @"^COO"),
			new CategoryViewModel("English", @"^ENG"),
			new CategoryViewModel("French", @"^FRE"),
			new CategoryViewModel("General Business", @"^GEN"),
			new CategoryViewModel("Geometry", @"^GEO"),
			new CategoryViewModel("Health", @"^HEA"),
			new CategoryViewModel("History of Civilization", @"^HIS"),
			new CategoryViewModel("Intermediate Math", @"^INTM"),
			new CategoryViewModel("Literature & Creative Writing", @"^LCW"),
			new CategoryViewModel("Basic Literature", @"^LIT"),
			new CategoryViewModel("Life of Christ", @"^LOC"),
			new CategoryViewModel("College Math", @"^Math\d+Coll"),
			new CategoryViewModel("Math", @"^Math(Key|RR)?\d{2}(?!Coll)"),
			new CategoryViewModel("Missions", @"^MIS"),
			new CategoryViewModel("Music", @"^MUS"),
			new CategoryViewModel("New Testament", @"^NT"),
			new CategoryViewModel("Old Testament", @"^OT"),
			new CategoryViewModel("Physical Science", @"^PHY"),
			new CategoryViewModel("Science", @"^SCI"),
			new CategoryViewModel("Spanish", @"^SPA"),
			new CategoryViewModel("Speech", @"^SPE"),
			new CategoryViewModel("Social Studies", @"^SS"),
			new CategoryViewModel("Typing", @"^Typ"),
			new CategoryViewModel("Videophonics", @"^Vid"),
			new CategoryViewModel("Word Building", @"^WB")
			};
		}
	}
}