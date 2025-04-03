using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;
public class ConnectionStringSource : ISourceDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("host")]
    public string Host { get; set; }
    [Column("port")]
    public int Port { get; set; }
    [Column("username")]
    public string Username { get; set; }
    [Column("password")]
    public string? Password { get; set; }
    [Column("dbname")]
    public string DbName { get; set; }
    [Column("sslmode")]
    public string? SslMode { get; set; }
    [Column("integratedsecurity")]
    public bool IntegratedSecurity { get; set; }
}