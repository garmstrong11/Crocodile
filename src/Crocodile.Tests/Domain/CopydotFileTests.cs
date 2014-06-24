namespace Crocodile.Tests.Domain
{
	using Crocodile.Domain;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class CopydotFileTests
	{
		private string _path;

		[SetUp]
		public void Init()
		{
			_path = @"\\San\araxivolume_ace\Jobs\Eng1029_cd\UserDefinedFolders\Customer Originals\eng 1029 sk\7229 eng1029 pg01.PDF";
		}
		
		[Test]
		public void Path_ReturnsPassedInPath()
		{
			var cdf = new CopydotFile(_path);

			cdf.Path.Should().Be(_path);
		}

		[Test]
		public void PropertyGet_PrinergyJobName_ReturnsExpected()
		{
			var cdf = new CopydotFile(_path);
			cdf.PrinergyJobName.Should().Be("Eng1029_cd");
		}

		[Test]
		public void PropertyGet_ParentPath_ReturnsExpected()
		{
			var cdf = new CopydotFile(_path);
			cdf.ParentPath.Should().Be(@"\\San\araxivolume_ace\Jobs\Eng1029_cd\UserDefinedFolders\Customer Originals\eng 1029 sk");
		}

		[Test]
		public void PropertyGet_ParentName_ReturnsExpected()
		{
			var cdf = new CopydotFile(_path);
			cdf.ParentName.Should().Be("eng 1029 sk");
		}

		[Test]
		public void PropertyGet_HasDescreenedCousins_ReturnsExpected()
		{
			var cdf = new CopydotFile(_path);
			var cdf2 = new CopydotFile(
					@"\\San\araxivolume_ace\Jobs\Art77_cd\UserDefinedFolders\Customer Originals\beg art 77\60077 beg art77 pg01.PDF");

			cdf.HasDescreenedCousin.Should().Be(false);
			cdf2.HasDescreenedCousin.Should().Be(true);
		}
	}
}