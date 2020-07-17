#if DEBUG
using System;
using System.IO;


namespace nwn2_pi_storesorter
{
	static class logfile
	{
		internal static void createLogfile()
		{
			using (var sw = new StreamWriter(File.Open("storesort.log",
													   FileMode.Create, // clean the old logfile if it exists
													   FileAccess.Write,
													   FileShare.None)))
			{}
		}

		internal static void log(string line)
		{
			using (var sw = new StreamWriter(File.Open("storesort.log",
													   FileMode.Append,
													   FileAccess.Write,
													   FileShare.None)))
			{
				sw.WriteLine(line);
			}
		}
	}
}
#endif
