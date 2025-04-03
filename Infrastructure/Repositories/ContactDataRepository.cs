using Domain.Entities.DataContext;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class ContactDataRepository : BaseRepository, IContactDataRepository
{
    public ContactDataRepository(IDataDbContextFactory dataDbContextFactory) : base(dataDbContextFactory)
    {
    }

    public async Task<ContactData> SaveDataAsync(ContactData contactData)
    {
        var addStatus = await _dataDbContext.ContactData.AddAsync(contactData);

        await _dataDbContext.SaveChangesAsync();

        return contactData;
    }
}