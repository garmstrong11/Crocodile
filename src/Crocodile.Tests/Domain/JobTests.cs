namespace Crocodile.Tests.Domain
{
	using Crocodile.Domain;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class JobTests
	{
		//[TestCase(@"\\San\araxivolume_ace\Jobs\WB1003_4c\UserDefinedFolders\PartsMaster\Customer Originals\Copydot")]
		//[TestCase(@"\\San\araxivolume_ace\Jobs\WB1002_cd\UserDefinedFolders\Customer Originals")]
		[Test]
		public void Project_Name_returnsProjectRootDirectoryName()
		{
			var dir = @"\\San\araxivolume_ace\Jobs\WB1003_4c\UserDefinedFolders\PartsMaster\Customer Originals\Copydot";
			var prj = new Job(dir);

			prj.Name.Should().Be("WB1003_4c");

		}

		[Test]
		public void GetJobPaths_Returns_IEnumerable()
		{
			var actual = Job.GetJobPaths();
			actual.Should().NotBeNull();
		}
	}
}