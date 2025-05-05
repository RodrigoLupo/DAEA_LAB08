using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetProductExpensive
{
    private readonly IUnitOfWork _uow;
    public GetProductExpensive(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Product> GetProductThanExpensive()
    {
        var products = await _uow.GetRepository<Product>().GetAll();
        var productExpensive = products
            .OrderByDescending(p => p.Price)
            .FirstOrDefault();
        return productExpensive;
    }
}