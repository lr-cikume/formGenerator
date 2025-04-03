namespace Domain.Entities;

public class ConnectionView
{
    public Guid SecretId { get; set; }
    public string DbName { get; set; }
    public bool IsActive { get; set; }
}