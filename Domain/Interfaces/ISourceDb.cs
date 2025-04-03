namespace Domain.Interfaces;

public interface ISourceDb
{
    Guid Id { get; set; }
    string Host { get; set; }
    int Port { get; set; }
    string Username { get; set; }
    string? Password { get; set; }
    string DbName { get; set; }
    string? SslMode { get; set; }
    bool IntegratedSecurity { get; set; }
}