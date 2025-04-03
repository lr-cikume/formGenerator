using Domain.Entities.DataContext;
using Domain.Interfaces.Builders;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ContactDataService : IContactDataService
    {
        private readonly IConnectionStringDirector _connectionStringDirector;
        private readonly IContactDataRepository _contactDataRepository;

        public ContactDataService(IConnectionStringDirector connectionStringDirector, IContactDataRepository contactDataRepository)
        {
            _connectionStringDirector = connectionStringDirector;
            _contactDataRepository = contactDataRepository;
        }

        public async Task<ContactData> SaveDataAsync(ContactData contactData, Guid tenantId)
        {
            var connectionString = await _connectionStringDirector.ConstructTenantDbConnection(tenantId);

            _contactDataRepository.SetDataConnection(connectionString);

            return await _contactDataRepository.SaveDataAsync(contactData);
        }
    }
}
