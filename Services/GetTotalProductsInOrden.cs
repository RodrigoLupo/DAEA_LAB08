using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetTotalProductsInOrden
{
    private readonly IUnitOfWork _uow;

    public GetTotalProductsInOrden(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<int> GetTotalProductsInOrder(int orderId)
    {
        var allOrderDetails = await _uow.GetRepository<Orderdetail>().GetAll();
        var totalProducts = allOrderDetails
            .Where(c => c.Orderid == orderId)
            .Sum(c => c.Quantity);
        return totalProducts;
    }
}