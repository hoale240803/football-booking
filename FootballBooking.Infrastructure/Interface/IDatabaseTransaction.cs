namespace FootballBooking.Infrastructure.Interface
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        Task CommitAsync();

        void Rollback();

        Task RollbackAsync();
    }
}