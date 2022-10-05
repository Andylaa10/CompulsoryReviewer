using System.Reflection.Metadata;
using Application;
using Application.Interface;
using Domain;
using Moq;

namespace XUnitTestReviewerProject;

public class ReviewServiceTest
{

    #region GetMostProductiveReviewers
    static IEnumerable<Object[]> GetMostProductiveReviewers_TestCases()
    {
        yield return new Object[]
        {
            new BEReview[]
            {
            },
            new List<int>()
        };
        // 1 Top-reviewer => list(1)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>(){1}
        };
        
        // 2 Top-reviewers => list(1,2)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 3, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 4, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 5, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>(){1, 2}
        };
    }
    

    #endregion

    #region GetMoviesWithHighestNumberOfTopRates 
    static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRates_TestCases()
    {
        yield return new Object[]
        {
            new BEReview[]
            {
            },
            new List<int>()
        };
        // 1 Most Top-Rated Movie => list(1)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = new DateTime() }
            },
            new List<int>(){2}
        };
        
        // Most Top-Rated Movie => list(1,2)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 3, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 4, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 5, Grade = 5, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 6, Grade = 5, ReviewDate = new DateTime() }
            },
            new List<int>(){5, 6}
        };
    }
    

    #endregion

    //TO-DO 
    #region GetTopRatedMoviesTest
    static IEnumerable<Object[]> GetTopRatedMoviesTest_TestCases()
    {
        yield return new Object[]
        {
            new BEReview[]
            {
            },
            new List<int>()
        };
        // 1 Toprated-movie => list(2, 1)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 4, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>() { 2, 1 }
        };

        // 3 Toprated-movies => list(3, 2, 1)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 1, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 3, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 2, Grade = 4, ReviewDate = new DateTime() }
            },
            new List<int>() { 3, 2, 1 }
        };
    }


    #endregion
    
    //TO-DO
    #region GetTopMoviesByReviewerTest
    static IEnumerable<Object[]> GetTopMoviesByReviewerTest_TestCases()
    {
        yield return new Object[]
        {
            new BEReview[]
            {
            },
            new List<int>()
        };
        // 1 Top-reviewer => list(1)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 3, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>() { 1 }
        };

        // 2 Top-reviewers => list(1,2)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 3, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 2, Grade = 4, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 3, Grade = 5, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 4, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 5, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>() {3, 2, 1}
        };
    }


    #endregion
    
    //TO-DO
    #region GetReviewersByMovieTest
    static IEnumerable<Object[]> GetReviewersByMovieTest_TestCases()
    {
        yield return new Object[]
        {
            new BEReview[]
            {
            },
            new List<int>()
        };
        // Gets reviewer 2 based on movie id => list(2)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 3, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>() {1}
        };

        // Gets reviewer 1, 3, 2 based on movie id => list(1,2)
        // Reviewer 1 is first because of highest rate
        // Reviewer 3 is second because of rate and earlier date
        // Reviewer 2 is third
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 1, Movie = 3, Grade = 5, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 3, Grade = 3, ReviewDate = DateTime.Now.AddMilliseconds(-1) },
                new BEReview() { Reviewer = 2, Movie = 3, Grade = 3, ReviewDate = new DateTime() },
                new BEReview() { Reviewer = 3, Movie = 5, Grade = 3, ReviewDate = new DateTime() }
            },
            new List<int>() { 1, 3, 2 }
        };
    }
    #endregion
    
    
    [Fact]
    public void CreateReviewServiceTest()
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
    [InlineData(-1, "Id must be positive")] // Throws an argument exception if reviewer id is less than 1
    [InlineData(0, "Id must be positive")]
    public void GetNumberOfInvalidReviewsFromReviewerTest(int reviewer, string exceptedMessage)
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
    public void GetValidAverageRateFromReviewerTest(int reviewer, int grade, int grade2,  double expectedResult)
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
    [InlineData(-1, "Id must be positive")] // Throws an argument exception if reviewer id is less than 1
    [InlineData(0, "Id must be positive")]
    public void GetInvalidAverageRateFromReviewerTest(int reviewer, string expectedMessage)
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
    public void GetNumberOfValidRatesByReviewerTest(int reviewer, int rate, int expectedResult)
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
    [InlineData(-1, 2, "ID must be positive")] // Throws an argument exception if reviewer id is less than 1
    [InlineData(0, 2, "ID must be positive")] // Throws an argument exception if reviewer id is less than 1
    [InlineData(1, 0, "Grade must be 1-5")] // Throws an argument exception if the rate is not between 1-5
    [InlineData(1, 6, "Grade must be 1-5")] // Throws an argument exception if the rate is not between 1-5
    public void GetNumberOfInvalidRatesByReviewerTest(int reviewer, int rate, string expectedMessage)
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
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void GetValidNumberOfReviewsTest(int movie, int expectedResult)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 3, Movie = 3, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 2, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetNumberOfReviews(movie); 
        
        // Assert
        Assert.Equal(expectedResult, actual);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }
    
    [Theory]
    [InlineData(-1, "ID must be positive")] // Throws an argument exception if movie id is less than 1
    [InlineData(0, "ID must be positive")] // Throws an argument exception if movie id is less than 1
    public void GetInvalidNumberOfReviewsTest(int movie, string expectedResult)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = movie, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = movie, Grade = 2, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        Action action = () => service.GetNumberOfReviews(movie);
        var ex = Assert.Throws<ArgumentException>(action);
        
        // Assert
        Assert.Equal(expectedResult, ex.Message);
        mockRepository.Verify(r => r.GetAll(), Times.Never);
    }

    [Theory]
    [InlineData(1,1.5)]
    [InlineData(3,4)]
    public void GetValidAverageRateOfMovieTest(int movie, double expectedResult)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 1, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 3, Movie = 3, Grade = 4, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = new DateTime() },
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetAverageRateOfMovie(movie);

        // Assert
        Assert.Equal(expectedResult, actual);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }
    
    [Theory]
    [InlineData(0,"ID must be positive")] // Throws an argument exception if movie id is less than 1
    [InlineData(-1,"ID must be positive")] // Throws an argument exception if movie id is less than 1
    public void GetInvalidAverageRateOfMovieTest(int movie, string expectedResult)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = movie, Grade = 1, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        Action action = () => service.GetAverageRateOfMovie(movie);
        var ex = Assert.Throws<ArgumentException>(action);
        
        // Assert
        Assert.Equal(expectedResult, ex.Message);
        mockRepository.Verify(r => r.GetAll(), Times.Never);
    }

    [Theory]
    [InlineData(1, 2, 1)] // Movie ID 1 has received rating 2 once
    [InlineData(2, 3, 2)] // Movie ID 2 has received rating 3 twice
    public void GetValidNumberOfRatesTest(int movie, int rating, int expectedResult)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 2, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime() },
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetNumberOfRates(movie, rating);

        // Assert
        Assert.Equal(expectedResult, actual);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }
    
    [Theory]
    [InlineData(0, 2, "ID must be positive")] // Checks if ID of the movie is 0 or below 
    [InlineData(-1, 3, "ID must be positive")] // Checks if ID of the movie is 0 or below
    [InlineData(1, 0, "Grade must be 1-5")] // Checks if the given grade is 1-5
    [InlineData(2, 6, "Grade must be 1-5")] // Checks if the given grade is 1-5
    public void GetInvalidNumberOfRatesTest(int movie, int rating, string expectedResult)
    {
        // Arrange 
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = movie, Grade = rating, ReviewDate = new DateTime() }
        };
        
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        Action action = () => service.GetNumberOfRates(movie, rating);
        var ex = Assert.Throws<ArgumentException>(action);

        // Assert
        Assert.Equal(expectedResult, ex.Message);
        mockRepository.Verify(r => r.GetAll(), Times.Never);
    }
    
    [Theory]
    [MemberData(nameof(GetMoviesWithHighestNumberOfTopRates_TestCases))]
    public void GetMoviesWithHighestNumberOfTopRatesTest(BEReview[] data, List<int> expectedResult)
    {
        var fakeRepo = data;

        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetMoviesWithHighestNumberOfTopRates();

        // Assert
        Assert.True(Enumerable.SequenceEqual(expectedResult, actual));
    }

    [Theory]
    [MemberData(nameof(GetMostProductiveReviewers_TestCases))]
    public void GetMostProductiveReviewersTest(BEReview[] data, List<int> expectedResult)
    {
        var fakeRepo = data;

        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetMostProductiveReviewers();

        // Assert
        Assert.True(Enumerable.SequenceEqual(expectedResult, actual));
    }

    [Theory]
    [MemberData(nameof(GetTopRatedMoviesTest_TestCases))]
    public void GetTopRatedMoviesTest(BEReview[] data, List<int> expectedresult)
    {
        // Arrange 
        var fakeRepo = data;

        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetTopRatedMovies(3);

        // Assert
        Assert.Equal(expectedresult, actual);
        Assert.True(Enumerable.SequenceEqual(expectedresult, actual));
    }

    [Theory]
    [MemberData(nameof(GetTopMoviesByReviewerTest_TestCases))]
    public void GetTopMoviesByReviewerTest(BEReview[] data, List<int> expectedResult)
    {
        var fakeRepo = data;

        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetTopMoviesByReviewer(3);

        // Assert
        Assert.Equal(expectedResult, actual);
        Assert.True(Enumerable.SequenceEqual(expectedResult, actual));
    }

    [Theory]
    [MemberData(nameof(GetReviewersByMovieTest_TestCases))]
    public void GetReviewersByMovieTest(BEReview[] data, List<int> expectedResult)
    {
        var fakeRepo = data;

        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewService service = new ReviewService(mockRepository.Object);
        mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Act
        var actual = service.GetReviewersByMovie(3);

        // Assert
        Assert.Equal(expectedResult, actual);
        Assert.True(Enumerable.SequenceEqual(expectedResult, actual));
    }
    
}