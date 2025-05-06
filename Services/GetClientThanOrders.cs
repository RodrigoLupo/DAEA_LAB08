using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetClientThanOrders
{
    private readonly IUnitOfWork _uow;
    public GetClientThanOrders(IUnitOfWork uow)
    {
        _uow = uow;
    }
    
    public async Task<Client> GetClientWithMostOrders()
    {
        var orders = await _uow.GetRepository<Order>().GetAll();
        var clients = await _uow.GetRepository<Client>().GetAll();

        var topClientId = orders
            .GroupBy(o => o.Clientid)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

        return clients.FirstOrDefault(c => c.Clientid == topClientId);
    }


}