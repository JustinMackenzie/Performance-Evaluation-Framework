using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScenarioManagement.API.Application.Commands;
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.API.Controllers;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ProcedureControllerTests
    {
        /// <summary>
        /// The mediator mock
        /// </summary>
        private Mock<IMediator> _mediatorMock;

        /// <summary>
        /// The logger mock
        /// </summary>
        private Mock<ILogger<ProcedureController>> _loggerMock;

        /// <summary>
        /// The procedure queries mock
        /// </summary>
        private Mock<IProcedureQueries> _procedureQueriesMock;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this._loggerMock = new Mock<ILogger<ProcedureController>>();
            this._mediatorMock = new Mock<IMediator>();
            this._procedureQueriesMock = new Mock<IProcedureQueries>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullMediator_ThrowsException()
        {
            try
            {
                ProcedureController controller = new ProcedureController(
                    null,
                    this._loggerMock.Object,
                    this._procedureQueriesMock.Object);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("mediator", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullProcedureQueries_ThrowsException()
        {
            try
            {
                ProcedureController controller = new ProcedureController(
                    this._mediatorMock.Object,
                    this._loggerMock.Object,
                    null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("procedureQueries", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullLogger_ThrowsException()
        {
            try
            {
                ProcedureController controller = new ProcedureController(
                    this._mediatorMock.Object,
                    null,
                    this._procedureQueriesMock.Object);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("logger", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void CreateProcedure_ValidCommand_SendsCommandToMediator()
        {
            string procedureName = "Test Name";
            Procedure procedure = new Procedure(procedureName);
            CreateProcedureCommand command = new CreateProcedureCommand { Name = procedureName };
            ProcedureController controller = new ProcedureController(
                this._mediatorMock.Object, 
                this._loggerMock.Object,
                this._procedureQueriesMock.Object);
            this._mediatorMock.Setup(m => m.Send(command, default(CancellationToken))).Returns(Task.FromResult(procedure));

            controller.CreateProcedure(command).Wait();

            this._mediatorMock.Verify(m => m.Send(command, default(CancellationToken)), Times.Once());
        }

        [TestMethod]
        public void CreateProcedure_ValidCommand_ReturnsOkWithCorrectProcedure()
        {
            string procedureName = "Test Name";
            Procedure procedure = new Procedure(procedureName);
            CreateProcedureCommand command = new CreateProcedureCommand { Name = procedureName };
            ProcedureController controller = new ProcedureController(
                this._mediatorMock.Object,
                this._loggerMock.Object,
                this._procedureQueriesMock.Object);
            this._mediatorMock.Setup(m => m.Send(command, default(CancellationToken))).Returns(Task.FromResult(procedure));

            IActionResult result = controller.CreateProcedure(command).Result;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(procedure, ((OkObjectResult)result).Value);
        }
    }
}
