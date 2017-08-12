using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScenarioManagement.Domain.UnitTests
{
    [TestClass]
    public class ProcedureTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_AssignsName()
        {
            string name = "Test Name";
            Procedure procedure = new Procedure(name);

            Assert.AreEqual(name, procedure.Name);
        }

        [TestMethod]
        public void Constructor_ValidParameters_InitializesEmptyScenarioList()
        {
            string name = "Test Name";
            Procedure procedure = new Procedure(name);

            Assert.IsTrue(procedure.Scenarios.SequenceEqual(Enumerable.Empty<Scenario>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NullName_ThrowsException()
        {
            string expectedMessage = $"The procedure name cannot be null or empty.{Environment.NewLine}Parameter name: name";
            string expectedParamName = "name";

            try
            {
                Procedure procedure = new Procedure(null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
                Assert.AreEqual(expectedParamName, e.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyName_ThrowsException()
        {
            string expectedMessage = $"The procedure name cannot be null or empty.{Environment.NewLine}Parameter name: name";
            string expectedParamName = "name";

            try
            {
                Procedure procedure = new Procedure(string.Empty);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
                Assert.AreEqual(expectedParamName, e.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void AddScenario_ValidParameters_CreatesScenario()
        {
            string procedureName = "Procedure";
            string scenarioName = "Scenario";
            Procedure procedure = new Procedure(procedureName);

            procedure.AddScenario(scenarioName);

            Scenario scenario = procedure.Scenarios.Single(s => s.Name == scenarioName);

            Assert.AreEqual(scenarioName, scenario.Name);
        }
    }
}
