namespace Crocodile.ConsolePdfRead
{
	using System.Linq;
	using PdfFileAnalyzer;

	class Program
	{
		static void Main(string[] args)
		{
			//string pdfFilePath = @"F:\ACE\Copydot\1450 wb1050 pg21.PDF";
			string pdfFilePath = @"F:\ACE\Copydot\1453 wb1053 pg01.PDF";
			var doc = new PdfDocument();

			if (doc.ReadPdfFile(pdfFilePath)) return;

			var seps = doc.ObjectArray
				.Where(d => d.ObjectType != null && d.ObjectType.StartsWith("/CS"))
				.Select(d => d.ObjectValue.ToArray[1].ToString().Substring(1))
				.ToList();
		}
	}
}
