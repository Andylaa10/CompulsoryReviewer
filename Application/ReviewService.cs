using Application.Interface;

namespace Application;

public class ReviewService : IReviewService
{
    private IReviewRepository _repository;
    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }

    public int GetNumberOfReviewsFromReviewer(int reviewer)
    {
        if (reviewer < 1) throw new ArgumentException("Id must be positive");
            var reviews = _repository.GetAll().Where(r => r.Reviewer == reviewer).Select(r => r.Reviewer);

        return reviews.Count();
    }

    public double GetAverageRateFromReviewer(int reviewer)
    { 
        if (reviewer < 1) throw new ArgumentException("Id must be positive");
        var reviews = _repository.GetAll().Where(r => r.Reviewer == reviewer).Select(r => r.Grade);

        return reviews.Average();
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        if (reviewer < 1 || rate < 1) throw new ArgumentException("input must be positive");
        var reviews = _repository.GetAll().Where(r => r.Reviewer == reviewer && r.Grade == rate).Select(r => r.Reviewer);

        return reviews.Count();
    }

    public int GetNumberOfReviews(int movie)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateOfMovie(int movie)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        throw new NotImplementedException();
    }

    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewersByMovie(int movie)
    {
        throw new NotImplementedException();
    }
}