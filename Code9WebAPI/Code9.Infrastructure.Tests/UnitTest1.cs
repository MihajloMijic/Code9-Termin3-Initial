using AutoFixture;
using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Code9.Infrastructure.Repositories;
using FluentAssertions;
using Moq;

namespace Code9.Infrastructure.Tests
{
    public class RepositoryTests
    {
        private CinemaRepository _cinemaRepository { get; set; }

        private MovieRepository _movieRepository { get; set; }

        private IFixture _fixture { get; set; }

        private Mock<IDbContext> _dbContext { get; set; }

        private MockRepository _mockRepository { get; set; }
        
        public RepositoryTests()
        {
            _fixture = new Fixture();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _dbContext = _mockRepository.Create<IDbContext>();
            _cinemaRepository = new CinemaRepository(_dbContext.Object);
        }

        [Fact]
        public async void GetAllCinema_ReturnOK()
        {
            //Arrange
            var cinemas = _fixture
                .Build<Cinema>()
                .Without(x => x.Cities)
                .CreateMany(3)
                .ToList();
            
            _dbContext.Setup(x => x.GetAllCinema()).Returns(Task.FromResult(cinemas));

            //Act
            var result =await  _cinemaRepository.GetAllCinema();

            //Assert
            result.Count.Should().BeGreaterThanOrEqualTo(cinemas.Count);


        }
    }
}