using DigitalSolutionPrueba.Application.Services;
using DigitalSolutionPrueba.Domain.Entities;
using DigitalSolutionPrueba.Domain.Interfaces;
using Moq;
using Xunit;

namespace DigitalSolutionPrueba.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void GetUserByUsername_ExistingUser_ReturnsUser()
        {
            // Arrange
            var username = "Alfonso";
            var expectedUser = new User { UserName = username };
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(username))
                               .Returns(expectedUser);

            // Act
            var result = _userService.GetUserByUsername(username);

            // Assert
            Assert.Equal(expectedUser, result);
        }
    }
}
