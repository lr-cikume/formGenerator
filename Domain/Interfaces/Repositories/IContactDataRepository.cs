using Domain.Entities.DataContext;

namespace Domain.Interfaces.Repositories;

public interface IContactDataRepository
{
    Task<ContactData> SaveDataAsync(ContactData contactData);

    IDataConnection SetDataConnection(string connectionString);
}