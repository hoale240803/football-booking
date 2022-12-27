using System.Linq.Expressions;

namespace FootballBooking.Infrastructure.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Expression { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}