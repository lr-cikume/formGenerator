namespace Domain.Interfaces.Factories;

public interface IDataDbContextFactory
{
    IDataConnection CreateDbContext(string[] args);
}