using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace Excel.Tests
{
	internal static class Helper
	{
		public static Stream GetTestWorkbook(string key)
		{
			string fileName = Path.Combine(GetKey("basePath"), GetKey(key));
			System.Diagnostics.Debug.Assert(File.Exists(fileName), "Inside the Excel.Tests App.config file, edit the key basePath to be the folder where the test workbooks are located.");

			return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		}

		public static string GetKey(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

		public static double ParseDouble(string s)
		{
			return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}
