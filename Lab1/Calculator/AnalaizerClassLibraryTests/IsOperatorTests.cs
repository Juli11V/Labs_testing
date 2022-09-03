using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnalaizerClassLibraryTests
{
    [TestClass]
    public class IsOperatorTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\UnitTests.mdf;Integrated Security=True;Connect Timeout=30", "Test2Data", DataAccessMethod.Sequential)]
        [TestMethod]
        public void IsOperator_IsOperatorGetFromDB_ResultBoolean()
        {
            //Asert

            string operators = (string)TestContext.DataRow["operator"];
            bool expectedResult = System.Convert.ToBoolean(TestContext.DataRow["result"]);

           //Act

            bool actualResult;

           //Assert

            try
            {
                actualResult = AnalaizerClass.IsOperator(operators);
                Assert.AreEqual(expectedResult, actualResult);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}









       