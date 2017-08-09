using System;
using System.Collections.Generic;
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
    [TestClass]
    public class CreateScenarioCommandHandlerTests
    {
        private Mock<IScenarioRepository> _repositoryMock;

        private Mock<IEventBus> _eventBusMock;

        [TestInitialize]
        public void Initialize()
        {
            this._repositoryMock = new Mock<IScenarioRepository>();
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
        public void Handle_ValidCommand_AddsScenarioWithCorrectNameToRepository()
        {
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test" };
            this._repositoryMock
                .Setup(r => r.Add(It.IsAny<Scenario>()))
                .Returns(Task.CompletedTask);
            CreateScenarioCommandHandler handler = this.CreateHandler();

            handler.Handle(command).Wait();

            this._repositoryMock.Verify(r => r.Add(It.Is<Scenario>(s => s.Name == command.Name)), Times.Once());
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
        public void Handle_ValidCommand_PublishesEventWithCorrectData()
        {
            Guid scenarioId = Guid.Empty;
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test" };
            this._repositoryMock
                .Setup(r => r.Add(It.IsAny<Scenario>()))
                .Returns(Task.CompletedTask)
                .Callback<Scenario>(scenario =>
                {
                    scenarioId = scenario.Id;
                });
            CreateScenarioCommandHandler handler = this.CreateHandler();

            handler.Handle(command).Wait();

            this._eventBusMock.Verify(b => b.Publish(It.Is<ScenarioCreatedEvent>(e => e.Name == command.Name && e.ScenarioId == scenarioId)));
        }

        [TestMethod]
        public void Handle_ValidCommand_ReturnsSavedScenario()
        {
            Scenario scenario = null;
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test" };
            this._repositoryMock
                .Setup(r => r.Add(It.IsAny<Scenario>()))
                .Returns(Task.CompletedTask)
                .Callback<Scenario>(s =>
                {
                    scenario = s;
                });
            CreateScenarioCommandHandler handler = this.CreateHandler();

            Scenario result = handler.Handle(command).Result;

            Assert.AreEqual(scenario, result);
        }

        private CreateScenarioCommandHandler CreateHandler()
        {
            return new CreateScenarioCommandHandler(this._repositoryMock.Object, this._eventBusMock.Object);
        }
    }
}
