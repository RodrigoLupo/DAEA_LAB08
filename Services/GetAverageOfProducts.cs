using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetAverageOfProducts
{
    private readonly IUnitOfWork _uow;
    public GetAverageOfProducts(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<double> GetAveragePrice()
    {
        var products = await _uow.GetRepository<Product>().GetAll();
        var averagePrice = products
            .Average(p => p.Price);
        return (double)averagePrice;
    }
}