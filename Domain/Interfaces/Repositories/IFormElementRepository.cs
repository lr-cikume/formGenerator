using Domain.Entities.Dto;

namespace Domain.Interfaces.Repositories;

public interface IFormElementRepository
{
    /// <summary>
    /// Returns the list of FormElements that are configured for the contact form
    /// </summary>
    Task<List<FormElement>> GetElements();

    IDataConnection SetDataConnection(string connectionString);
}