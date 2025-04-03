namespace Domain.Interfaces.Builders;

public interface IConnectionStringBuilder
{
    IConnectionStringBuilder SetServer(string server);
    IConnectionStringBuilder SetDatabase(string database);
    IConnectionStringBuilder SetUser(string user);
    IConnectionStringBuilder SetPassword(string password);
    IConnectionStringBuilder SetPort(int port);
    IConnectionStringBuilder SetSslMode(string sslMode);
    IConnectionStringBuilder SetIntegratedSecurity(bool integratedSecurity);
    string Build();
}