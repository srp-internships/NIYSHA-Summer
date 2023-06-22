namespace TestNinja.Mocking
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}