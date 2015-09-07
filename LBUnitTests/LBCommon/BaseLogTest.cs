using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LBCommon;

namespace LBCommonTests
{
    [TestClass]
    public class BaseLogTest
    {
        static string testAppName = "Test App Name";
        
        class BaseLogAccess : BaseLog
        {
        }

        [TestMethod]
        public void TestInitialization()
        {
            BaseLog Log = new BaseLogAccess();
            Log.Init(testAppName);
            Assert.AreEqual(Log.ApplicationName, testAppName);
            Log.Write(LogType.Error, "Test");
        }

        [TestMethod]
        public void TestWrite()
        {
            BaseLog Log = new BaseLogAccess();
            Log.Init(testAppName);
            Log.Write(LogType.Error, "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInitializationWithNullParam()
        {
            BaseLog Log = new BaseLogAccess();
            Log.Init(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInitializationWithEmptyString()
        {
            BaseLog Log = new BaseLogAccess();
            Log.Init("");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestWriteWithoutInit()
        {
            BaseLog Log = new BaseLogAccess();
            Log.Write(LogType.Error, "Test");
        }
    }
}
