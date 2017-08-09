using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScenarioManagement.API.Application.Commands;
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
        public void Handle_ValidCommand_CreatesScenarioWithCorrectName()
        {
            CreateScenarioCommand command = new CreateScenarioCommand { Name = "Test", SchemaId = Guid.NewGuid() };
            this._repositoryMock
                .Setup(r => r.Add(It.IsAny<Scenario>()))
                .Returns(Task.CompletedTask)
                .Callback<Scenario>(s =>
                {
                    Assert.AreEqual(command.Name, s.Name);
                });

            CreateScenarioCommandHandler handler = this.CreateHandler();

            handler.Handle(command).Wait();
        }

        private CreateScenarioCommandHandler CreateHandler()
        {
            return new CreateScenarioCommandHandler(this._repositoryMock.Object, this._eventBusMock.Object);
        }
    }
}
