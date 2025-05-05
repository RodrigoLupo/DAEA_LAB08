using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetOrdersAndDetailsWithProducts
{
    private readonly IUnitOfWork _uow;
    public GetOrdersAndDetailsWithProducts(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<(string ProductName, int Quantity)>> OrdersAndDetailsWithProducts()
    {
        var orderDetails = await _uow.GetRepository<Orderdetail>().GetAll();
        var products = await _uow.GetRepository<Product>().GetAll();

        var result = (from od in orderDetails
                join p in products on od.Productid equals p.ProductId
                select (ProductName: p.Name, Quantity: od.Quantity))
            .ToList();

        return result;
    }
}