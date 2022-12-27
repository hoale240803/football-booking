using FootballBooking.Infrastructure.Specification;
using System.Linq.Expressions;

namespace FootballBooking.Infrastructure.Repository
{
    public class Specification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Expression { get; }
        public List<Expression<Func<TEntity, object>>> Includes { get; }

        public Specification(Expression<Func<TEntity, bool>> expression)
        {
            Expression = expression;
            Includes = new();
        }
    }
}