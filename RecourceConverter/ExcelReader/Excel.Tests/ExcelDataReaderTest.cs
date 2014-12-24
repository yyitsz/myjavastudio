using System;
using System.IO;
using System.Data;
using System.Configuration;
using Excel;

#if MSTEST_DEBUG || MSTEST_RELEASE
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using Assert = NUnit.Framework.Assert;
#endif

namespace Excel.Tests
{
	[TestClass]
	public class ExcelDataReaderTest
	{
		#region Setup/Teardown


		#endregion

		private static Stream GetTestWorkbook(string key)
		{
			string fileName = Path.Combine(GetKey("basePath"), GetKey(key));
			System.Diagnostics.Debug.Assert(File.Exists(fileName), "Inside the Excel.Tests App.config file, edit the key basePath to be the folder where the test workbooks are located.");

			return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		}

		private static string GetKey(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

		[TestMethod]
		public void ChessTest()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("TestChess"));

			DataTable result = excelReader.WorkbookData.Tables[0];

			Assert.AreEqual(4, result.Rows.Count);
			Assert.AreEqual(6, result.Columns.Count);
		}


		[TestMethod]
		public void Dimension10x10000Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test10x10000"));

			DataTable result = excelReader.WorkbookData.Tables[0];

			Assert.AreEqual(10000, result.Rows.Count);
			Assert.AreEqual(10, result.Columns.Count);
		}

		[TestMethod]
		public void Dimension10x10Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test10x10"));

			DataTable result = excelReader.WorkbookData.Tables[0];

			Assert.AreEqual(10, result.Rows.Count);
			Assert.AreEqual(10, result.Columns.Count);
		}

		[TestMethod]
		public void Dimension255x10Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test255x10"));

			DataTable result = excelReader.WorkbookData.Tables[0];

			Assert.AreEqual(10, result.Rows.Count);
			Assert.AreEqual(255, result.Columns.Count);
		}

		[TestMethod]
		public void MultiSheetTest()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("TestMultiSheet"));

			Assert.AreEqual(3, excelReader.WorkbookData.Tables.Count);
		}

		[TestMethod]
		public void PromoteToColumnsTest()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test10x10"), true, true);

			DataTable result = excelReader.WorkbookData.Tables[0];

			Assert.AreEqual(9, result.Rows.Count);
			Assert.AreEqual("col1", result.Columns[0].ColumnName);
			Assert.AreEqual("Column2", result.Columns[1].ColumnName);
		}

		[TestMethod]
		public void UnicodeCharsTest()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("TestUnicodeChars"));

			DataTable result = excelReader.WorkbookData.Tables[0];

			Assert.AreEqual(3, result.Rows.Count);
			Assert.AreEqual(8, result.Columns.Count);
			Assert.AreEqual(GetKey("TestUnicodePos2x1"), result.Rows[1][0].ToString());
		}

		[TestMethod]
		public void DoublePrecisionTest()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("TestDoublePrecision"));
			DataTable result = excelReader.WorkbookData.Tables[0];

			double excelPI = 3.1415926535897900;

			Assert.AreEqual(+excelPI, ParseDouble(result.Rows[2][1].ToString()), 1e-14);
			Assert.AreEqual(-excelPI, ParseDouble(result.Rows[3][1].ToString()), 1e-14);

			Assert.AreEqual(+excelPI * 1.0e-300, ParseDouble(result.Rows[4][1].ToString()), 3e-315);
			Assert.AreEqual(-excelPI * 1.0e-300, ParseDouble(result.Rows[5][1].ToString()), 3e-315);

			Assert.AreEqual(+excelPI * 1.0e300, ParseDouble(result.Rows[6][1].ToString()));
			Assert.AreEqual(-excelPI * 1.0e300, ParseDouble(result.Rows[7][1].ToString()));

			Assert.AreEqual(+excelPI * 1.0e15, ParseDouble(result.Rows[8][1].ToString()));
			Assert.AreEqual(-excelPI * 1.0e15, ParseDouble(result.Rows[9][1].ToString()));

		}

		[TestMethod]
		public void Issue_Protected_2040_Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("TestExcel_2040"));

			Assert.AreEqual(true, excelReader.IsProtected);
		}

		[TestMethod]
		public void Issue_Encoding_1520_Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test_Encoding_1520"));
			//DataTable result = excelReader.WorkbookData.Tables[0];

			string val1 = "Simon Hodgetts";
			string val2 = excelReader.WorkbookData.Tables[0].Rows[2][0].ToString();
			Assert.AreEqual(val1, val2);

			val1 = "John test";
			val2 = excelReader.WorkbookData.Tables[0].Rows[1][0].ToString();
			Assert.AreEqual(val1, val2);

			//librement réutilisable
			val1 = "librement réutilisable";
			val2 = excelReader.WorkbookData.Tables[0].Rows[7][0].ToString();
			Assert.AreEqual(val1, val2);

			val2 = excelReader.WorkbookData.Tables[0].Rows[8][0].ToString();
			Assert.AreEqual(val1, val2);

		}

		[TestMethod]
		public void Issue_Date_and_Time_1468_Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test_Encoding_1520"));
			//excelReader.WorkbookData.Tables[0].Rows[2][0].ToString();

			string val1 = new DateTime(2009, 05, 01).ToShortDateString();
			string val2 = DateTime.Parse(excelReader.WorkbookData.Tables[0].Rows[1][1].ToString()).ToShortDateString();

			Assert.AreEqual(val1, val2);

			val1 = DateTime.Parse("11:00:00").ToShortTimeString();
			val2 = DateTime.Parse(excelReader.WorkbookData.Tables[0].Rows[2][4].ToString()).ToShortTimeString();

			Assert.AreEqual(val1, val2);
		}

		[TestMethod]
		public void Issue_Decimal_1109_Test()
		{
			ExcelDataReader excelReader = new ExcelDataReader(GetTestWorkbook("Test_Decimal_1109"));

			Assert.AreEqual(Double.Parse("3.14159"), Double.Parse(excelReader.WorkbookData.Tables[0].Rows[0][0].ToString()));

			double val1 = -7080.61;
			double val2 = Double.Parse(excelReader.WorkbookData.Tables[0].Rows[0][1].ToString());
			Assert.AreEqual(val1, val2);
		}

		private static double ParseDouble(string s)
		{
			return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}