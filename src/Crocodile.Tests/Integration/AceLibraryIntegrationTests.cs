namespace Crocodile.Tests.Integration
{
	using FluentAssertions;
	using NUnit.Framework;
	using UI.Infrastructure;

	[TestFixture]
	public class AceLibraryIntegrationTests
	{
		[Test]
		public void CanInstantiateAceLibrary()
		{
			var lib = new AceLibrary();
			lib.Categories.Should().NotBeEmpty();
		}

		[Test]
		public void FindProjects_FindsProjects()
		{
			var lib = new AceLibrary();
			lib.FindProjects();

			lib.Categories[1].Projects.Should().NotBeEmpty();
		}
	}
}