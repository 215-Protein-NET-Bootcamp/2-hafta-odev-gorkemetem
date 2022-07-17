using NUnit.Framework;
using System;

namespace ProteinApi.Test
{
    [Obsolete("use student insted of Student.cs ")]
    public class DemoStudent
    {

    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DemoStudent obj = new DemoStudent();
            Assert.Equals(true,true);
        }
    }
}