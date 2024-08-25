using Xunit;
using Moq;
using LoanApp.Application.Dtos;
using LoanApp.Application.Services;
using LoanApp.Core.Interfaces;
using LoanApp.Core.Models;
using System.Threading.Tasks;
using LoanApp.Core.Events;
using LoanApp.Infrastructure.Data.Repositories;

namespace LoanApp.Tests.Services
{
    public class LoanApplicationManagerTests
    {
        private readonly Mock<ILoanApplicationRepository> _mockLoanApplicationRepository;
        private readonly Mock<IEventBus> _mockEventBus;
        private readonly LoanApplicationManager _manager;

        public LoanApplicationManagerTests()
        {
            _mockLoanApplicationRepository = new Mock<ILoanApplicationRepository>();
            _mockEventBus = new Mock<IEventBus>();
            _manager = new LoanApplicationManager(_mockLoanApplicationRepository.Object, _mockEventBus.Object);
        }

        [Fact]
        public async Task SubmitLoanApplicationAsync_ReturnsTrue_WhenLoanSubmissionIsSuccessful()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationDto
            {
                CustomerId = 67,
                Amount = 10000,
                Status = "Pending"
            };

            _mockLoanApplicationRepository.Setup(repo => repo.AddAsync(It.IsAny<LoanApplication>()))
                                          .Returns(Task.CompletedTask);

            _mockEventBus.Setup(bus => bus.Publish(It.IsAny<LoanApplicationSubmittedEvent>()));

            // Act
            var result = await _manager.SubmitLoanApplicationAsync(loanApplicationDto);

            // Assert
            Assert.True(result);
            _mockLoanApplicationRepository.Verify(repo => repo.AddAsync(It.IsAny<LoanApplication>()), Times.Once);
            _mockEventBus.Verify(bus => bus.Publish(It.IsAny<LoanApplicationSubmittedEvent>()), Times.Once);
        }

        [Fact]
        public async Task SubmitLoanApplicationAsync_ReturnsFalse_WhenLoanSubmissionFails()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationDto
            {
                CustomerId = 45,
                Amount = 10000,
                Status = "Submitted"
            };

            _mockLoanApplicationRepository.Setup(repo => repo.AddAsync(It.IsAny<LoanApplication>()))
                                          .ThrowsAsync(new System.Exception("Database error"));

            // Act
            var result = await _manager.SubmitLoanApplicationAsync(loanApplicationDto);

            // Assert
            Assert.False(result);
            _mockLoanApplicationRepository.Verify(repo => repo.AddAsync(It.IsAny<LoanApplication>()), Times.Once);
            _mockEventBus.Verify(bus => bus.Publish(It.IsAny<LoanApplicationSubmittedEvent>()), Times.Never);
        }

        [Fact]
        public async Task SubmitLoanApplicationAsync_ReturnsFalse_WhenEventBusThrowsException()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationDto
            {
                CustomerId = 43,
                Amount = 10000,
                Status = "Success"
            };

            _mockLoanApplicationRepository.Setup(repo => repo.AddAsync(It.IsAny<LoanApplication>()))
                                          .Returns(Task.CompletedTask);

            _mockEventBus.Setup(bus => bus.Publish(It.IsAny<LoanApplicationSubmittedEvent>()))
                         .Throws(new System.Exception("EventBus error"));

            // Act
            var result = await _manager.SubmitLoanApplicationAsync(loanApplicationDto);

            // Assert
            Assert.False(result);
            _mockLoanApplicationRepository.Verify(repo => repo.AddAsync(It.IsAny<LoanApplication>()), Times.Once);
            _mockEventBus.Verify(bus => bus.Publish(It.IsAny<LoanApplicationSubmittedEvent>()), Times.Once);
        }
    }
}