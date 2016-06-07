using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using DataAccessLayer;
using DataLayer;
using DataLayer.Entities;
using DataAccessLayer.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClinet
{
    /// <summary>
    /// Summary description for TestClient
    /// </summary>
    [TestClass]
    public class TestClient
    {
        public TestClient()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_LookUpLicensesByApplication_Test()
        {
            LicensingContext context = new LicensingContext();
            ILicenseLookUp lookUp = new LicenseLookUp(context);
            Application app = new Application();
            string name = app.App = "SLMS";

            var result = lookUp.GetLicensesByApplication(name);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }
    }
}
