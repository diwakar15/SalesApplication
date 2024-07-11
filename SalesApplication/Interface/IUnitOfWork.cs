namespace SalesApplication.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ISalesRecordRepository1 SalesRecords { get; }
        Task<int> CompleteAsync();
    }
}
