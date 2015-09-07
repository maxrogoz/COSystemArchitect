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
        public void SimpleLogTestInitialization()
        {
            DeleteLog();

            SimpleLog Log = new SimpleLog();
            Log.Init(testAppName);
            Assert.IsTrue(EventLog.SourceExists(testAppName));
            Log.Init(testAppName);
        }

        [TestMethod]
        public void SimpleLogTestWrite()
        {
            DeleteLog();

            SimpleLog Log = new SimpleLog();
            Log.Init(testAppName);
            Log.Write(EventLogEntryType.Error, "Test");
        }

        private void DeleteLog()
        {
            if (EventLog.Exists(testAppName))
                EventLog.Delete(testAppName);
        }

    }
}
