using Domain.Entities.DataContext;

namespace Domain.Interfaces.Services;

public interface IContactDataService
{
    Task<ContactData> SaveDataAsync(ContactData contactData, Guid tenantId);
}