using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using LBSimpleLogger;

namespace LBSimpleLogTests
{
    [TestClass]
    public class SimpleLogTest
    {
        static string testAppName = "Simple Log Test";
        
        [TestMethod]
        public void TestInitialization()
        {
            SimpleLog Log = new SimpleLog();
            Log.Init(testAppName);
            Log.Init(testAppName);
        }

        [TestMethod]
        public void TestWrite()
        {
            SimpleLog Log = new SimpleLog();
            Log.Init(testAppName);
            Log.Write(EventLogEntryType.Error, "Test");
        }

    }
}
