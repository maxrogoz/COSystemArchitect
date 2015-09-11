using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

using LBBackuper;

namespace LBUnitTests.LBBackuper.FileProcessor
{
    [TestClass]
    public class DirectoryCreatorTest
    {
        public DirectoryCreatorTest()
        {
        }

        private TestContext testContextInstance;

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
        public void FileProcessorDirectoryCreationTest()
        {
            //PathCopier pc = new PathCopier();
            //pc.CopyPathWithUserRights(@"d:\ctest", null, @"\\MROGOZA-H\Public\ct", null);

            //string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            //Assert.IsFalse(Directory.Exists(tempPath));
            
            //DirectoryCreator dc = new DirectoryCreator();
            //dc.CreateDirectory(tempPath);
            //Assert.IsTrue(Directory.Exists(tempPath));
            //Directory.Delete(tempPath);

            //TimeSpan time = DateTime.Now.TimeOfDay;

            //ITask task = new LBBackuper.BackupTask() {
            //    SourceFolder = @"d:\ctest",
            //    DestFolder = @"\\MROGOZA-H\Public\ct",
            //    FileProcessor = AppKernel.Get<IFileProcessor>(),
            //    Logger =  AppKernel.Get<ILog>()
            //};

            //ISchedule s1 = new LBBackuper.BackupSchedule()
            //{
            //    Time = time.Add(new TimeSpan(0, 0, 5)),
            //    Task = task
            //};
            //ISchedule s2 = new LBBackuper.BackupSchedule()
            //{
            //    Time = time.Add(new TimeSpan(0, 1, 5)),
            //    Task = task
            //};
            //ISchedule s3 = new LBBackuper.BackupSchedule()
            //{
            //    Time = time.Add(new TimeSpan(0, 1, 6)),
            //    Task = task
            //};

        }
    }
}
