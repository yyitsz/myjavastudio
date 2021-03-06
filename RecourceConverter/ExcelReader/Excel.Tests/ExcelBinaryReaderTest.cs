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
	public class ExcelBinaryReaderTest
	{
		[TestMethod]
		public void AsDataSet_Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("TestChess"), ExcelFileType.Binary);

			DataSet result = excelReader.AsDataSet();

			Assert.IsTrue(result != null);
			Assert.AreEqual(1, result.Tables.Count);
			Assert.AreEqual(4, result.Tables[0].Rows.Count);
			Assert.AreEqual(6, result.Tables[0].Columns.Count);

			excelReader.Close();
		}


		[TestMethod]
		public void Fail_Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("TestFail_Binary"), ExcelFileType.Binary);

			Assert.AreEqual(false, excelReader.IsValid);
			Assert.AreEqual(true, excelReader.IsClosed);
			Assert.AreEqual("Error: Invalid file signature.", excelReader.ExceptionMessage);
		}

		[TestMethod]
		public void ChessTest()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("TestChess"), ExcelFileType.Binary);

			DataTable result = excelReader.AsDataSet().Tables[0];

			Assert.AreEqual(4, result.Rows.Count);
			Assert.AreEqual(6, result.Columns.Count);
			Assert.AreEqual("1", result.Rows[3][5].ToString());
			Assert.AreEqual("1", result.Rows[2][0].ToString());

			excelReader.Close();
		}

		[TestMethod]
		public void Dimension10x10000Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test10x10000"), ExcelFileType.Binary);

			DataTable result = excelReader.AsDataSet().Tables[0];

			Assert.AreEqual(10000, result.Rows.Count);
			Assert.AreEqual(10, result.Columns.Count);
			Assert.AreEqual("1x2", result.Rows[1][1]);
			Assert.AreEqual("1x10", result.Rows[1][9]);
			Assert.AreEqual("1x1", result.Rows[9999][0]);
			Assert.AreEqual("1x10", result.Rows[9999][9]);

			excelReader.Close();
		}

		[TestMethod]
		public void Dimension10x10Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test10x10"), ExcelFileType.Binary);

			DataTable result = excelReader.AsDataSet().Tables[0];

			Assert.AreEqual(10, result.Rows.Count);
			Assert.AreEqual(10, result.Columns.Count);
			Assert.AreEqual("10x10", result.Rows[1][0]);
			Assert.AreEqual("10x27", result.Rows[9][9]);

			excelReader.Close();
		}

		[TestMethod]
		public void Dimension255x10Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test255x10"), ExcelFileType.Binary);

			DataTable result = excelReader.AsDataSet().Tables[0];

			Assert.AreEqual(10, result.Rows.Count);
			Assert.AreEqual(255, result.Columns.Count);
			Assert.AreEqual("1", result.Rows[9][254].ToString());
			Assert.AreEqual("one", result.Rows[1][1].ToString());

			excelReader.Close();
		}

		[TestMethod]
		public void MultiSheetTest()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("TestMultiSheet"), ExcelFileType.Binary);

			DataSet result = excelReader.AsDataSet();

			Assert.AreEqual(3, result.Tables.Count);

			Assert.AreEqual(4, result.Tables["Sheet1"].Columns.Count);
			Assert.AreEqual(12, result.Tables["Sheet1"].Rows.Count);
			Assert.AreEqual(4, result.Tables["Sheet2"].Columns.Count);
			Assert.AreEqual(12, result.Tables["Sheet2"].Rows.Count);
			Assert.AreEqual(2, result.Tables["Sheet3"].Columns.Count);
			Assert.AreEqual(5, result.Tables["Sheet3"].Rows.Count);

			Assert.AreEqual("2", result.Tables["Sheet1"].Rows[11][3].ToString());
			Assert.AreEqual("1", result.Tables["Sheet2"].Rows[11][0].ToString());
			Assert.AreEqual("3", result.Tables["Sheet3"].Rows[4][1].ToString());

			excelReader.Close();
		}

		[TestMethod]
		public void UnicodeCharsTest()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("TestUnicodeChars"), ExcelFileType.Binary);

			DataTable result = excelReader.AsDataSet().Tables[0];

			Assert.AreEqual(3, result.Rows.Count);
			Assert.AreEqual(8, result.Columns.Count);
			Assert.AreEqual(Helper.GetKey("TestUnicodePos2x1"), result.Rows[1][0].ToString());

			excelReader.Close();
		}

		[TestMethod]
		public void DoublePrecisionTest()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("TestDoublePrecision"), ExcelFileType.Binary);

			DataTable result = excelReader.AsDataSet().Tables[0];

			double excelPI = 3.1415926535897900;

			Assert.AreEqual(+excelPI, Helper.ParseDouble(result.Rows[2][1].ToString()), 1e-14);
			Assert.AreEqual(-excelPI, Helper.ParseDouble(result.Rows[3][1].ToString()), 1e-14);

			Assert.AreEqual(+excelPI * 1.0e-300, Helper.ParseDouble(result.Rows[4][1].ToString()), 3e-315);
			Assert.AreEqual(-excelPI * 1.0e-300, Helper.ParseDouble(result.Rows[5][1].ToString()), 3e-315);

			Assert.AreEqual(+excelPI * 1.0e300, Helper.ParseDouble(result.Rows[6][1].ToString()));
			Assert.AreEqual(-excelPI * 1.0e300, Helper.ParseDouble(result.Rows[7][1].ToString()));

			Assert.AreEqual(+excelPI * 1.0e15, Helper.ParseDouble(result.Rows[8][1].ToString()));
			Assert.AreEqual(-excelPI * 1.0e15, Helper.ParseDouble(result.Rows[9][1].ToString()));

			excelReader.Close();

		}


		[TestMethod]
		public void Issue_Encoding_1520_Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test_Encoding_1520"), ExcelFileType.Binary);

			DataSet dataSet = excelReader.AsDataSet();

			string val1 = "Simon Hodgetts";
			string val2 = dataSet.Tables[0].Rows[2][0].ToString();
			Assert.AreEqual(val1, val2);

			val1 = "John test";
			val2 = dataSet.Tables[0].Rows[1][0].ToString();
			Assert.AreEqual(val1, val2);

			//librement réutilisable
			val1 = "librement réutilisable";
			val2 = dataSet.Tables[0].Rows[7][0].ToString();
			Assert.AreEqual(val1, val2);

			val2 = dataSet.Tables[0].Rows[8][0].ToString();
			Assert.AreEqual(val1, val2);

			excelReader.Close();

		}

		[TestMethod]
		public void Issue_Date_and_Time_1468_Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test_Encoding_1520"), ExcelFileType.Binary);

			DataSet dataSet = excelReader.AsDataSet(true);

			string val1 = new DateTime(2009, 05, 01).ToShortDateString();
			string val2 = DateTime.Parse(dataSet.Tables[0].Rows[1][1].ToString()).ToShortDateString();

			Assert.AreEqual(val1, val2);

			val1 = DateTime.Parse("11:00:00").ToShortTimeString();
			val2 = DateTime.Parse(dataSet.Tables[0].Rows[2][4].ToString()).ToShortTimeString();

			Assert.AreEqual(val1, val2);

			excelReader.Close();
		}

		[TestMethod]
		public void Issue_Decimal_1109_Test()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test_Decimal_1109"), ExcelFileType.Binary);

			DataSet dataSet = excelReader.AsDataSet(true);

			Assert.AreEqual(Double.Parse("3.14159"), Double.Parse(dataSet.Tables[0].Rows[0][0].ToString()));

			double val1 = -7080.61;
			double val2 = Double.Parse(dataSet.Tables[0].Rows[0][1].ToString());
			Assert.AreEqual(val1, val2);

			excelReader.Close();
		}

		[TestMethod]
		public void Test_num_double_date_bool_string()
		{
			IExcelDataReader excelReader = Factory.CreateReader(Helper.GetTestWorkbook("Test_num_double_date_bool_string"), ExcelFileType.Binary);

			DataSet dataSet = excelReader.AsDataSet(true);

			Assert.AreEqual(30, dataSet.Tables[0].Rows.Count);
			Assert.AreEqual(6, dataSet.Tables[0].Columns.Count);

			Assert.AreEqual(int.Parse("1"), int.Parse(dataSet.Tables[0].Rows[0][0].ToString()));
			Assert.AreEqual(int.Parse("1346269"), int.Parse(dataSet.Tables[0].Rows[29][0].ToString()));

			//double + Formula
			Assert.AreEqual(double.Parse("1.02"), double.Parse(dataSet.Tables[0].Rows[0][1].ToString()));
			Assert.AreEqual(double.Parse("4.08"), double.Parse(dataSet.Tables[0].Rows[2][1].ToString()));
			Assert.AreEqual(double.Parse("547608330.24"), double.Parse(dataSet.Tables[0].Rows[29][1].ToString()));

			//Date + Formula
			Assert.AreEqual(DateTime.Parse("05.07.2009").ToShortDateString(), DateTime.Parse(dataSet.Tables[0].Rows[0][2].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToShortDateString());
			Assert.AreEqual(DateTime.Parse("11.26.2009").ToShortDateString(), DateTime.Parse(dataSet.Tables[0].Rows[29][2].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToShortDateString());

			//Custom Date Time + Formula
			Assert.AreEqual(DateTime.Parse("05.07.2009").ToShortDateString(), DateTime.Parse(dataSet.Tables[0].Rows[0][5].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToShortDateString());
			Assert.AreEqual(DateTime.Parse("05.08.2009 11:01:02"), DateTime.Parse(dataSet.Tables[0].Rows[1][5].ToString(), System.Globalization.CultureInfo.InvariantCulture));

			//DBNull value
			Assert.AreEqual(DBNull.Value, dataSet.Tables[0].Rows[1][4]);

			excelReader.Close();
		}

		[TestMethod]
		public void DataReader_Read_Test()
		{
			IExcelDataReader r = Factory.CreateReader(Helper.GetTestWorkbook("Test_num_double_date_bool_string"), ExcelFileType.Binary);

			DataTable table = new DataTable();
			table.Columns.Add(new DataColumn("num_col", typeof(int)));
			table.Columns.Add(new DataColumn("double_col", typeof(double)));
			table.Columns.Add(new DataColumn("date_col", typeof(DateTime)));
			table.Columns.Add(new DataColumn("boo_col", typeof(bool)));

			int fieldCount = -1;

			while (r.Read())
			{
				fieldCount = r.FieldCount;
				table.Rows.Add(r.GetInt32(0), r.GetDouble(1), r.GetDateTime(2), r.IsDBNull(4));
			}

			r.Close();

			Assert.AreEqual(6, fieldCount);

			Assert.AreEqual(30, table.Rows.Count);

			Assert.AreEqual(int.Parse("1"), int.Parse(table.Rows[0][0].ToString()));
			Assert.AreEqual(int.Parse("1346269"), int.Parse(table.Rows[29][0].ToString()));

			//double + Formula
			Assert.AreEqual(double.Parse("1.02"), double.Parse(table.Rows[0][1].ToString()));
			Assert.AreEqual(double.Parse("4.08"), double.Parse(table.Rows[2][1].ToString()));
			Assert.AreEqual(double.Parse("547608330.24"), double.Parse(table.Rows[29][1].ToString()));

			//Date + Formula
			Assert.AreEqual(DateTime.Parse("05.07.2009").ToShortDateString(), DateTime.Parse(table.Rows[0][2].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToShortDateString());
			Assert.AreEqual(DateTime.Parse("11.26.2009").ToShortDateString(), DateTime.Parse(table.Rows[29][2].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToShortDateString());
		}

		[TestMethod]
		public void DataReader_NextResult_Test()
		{
			IExcelDataReader r = Factory.CreateReader(Helper.GetTestWorkbook("TestMultiSheet"), ExcelFileType.Binary);

			Assert.AreEqual(3, r.ResultsCount);

			DataTable table = new DataTable();
			table.Columns.Add("c1", typeof(int)); table.Columns.Add("c2", typeof(int)); table.Columns.Add("c3", typeof(int)); table.Columns.Add("c4", typeof(int));

			int fieldCount = -1;

			while (r.Read())
			{
				fieldCount = r.FieldCount;
				table.Rows.Add(r.GetInt32(0), r.GetInt32(1), r.GetInt32(2), r.GetInt32(3));
			}

			Assert.AreEqual(12, table.Rows.Count);
			Assert.AreEqual(4, fieldCount);
			Assert.AreEqual(1, table.Rows[11][3]);


			r.NextResult();
			table.Rows.Clear();

			while (r.Read())
			{
				fieldCount = r.FieldCount;
				table.Rows.Add(r.GetInt32(0), r.GetInt32(1), r.GetInt32(2), r.GetInt32(3));
			}

			Assert.AreEqual(12, table.Rows.Count);
			Assert.AreEqual(4, fieldCount);
			Assert.AreEqual(2, table.Rows[11][3]);


			r.NextResult();
			table.Rows.Clear();

			while (r.Read())
			{
				fieldCount = r.FieldCount;
				table.Rows.Add(r.GetInt32(0), r.GetInt32(1));
			}

			Assert.AreEqual(5, table.Rows.Count);
			Assert.AreEqual(2, fieldCount);
			Assert.AreEqual(3, table.Rows[4][1]);

			Assert.AreEqual(false, r.NextResult());

			r.Close();
		}

		[TestMethod]
		public void Dimension10x10TestBIFF12()
		{

		}
	}
}