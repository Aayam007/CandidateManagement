using CandidateManagement.Application.DTOs;
using CandidateManagement.Application.Services;
using CandidateManagement.Domain.Entities;
using CandidateManagement.Domain.IRepositories;
using Moq;
using NUnit.Framework;

namespace CandidateManagement.Tests
{
    public class CandidateServiceTests
    {
        private Mock<ICandidateRepository> _candidateRepositoryMock;
        private CandidateService _candidateService;

        [SetUp]
        public void Setup()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object);
        }

        [Test]
        public async Task AddOrUpdateCandidateAsync_CandidateDoesNotExist_ShouldCreateCandidate()
        {
            // Arrange
            var candidateDto = new CandidateDto { Email = "test@example.com", FirstName = "John", LastName = "Doe" };
            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(candidateDto.Email))
                .ReturnsAsync((Candidate)null);

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            Assert.That(result, Is.EqualTo("Candidate added successfully."));
            _candidateRepositoryMock.Verify(repo => repo.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }

        [Test]
        public async Task AddOrUpdateCandidateAsync_CandidateExists_ShouldUpdateCandidate()
        {
            // Arrange
            var existingCandidate = new Candidate { Email = "test@example.com", FirstName = "John", LastName = "Doe" };
            var candidateDto = new CandidateDto { Email = "test@example.com", FirstName = "Jane", LastName = "Doe" };
            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(candidateDto.Email))
                .ReturnsAsync(existingCandidate); 

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            Assert.That(result, Is.EqualTo("Candidate added or updated successfully."));
            _candidateRepositoryMock.Verify(repo => repo.UpdateCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }
    }
}
