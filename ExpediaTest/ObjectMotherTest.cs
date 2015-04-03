using System;
using System.Collections.Generic;
using Expedia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpediaTest
{
    class ObjectMotherTest
    {
        [TestMethod]
        public void TestObjectMotherCanCreateCarBMW()
        {
            var target = ObjectMother.BMW();

            Assert.Equals(target.Name, "BMW");
        }
    }
}
