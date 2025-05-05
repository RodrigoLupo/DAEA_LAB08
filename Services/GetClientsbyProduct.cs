using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetClientsbyProduct
{
    private readonly IUnitOfWork _uow;
    public GetClientsbyProduct(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<Client>> GetClientsByProduct(int productId)
    {
        var orderDetails = await _uow.GetRepository<Orderdetail>().GetAll();
        var orders = await _uow.GetRepository<Order>().GetAll();
        var clients = await _uow.GetRepository<Client>().GetAll();

        var orderIdsWithProduct = orderDetails
            .Where(od => od.Productid == productId)
            .Select(od => od.Orderid)
            .Distinct()
            .ToList();

        var clientIds = orders
            .Where(o => orderIdsWithProduct.Contains(o.Orderid))
            .Select(o => o.Clientid)
            .Distinct()
            .ToList();

        var filteredClients = clients
            .Where(c => clientIds.Contains(c.Clientid))
            .ToList();

        return filteredClients;
    }

}