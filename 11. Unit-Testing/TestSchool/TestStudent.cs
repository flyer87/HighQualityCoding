using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            //actions
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            //actions
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentEmptyNameThrowsException()
        {
            Student student = new Student();
            student.Name = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentNullNameThrowsException()
        {
            Student student = new Student();
            student.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentLargerIdThrowsExceptions()
        {
            Student st = new Student();
            st.Id = 999990;
        }

        [TestMethod,]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentLessIdThrowsExcpetion()
        {
            Student st = new Student();
            st.Id = 999;
        }

        [TestMethod]
        [Ignore]
        public void TestStudentCheckAvergeNote()
        {
            Student st = new Student();
            st.AddNote(5);
            st.AddNote(5);
            st.AddNote(5);
            Assert.AreEqual(5.00f, st.CalcAverageNote(), "Expected average note is differentiate!");
        }
    }
}
