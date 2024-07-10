namespace SalesApplication.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ISalesRecordRepository SalesRecords { get; }
        Task<int> CompleteAsync();
    }
}
