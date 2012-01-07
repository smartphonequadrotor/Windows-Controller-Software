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
        private XmppClient xmppClient;

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

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            xmppClient = new XmppClient();
            xmppClient.ConnectServer = "127.0.0.1";
            xmppClient.Username = "ControllerTest";
            xmppClient.Password = "MegatronDump";
            xmppClient.Resource = "XmppClientTest";
            xmppClient.Server = "smartphonequadrotor";
            xmppClient.QPhoneUsername = "QPhoneTest";
            xmppClient.QPhoneResource = "";
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            xmppClient = null;
        }
        
        #endregion


        /// <summary>
        ///A test for connect
        ///</summary>
        [TestMethod()]
        public void connectTest()
        {
            bool expected = true;
            bool actual;
            actual = xmppClient.connect();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for writeMessage
        ///</summary>
        [TestMethod()]
        public void writeMessageTest()
        {
            Assert.IsTrue(xmppClient.connect());
            string message = "hello there!";
            bool expected = true;
            bool actual = xmppClient.writeMessage(message);
            Assert.AreEqual(expected, actual);
        }
    }
}
