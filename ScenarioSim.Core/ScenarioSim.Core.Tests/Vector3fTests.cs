using System;
using NUnit.Framework;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class Vector3fTests
    {
        [Test]
        public void TestAngleBetween()
        {
            Vector3f a = new Vector3f(10, 6, 11);
            Vector3f b = new Vector3f(5, 4, 8);

            float angle = Vector3f.AngleBetween(a, b);

            Assert.IsTrue(Math.Abs(angle - 9.54f) < 0.01);
        }
    }
}
