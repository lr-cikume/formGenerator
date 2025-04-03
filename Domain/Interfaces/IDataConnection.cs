using Domain.Entities;

namespace Domain.Interfaces;

public interface IDataConnection
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}