using Lab8_RodrigoLupo.DTOs;
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
    public async Task<List<ProductSummary>> OrdersAndDetailsWithProducts()
    {
        var orderDetails = await _uow.GetRepository<Orderdetail>().GetAll();
        var products = await _uow.GetRepository<Product>().GetAll();

        var result = (from od in orderDetails
                join p in products on od.Productid equals p.ProductId
                group new {od, p} by new {p.ProductId, p.Name, p.Price} into g
                select new ProductSummary
                {
                    nombre = g.Key.Name,
                    cantidad = g.Sum(x=> x.od.Quantity)
                }).ToList();
        return result;
    }
}
