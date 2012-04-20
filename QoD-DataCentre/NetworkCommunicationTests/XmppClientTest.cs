using QoD_DataCentre.Src.Communication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetworkCommunicationTests
{
    
    
    /// <summary>
    ///This is a test class for XmppClientTest and is intended
    ///to contain all XmppClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmppClientTest
    {


        private TestContext testContextInstance;


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
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
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
        
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}


        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

        }
        
        #endregion




        
    }
}
