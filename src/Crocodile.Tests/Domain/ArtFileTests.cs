namespace Crocodile.Tests.Domain
{
	using Crocodile.Domain;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class ArtFileTests
	{
		[Test]
		public void PropertyGet_Index_ReturnsExpected()
		{
			var pg = new ArtFile("82128 acc128 pg48.PDF");

			pg.Index.Should().Be(48);
		}

		[Test]
		public void PropertyGet_Id_ReturnsExpected()
		{
			var pg = new ArtFile("82128 acc128 pg48.PDF");

			pg.Id.Should().Be(82128);
		}

		[TestCase("6721 math1121-1123 pg40 sk.PDF", Result = BookType.ScoreKey)]
		[TestCase("6721 math1121-1123 sk pg40.PDF", Result = BookType.ScoreKey)]
		[TestCase("6721 math1121-1123 pg40.PDF ak", Result = BookType.AnswerKey)]
		[TestCase("6721 math1121-1123 AP pg40.PDF", Result = BookType.ActivityPack)]
		[TestCase("6721 math1121-1123 pg40.PDF", Result = BookType.Pace)]
		public BookType PropertyGet_BookType_ReturnsExpected(string test)
		{
			return new ArtFile(test).BookType;
		}

		[TestCase("6721 math1121-1123 pg40 sk.PDF", Result = ArtFileType.Pdf)]
		[TestCase("6721 math1121-1123 pg40 sk.tif", Result = ArtFileType.Tif)]
		public ArtFileType ArtFileType_ReturnsCorrectType(string test)
		{
			return new ArtFile(test).ArtFileType;
		}
	}
}