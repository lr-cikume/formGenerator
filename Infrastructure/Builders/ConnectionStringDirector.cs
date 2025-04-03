using Domain.Interfaces;
using Domain.Interfaces.Builders;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Builders
{
    /// <summary>
    /// Director to orchestrate the creation of database connection string
    /// </summary>
    public class ConnectionStringDirector : IConnectionStringDirector
    {
        private readonly ISourceDbRepository _repository;
        private readonly IConnectionStringBuilder _connectionStringBuilder;

        public ConnectionStringDirector(ISourceDbRepository repository, IConnectionStringBuilder connectionStringBuilder)
        {
            _repository = repository;
            _connectionStringBuilder = connectionStringBuilder;
        }

        /// <inheritdoc/>
        public async Task<string> ConstructTenantDbConnection(Guid tenantId)
        {
            var sourceDb = await _repository.GetSourceDbByIdAsync(tenantId);
            
            var connection = BuildTenantConnection(sourceDb);

            return connection;
        }

        /// <summary>
        /// Returns a database connection string with the information from <see cref="ISourceDb"/> 
        /// </summary>
        private string BuildTenantConnection(ISourceDb sourceDb)
        {
            try
            {
                var connectionStringBuilder = _connectionStringBuilder;
                if (!string.IsNullOrEmpty(sourceDb.Host))
                    connectionStringBuilder = connectionStringBuilder.SetServer(sourceDb.Host);

                if (!string.IsNullOrEmpty(sourceDb.DbName))
                    connectionStringBuilder = connectionStringBuilder.SetDatabase(sourceDb.DbName);

                if (!string.IsNullOrEmpty(sourceDb.Username))
                    connectionStringBuilder = connectionStringBuilder.SetUser(sourceDb.Username);

                if (!string.IsNullOrEmpty(sourceDb.Password))
                    connectionStringBuilder = connectionStringBuilder.SetPassword(sourceDb.Password);

                if (sourceDb.Port > 0)
                    connectionStringBuilder = connectionStringBuilder.SetPort(sourceDb.Port);

                if (!string.IsNullOrEmpty(sourceDb.SslMode))
                    connectionStringBuilder = connectionStringBuilder.SetSslMode(sourceDb.SslMode);

                connectionStringBuilder = connectionStringBuilder.SetIntegratedSecurity(sourceDb.IntegratedSecurity);
                return connectionStringBuilder.Build();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("An error occurred while getting form elements.", ex);
            }
        }
    }
}
