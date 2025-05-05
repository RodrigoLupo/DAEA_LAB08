using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetNullDescriptionsInProducts
{
    private readonly IUnitOfWork _uow;
    public GetNullDescriptionsInProducts(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<Product>> GetNullDescriptions()
    {
        var products = await _uow.GetRepository<Product>().GetAll();
        var nullDescriptions = products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToList();
        return nullDescriptions;
    }
}