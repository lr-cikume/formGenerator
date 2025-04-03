namespace Domain.Interfaces.Builders;

/// <summary>
/// Director contract to orchestrate the creation of database connection string
/// </summary>
public interface IConnectionStringDirector
{
    /// <summary>
    /// Builds the database connection string for the tenat
    /// </summary>
    Task<string> ConstructTenantDbConnection(Guid tenantId);
}