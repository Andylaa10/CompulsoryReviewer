using Domain;

namespace Application.Interface;

public interface IReviewRepository
{
    BEReview[] GetAll();
}