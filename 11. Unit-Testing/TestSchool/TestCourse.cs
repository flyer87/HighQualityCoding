using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class TestCourse
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // initialize actions
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // test cleanup actions
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseAddNullStudent()
        {
            Course c = new Course();
            c.AddStudent(null);
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            Course c = new Course();
            Student st = new Student();
            c.AddStudent(st);
            Assert.AreEqual(1, c.getStudentsCount(), "Student append problem!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseRemoveNullStudent()
        {
            Course c = new Course();
            c.RemoveStudent(null);
        }

        [TestMethod]
        public void TestCourseRemoveStudent()
        {
            Course c = new Course();
            Student s = new Student();
            c.AddStudent(s);
            c.RemoveStudent(s);
            Assert.AreEqual(0, c.getStudentsCount());
        }
    }
}
