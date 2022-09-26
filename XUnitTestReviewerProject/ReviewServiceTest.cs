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
        mockRepository.Setup(r => r.GetNumberOfReviewsFromReviewer(reviewer)).Returns(fakeRepo.Length);

        // Act
        var actual = service.GetNumberOfReviewsFromReviewer(reviewer); 

        // Assert
        Assert.Equal(actual, expectedResult);

    }

    [Fact]
    public void GetNumberOfInvalidReviewsFromReviewer()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetAverageRateFromReviewer()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }
    
    [Fact]
    public void GetValidAverageRateFromReviewer()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }
    
    [Fact]
    public void GetInvalidAverageRateFromReviewer()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }
    
    [Fact]
    public void GetNumberOfRatesByReviewer()
    {
        // Arrange 
        
        // Act
        
        // Assert
    }
    
    [Fact]
    public void GetNumberOfReviews()
    {
        // Arrange 
        
        // Act
        
        // Assert
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