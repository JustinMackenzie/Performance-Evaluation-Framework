using NUnit.Framework;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class Vector3fTests
    {
        [Ignore]
        public void TestAngleBetween()
        {
            Vector3f a = new Vector3f(0.2162451f, -0.2103498f, 0.9534101f);
            Vector3f b = new Vector3f(0.2753641f, -0.287051469f, 0.9174835f);

            float angle = Vector3f.AngleBetween(a, b);

            Assert.AreEqual(5.92, angle);
        }
    }
}
