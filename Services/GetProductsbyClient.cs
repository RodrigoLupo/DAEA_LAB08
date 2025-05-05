using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetProductsbyClient
{
    private readonly IUnitOfWork _uow;
    public GetProductsbyClient(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<Product>> GetProductsByClient(int clientId)
    {
        var orders = await _uow.GetRepository<Order>().GetAll();
        var orderDetails = await _uow.GetRepository<Orderdetail>().GetAll();
        var products = await _uow.GetRepository<Product>().GetAll();

        var clientOrderIds = orders
            .Where(o => o.Clientid == clientId)
            .Select(o => o.Orderid)
            .ToList();

        var productIds = orderDetails
            .Where(od => clientOrderIds.Contains(od.Orderid))
            .Select(od => od.Productid)
            .Distinct()
            .ToList();

        var filteredProducts = products
            .Where(p => productIds.Contains(p.ProductId))
            .ToList();

        return filteredProducts;
    }

}