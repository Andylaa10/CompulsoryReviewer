using Application;
using Application.Interface;
using Domain;
using Moq;

namespace XUnitTestReviewerProject;

public class ReviewServiceTest
{
    
    [Fact]
    public void CreateReviewService()
    {
        // Arrange 
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();

        // Act
        IReviewService service = new ReviewService(mockRepository.Object);

        // Assert
        Assert.NotNull(service);
        Assert.True(service is ReviewService);
    }

    
    [Theory]
    [InlineData(1,2)]
    [InlineData(2,1)]
    [InlineData(3,0)]
    public void GetNumberOfValidReviewsFromReviewerTest(int reviewer, int expectedResult)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        // Act
        var actual = service.GetNumberOfReviewsFromReviewer(reviewer); 

        // Assert
        Assert.Equal(actual, expectedResult);
        mockRepository.Verify(r => r.GetAll(), Times.Once);

    }

    [Theory]
    [InlineData(-1, "Id must be positive")]
    [InlineData(0, "Id must be positive")]
    public void GetNumberOfInvalidReviewsFromReviewer(int reviewer, string exceptedMessage)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        Action action = () => service.GetNumberOfReviewsFromReviewer(reviewer);
        var ex = Assert.Throws<ArgumentException>(action);

        // Assert
        Assert.Equal(exceptedMessage, ex.Message);
        mockRepository.Verify(r => r.GetAll(), Times.Never);
    }

    [Theory]
    [InlineData(1, 3, 3, 3)]
    [InlineData(1, 1, 3, 2)]
    [InlineData(1, 4, 5, 4.5)]
    public void GetValidAverageRateFromReviewer(int reviewer, int grade, int grade2,  double expectedResult)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = grade, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = grade, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = grade2, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        // Act
        var actual = service.GetAverageRateFromReviewer(reviewer); 

        // Assert
        Assert.Equal(actual, expectedResult);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }
    
    [Theory]
    [InlineData(-1, "Id must be positive")]
    [InlineData(0, "Id must be positive")]
    public void GetInvalidAverageRateFromReviewer(int reviewer, string expectedMessage)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        Action action = () => service.GetAverageRateFromReviewer(reviewer);
        var ex = Assert.Throws<ArgumentException>(action);

        // Assert
        Assert.Equal(expectedMessage, ex.Message);
        mockRepository.Verify(r => r.GetAll(), Times.Never);
    }
    
    [Theory]
    [InlineData(1,2,2)]
    [InlineData(1,1,1)]
    public void GetNumberOfValidRatesByReviewer(int reviewer, int rate, int expectedResult)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = rate, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = rate, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        // Act
        var actual = service.GetNumberOfRatesByReviewer(reviewer, rate); 

        // Assert
        Assert.Equal(actual, expectedResult);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
        
    }
    
    [Theory]
    [InlineData(-1, 2, "input must be positive")]
    [InlineData(0, 2, "input must be positive")]
    [InlineData(1, -1, "input must be positive")]
    [InlineData(1, 0, "input must be positive")]
    public void GetNumberOfInvalidRatesByReviewer(int reviewer, int rate, string expectedMessage)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        Action action = () => service.GetNumberOfRatesByReviewer(reviewer, rate);
        var ex = Assert.Throws<ArgumentException>(action);

        // Assert
        Assert.Equal(expectedMessage, ex.Message);
        mockRepository.Verify(r => r.GetAll(), Times.Never);
    }

    [Theory]
    [InlineData()]
    public void GetNumberOfReviews()
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetNumberOfReviews(movie); 
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetAverageRateOfMovie()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetNumberOfRates()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetMoviesWithHighestNumberOfTopRates()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetMostProductiveReviewers()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTopRatedMovies()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTopMoviesByReviewer()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetReviewersByMovie()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }
    
}