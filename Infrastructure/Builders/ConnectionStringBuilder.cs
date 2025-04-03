using Domain.Interfaces.Builders;

namespace Infrastructure.Builders;

public class ConnectionStringBuilder : IConnectionStringBuilder
{
    private Dictionary<string, string> _parameters = new();
    private string _connectionString= string.Empty;
    
    public IConnectionStringBuilder SetServer(string server)
    {
        if (!string.IsNullOrEmpty(server))
            _parameters["Server"] = server;
        return this;
    }

    public IConnectionStringBuilder SetDatabase(string database)
    {
        if (!string.IsNullOrEmpty(database))
            _parameters["Database"] = database;
        return this;
    }

    public IConnectionStringBuilder SetUser(string user)
    {
        if (!string.IsNullOrEmpty(user))
            _parameters["User Id"] = user;
        return this;
    }

    public IConnectionStringBuilder SetPassword(string password)
    {
        if (!string.IsNullOrEmpty(password))
            _parameters["Password"] = password;
        return this;
    }

    public IConnectionStringBuilder SetPort(int port)
    {
        
        if (port > 0)
            _parameters["Server"] = $"{_parameters["Server"]},{port}";
        return this;
    }
    
    public IConnectionStringBuilder SetSslMode(string sslMode)
    {
        if (!string.IsNullOrEmpty(sslMode))
            _parameters["SslMode"] = sslMode;
        return this;
    }
    
    public IConnectionStringBuilder SetIntegratedSecurity(bool integratedSecurity)
    {
        _parameters["Integrated Security"] = integratedSecurity ? "true" : "false";
        return this;
    }

    public string Build()
    {
        _connectionString = string.Join(";", _parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return _connectionString;
        //return _connectionString+";Encrypt=True;TrustServerCertificate=True;";
    }

    public ConnectionStringBuilder Reset()
    {
        _parameters.Clear();
        _connectionString = string.Empty;
        return this;
    }
    
    public string GetCurrentConnectionString()
    {
        return _connectionString;
    }
}