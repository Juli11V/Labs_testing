using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AnalaizerClassLibrary;

namespace AnalaizerClassLibraryTests
{
    [TestClass]
    public class InsertSymbolTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\UnitTests.mdf;Integrated Security=True;Connect Timeout=30", "TestData", DataAccessMethod.Sequential)]
        [TestMethod]
        public void InsertSymbol_InsertSymbolInInputFromDB_NewInput()
        {
            //Asert

            string input = (string)TestContext.DataRow["input"];
            char symbol = Convert.ToChar(TestContext.DataRow["symbol"]);
            int position = (int)TestContext.DataRow["position"];
            string expectedInput = (string)TestContext.DataRow["expected"];

            //Act

            string actualInput;

            //Assert

            try
            {
                actualInput = AnalaizerClass.InsertSymbol(input, symbol, position);
                Assert.AreEqual(expectedInput, actualInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
