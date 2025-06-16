using Lab8_RodrigoLupo.DTOs;
using Lab8_RodrigoLupo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8_RodrigoLupo.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly PedidosDbContext _context;
    public ClientRepository(PedidosDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ClientOrderDto>> GetClientWithOrders()
    {
        var result = await _context.Clients
            .AsNoTracking()
            .Select(client => new ClientOrderDto
                {
                    ClientName = client.Name,
                    Orders = client.Orders.Select(order => new OrderDto
                    {
                        OrderId = order.Orderid,
                        OrderDate = order.Orderdate,
                    }).ToList()
                }
            ).ToListAsync();
        return result;
    }
    public async Task<List<dynamic>> GetClientsByProductCount()
    {
        var result = await _context.Clients
            .AsNoTracking()
            .Select(client => new
                {
                 ClientName = client.Name,
                 TotalProducts = client.Orders
                     .Sum(order => order.Orderdetails
                         .Sum(detail => detail.Quantity))
                }).ToListAsync<dynamic>();
        return result;
    }
    
}