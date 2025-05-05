using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetProductsGreatherThan
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductsGreatherThan(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<Product>> GetProductsGreatherThanValue(decimal price)
    {
        var products = await _unitOfWork.GetRepository<Product>().GetAll();
        var filteredProducts = products.Where(p => p.Price > price).ToList();
        return filteredProducts;
    }
}