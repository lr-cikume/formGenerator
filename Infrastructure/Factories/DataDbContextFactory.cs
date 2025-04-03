using Domain.Interfaces;
using Domain.Interfaces.Factories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Factories;

public class DataDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>, IDataDbContextFactory
{
    
    public DataDbContext CreateDbContext(string[] args)
    {
        try
        {
            var dbContext = new DataDbContext(args[0]);
            dbContext.Database.OpenConnection();
            dbContext.Database.CloseConnection();
            return dbContext;
        }
        catch (Exception ex)
        {
            // Manejar la excepción según sea necesario
            throw new InvalidOperationException("No se pudo establecer la conexión a la base de datos.", ex);
        }
    }
    
    IDataConnection IDataDbContextFactory.CreateDbContext(string[] args)
    {
        return CreateDbContext(args);
    }
}