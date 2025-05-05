using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetOrderInDate
{
    private readonly IUnitOfWork _uow;

    public GetOrderInDate(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<Order>> GetOrdersAfterDate(DateTime date)
    {
        var orders = await _uow.GetRepository<Order>().GetAll();
        var filteredOrders = orders
            .Where(o => o.Orderdate > date)
            .ToList();

        return filteredOrders;
    }
}
