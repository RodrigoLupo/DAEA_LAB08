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
    
    public async Task<List<Client>> GetClientsWithMoreThanOrders(int orderCount)
    {
        var clients = await _uow.GetRepository<Client>().GetAll();
        var orders = await _uow.GetRepository<Order>().GetAll();

        var clientWithMoreThanOrders = clients
            .Where(c => orders.Count(o => o.Clientid == c.Clientid) > orderCount)
            .ToList();

        return clientWithMoreThanOrders;
    }
}