using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScenarioManagement.API.Application.Commands;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class CreateScenarioCommandHandlerTests
    {
        /// <summary>
        /// The repository mock
        /// </summary>
        private Mock<IProcedureRepository> _repositoryMock;

        /// <summary>
        /// The event bus mock
        /// </summary>
        private Mock<IEventBus> _eventBusMock;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this._repositoryMock = new Mock<IProcedureRepository>();
            this._eventBusMock = new Mock<IEventBus>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullRepository_ThrowsArgumentNullException()
        {
            try
            {
                CreateScenarioCommandHandler handler = new CreateScenarioCommandHandler(null, this._eventBusMock.Object);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("repository", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullEventBus_ThrowsArgumentNullException()
        {
            try
            {
                CreateScenarioCommandHandler handler = new CreateScenarioCommandHandler(this._repositoryMock.Object, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("eventBus", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Handle_NullCommand_ThrowsArgumentNullException()
        {
            CreateScenarioCommandHandler handler = this.CreateHandler();

            try
            {
                handler.Handle(null).Wait();
            }
            catch (AggregateException ex)
            {
                ArgumentNullException exception = (ArgumentNullException)ex.InnerException;
                Assert.AreEqual("command", exception.ParamName);
                throw exception;
            }
        }

        [TestMethod]
        public void Handle_ValidCommand_AddsScenarioWithCorrectNameToRepository()
        {
            Procedure procedure = new Procedure("Test Procedure");
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test", ProcedureId = procedure.Id };
            this._repositoryMock
                .Setup(r => r.Get(command.ProcedureId))
                .Returns(Task.FromResult(procedure));
            this._repositoryMock
                .Setup(r => r.Update(procedure))
                .Returns(Task.CompletedTask);
            CreateScenarioCommandHandler handler = this.CreateHandler();

            handler.Handle(command).Wait();

            this._repositoryMock.Verify(r => r.Update(It.Is<Procedure>(p => p.Scenarios.Any(s => s.Name == command.Name))), Times.Once());
        }

        [TestMethod]
        public void Handle_ValidCommand_PublishesEventWithCorrectData()
        {
            Procedure procedure = new Procedure("Test Procedure");
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test", ProcedureId = procedure.Id };
            this._repositoryMock
                .Setup(r => r.Get(command.ProcedureId))
                .Returns(Task.FromResult(procedure));
            this._repositoryMock
                .Setup(r => r.Update(It.IsAny<Procedure>()))
                .Returns(Task.CompletedTask);

            CreateScenarioCommandHandler handler = this.CreateHandler();

            Scenario scenario = handler.Handle(command).Result;

            this._eventBusMock.Verify(b => b.Publish(It.Is<ScenarioCreatedEvent>(e => e.ProcedureId == procedure.Id && e.Name == command.Name && e.ScenarioId == scenario.Id)));
        }

        [TestMethod]
        public void Handle_ValidCommand_ReturnsSavedScenario()
        {
            Procedure procedure = new Procedure("Test Procedure");
            Scenario scenario = null;
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test", ProcedureId = procedure.Id };
            this._repositoryMock
                .Setup(r => r.Get(command.ProcedureId))
                .Returns(Task.FromResult(procedure));
            this._repositoryMock
                .Setup(r => r.Update(It.IsAny<Procedure>()))
                .Returns(Task.CompletedTask)
                .Callback<Procedure>(p =>
                {
                    scenario = p.Scenarios.First();
                });
            CreateScenarioCommandHandler handler = this.CreateHandler();

            Scenario result = handler.Handle(command).Result;

            Assert.AreEqual(scenario, result);
        }

        /// <summary>
        /// Creates the handler.
        /// </summary>
        /// <returns></returns>
        private CreateScenarioCommandHandler CreateHandler()
        {
            return new CreateScenarioCommandHandler(this._repositoryMock.Object, this._eventBusMock.Object);
        }
    }
}
