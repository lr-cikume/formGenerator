using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class SourceDbRepository : ISourceDbRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public SourceDbRepository(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ISourceDb> GetSourceDbByIdAsync(Guid id)
    {
        var result = await _context
            .ConnectionViews
            .FirstOrDefaultAsync(c => c.SecretId == id);

        //validate if result is not null, otherwhise return a new ConnectionStringSource
        if (result == null)
        {
            return new ConnectionStringSource();
        }

        try
        {
            var name = result.DbName;
            var originalDbName = name;
            name = name.Replace("_", "").ToUpper();
            var dataBaseConfiguration = _configuration.GetSection("DATABASESETTINGS");
            var connectionObject = new ConnectionStringSource
            {
                Host = dataBaseConfiguration[$"{name}_HOST"],
                DbName = originalDbName,
                Username = dataBaseConfiguration[$"{name}_USER"],
                Password = dataBaseConfiguration[$"{name}_PASSWORD"]
            };
            return connectionObject;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            throw new ApplicationException("An error occurred while getting source db.", ex);
        }
    }

    public async Task<string> GetUuIdByNameAsync(string dbName)
    {
        var result = await _context
            .ConnectionViews
            .FirstOrDefaultAsync(c => c.DbName == dbName);
        
        return result?.SecretId.ToString() ?? string.Empty;
    }

    public async Task<ISourceDb> GetSourceDbByNameAsync(string name)
    {
        var result = await _context
            .ConnectionViews
            .FirstOrDefaultAsync(c => c.DbName == name);

        //validate if result is not null, otherwhise return a new ConnectionStringSource
        if (result == null)
        {
            return new ConnectionStringSource();
        }

        try
        {
            var originalDbName = name;
            name = name.Replace("_", "").ToUpper();
            var dataBaseConfiguration = _configuration.GetSection("DATABASESETTINGS");
            var connectionObject = new ConnectionStringSource
            {
                Host = dataBaseConfiguration[$"{name}_HOST"],
                DbName = originalDbName,
                Username = dataBaseConfiguration[$"{name}_USER"],
                Password = dataBaseConfiguration[$"{name}_PASSWORD"]
            };
            return connectionObject;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            throw new ApplicationException("An error occurred while getting source db.", ex);
        }
    }
}