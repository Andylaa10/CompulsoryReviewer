using System.Collections.Immutable;
using System.Security.AccessControl;
using Application.Interface;
using Domain;

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
        if (reviewer < 1) throw new ArgumentException("ID must be positive");
        if (rate is < 1 or > 5) throw new ArgumentException("Grade must be 1-5");
        var reviews = _repository.GetAll().Where(r => r.Reviewer == reviewer && r.Grade == rate).Select(r => r.Reviewer);

        return reviews.Count();
    }

    public int GetNumberOfReviews(int movie)
    {
        if (movie < 1) throw new ArgumentException("ID must be positive");
            var reviews = _repository.GetAll().Where(r => r.Movie == movie).Select(r => r.Movie);
        return reviews.Count();
    }

    public double GetAverageRateOfMovie(int movie)
    {
        if (movie < 1) throw new ArgumentException("ID must be positive");
        var reviews = _repository.GetAll().Where(r => r.Movie == movie).Select(r => r.Grade);
        return reviews.Average();
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        if (movie < 1) throw new ArgumentException("ID must be positive");
        if (rate is < 1 or > 5) throw new ArgumentException("Grade must be 1-5");
        var reviews = _repository.GetAll().Where(r => r.Movie == movie && r.Grade == rate).Select(r => r.Grade);
        return reviews.Count();
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        Dictionary<int, int> ids = new Dictionary<int, int>();
        
        foreach (var review in _repository.GetAll())
        {
            if (review.Grade == 5)
            {
                if (ids.ContainsKey(review.Movie))
                {
                    ids[review.Movie]++;
                }
                else
                {
                    ids.Add(review.Movie, 1);
                }
            }
        }
        
        List<int> mostTopRates = new List<int>();
        int highest = 0;

        foreach (var review in ids)
        {
            int count = review.Value;
            int id = review.Key;

            if (count > highest)
            {
                highest = count;
                mostTopRates.Clear();
                mostTopRates.Add(id);
            } 
            else if (count == highest)
            {
                mostTopRates.Add(id);
            }
        }

        return mostTopRates;
    }

    public List<int> GetMostProductiveReviewers()
    {
        Dictionary<int, int> ids = new Dictionary<int, int>();
        
        foreach (var review in _repository.GetAll())
        {
            if (ids.ContainsKey(review.Reviewer))
            {
                ids[review.Reviewer]++;
            }
            else
            {
                ids.Add(review.Reviewer, 1);
            }
        }

        List<int> mostProductive = new List<int>();
        int highest = 0;

        foreach (var review in ids)
        {
            int count = review.Value;
            int id = review.Key;

            if (count > highest)
            {
                highest = count;
                mostProductive.Clear();
                mostProductive.Add(id);
            } 
            else if (count == highest)
            {
                mostProductive.Add(id);
            }
        }

        return mostProductive;
    }

    public List<int> GetTopRatedMovies(int amount)
    {

        var movieId = new Dictionary<int, double>();

        foreach (BEReview review in _repository.GetAll())
        {
            if(!movieId.ContainsKey(review.Movie))
            movieId.Add(review.Movie, GetAverageRateOfMovie(review.Movie));
        }

        var topRatedMovies = movieId.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        return topRatedMovies.Keys.Take(amount).ToList();
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewersByMovie(int movie)
    {
        var reviewers = _repository.GetAll().Where(r => r.Movie == movie).OrderByDescending(r => r.Grade).ThenByDescending(r => r.ReviewDate)
            .Select(r => r.Reviewer).ToList();
        return reviewers;
    }
}