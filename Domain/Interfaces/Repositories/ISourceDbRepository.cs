namespace Domain.Interfaces.Repositories;

public interface ISourceDbRepository
{
    Task<ISourceDb> GetSourceDbByIdAsync(Guid tenantId);
    Task<string> GetUuIdByNameAsync(string dbName);
}