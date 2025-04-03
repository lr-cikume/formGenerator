using Domain.Entities.DataContext.SpResults;
using Domain.Entities.Dto;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FormElementRepository : BaseRepository, IFormElementRepository
{    
    public FormElementRepository(IDataDbContextFactory dataDbContextFactory): base(dataDbContextFactory)
    {
    }

    /// <inheritdoc/>
    public async Task<List<FormElement>> GetElements()
    {
        //Gets the input fields 
        var inputFieldsQuery = from formDesign in _dataDbContext.FormDesigns
                    join inputFields in _dataDbContext.InputFields
                        on formDesign.Id equals inputFields.FormDesignId
                    //By now we expect to be only 1 registry in the whole FormDesigns table, but if this change uncomment and update this line
                    //where formDesign.Id == Guid.Empty
                    select inputFields;

        var formElementFromInputFieldsQuery = inputFieldsQuery.Include(e => e.InputType)
            .Include(e => e.Field)
            .Select(e => new FormElement
            {
                DisplayText = e.DisplayName,
                Position = e.DisplayOrder,
                //Lets assume that e.InputField.NameInput will be the same as e.Field.FieldName,
                IdElement = e.NameInput,                
                Required = e.Required,
                MaxLength = e.MaxLenght,
                ElementTypeString = e.InputType.Input,
                ElementFieldType = e.Field.FieldType,
                DataSource = e.DataSource,
                PlaceHolder = e.Description,
            });
        
        var result = await formElementFromInputFieldsQuery.ToListAsync();

        await FillSelectOptionsAsync(result);

        return result;
    }

    /// <summary>
    /// Retreives the options to fill the select inputs based on the <see cref="FormElement.DataSource"/> property
    /// </summary>
    /// <remarks>
    /// DataSource property points to a StoredProcedure in the sql db, so it´s required to map ths sp result to a db Entity
    /// </remarks>
    private async Task FillSelectOptionsAsync(List<FormElement> formElements)
    {
        foreach (var item in formElements)
        {
            if (item.ElementType != SupportedHtmlElements.Select || string.IsNullOrEmpty(item.DataSource))
            {
                continue;
            }

            if (item.DataSource.Contains("mailtype", StringComparison.InvariantCultureIgnoreCase))
            {
                item.ElementOptions = await GetSpItemsAsync<MailSpResult>(item.DataSource);
            }
            if (item.DataSource.Contains("dby", StringComparison.InvariantCultureIgnoreCase))
            {
                item.ElementOptions = await GetSpItemsAsync<ReferredSpResult>(item.DataSource);
            }
            if (item.DataSource.Contains("salesper", StringComparison.InvariantCultureIgnoreCase))
            {
                item.ElementOptions = await GetSpItemsAsync<SalesPersonSpResult>(item.DataSource); 
            }
            if (item.DataSource.Contains("nxtactn", StringComparison.InvariantCultureIgnoreCase))
            {
                item.ElementOptions = await GetSpItemsAsync<NextActionSpResult>(item.DataSource);
            }
            if (item.DataSource.Contains("custType", StringComparison.InvariantCultureIgnoreCase))
            {
                item.ElementOptions = await GetSpItemsAsync<CustomerTypeSpResult>(item.DataSource);
            }
            if (item.DataSource.Contains("lstactn", StringComparison.InvariantCultureIgnoreCase))
            {
                item.ElementOptions = await GetSpItemsAsync<LstActnSpResult>(item.DataSource);
            }
        }
    }

    /// <summary>
    /// Executes the sp, mapps it to <typeparamref name="TEntity"/> and returns it as a list of <see cref="ElementOption"/>.
    /// </summary>
    private async Task<List<ElementOption>> GetSpItemsAsync<TEntity>(string storedProcedureName) where TEntity : class, INameValueItem
    {
        var spResult = await _dataDbContext.Set<TEntity>()
                                           //.FromSqlInterpolated($"EXEC {storedProcedureName}")
                                           .FromSqlInterpolated($"{storedProcedureName}")
                                           .ToListAsync();
        return spResult.ToElementOption();
    }
}