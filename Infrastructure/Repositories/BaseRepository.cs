using Domain.Interfaces;
using Domain.Interfaces.Factories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BaseRepository
    {
        private readonly IDataDbContextFactory _dataDbContextFactory;
        protected DataDbContext _dataDbContext;

        public BaseRepository(IDataDbContextFactory dataDbContextFactory)
        {
            _dataDbContextFactory = dataDbContextFactory;
        }

        public IDataConnection SetDataConnection(string connectionString)
        {
            _dataDbContext = (DataDbContext)_dataDbContextFactory.CreateDbContext([connectionString]);
            return _dataDbContext;
        }
    }
}
