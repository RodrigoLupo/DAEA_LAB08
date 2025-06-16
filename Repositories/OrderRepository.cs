using Lab8_RodrigoLupo.DTOs;
using Lab8_RodrigoLupo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8_RodrigoLupo.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly PedidosDbContext _context;
    public OrderRepository(PedidosDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<OrderDetailsDto>> GetOrdersWithDetailsProducts()
    {
        var result = await _context.Orders
                .Include(order => order.Orderdetails)
                .ThenInclude(orderdetail => orderdetail.Product)
                .AsNoTracking()
                .Select(order => new OrderDetailsDto
                    {
                        OrderId = order.Orderid,
                        OrderDate = order.Orderdate,
                        Products = order.Orderdetails.Select(od => new ProductDto
                        {
                            ProductName = od.Product.Name,
                            Quantity = od.Quantity,
                            Price = od.Product.Price
                        }).ToList()
                    }).ToListAsync();
        return result;
    }
    public async Task<List<SalesByClientDto>> GetSalesByClient()
    {
        var result = await _context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderdetail => orderdetail.Product)
            .AsNoTracking()
            .GroupBy(order => order.Clientid)
            .Select(group => new SalesByClientDto
            {
                ClientName = _context.Clients.FirstOrDefault(c => c.Clientid == group.Key)!.Name,
                TotalSales = group.Sum(order => order.Orderdetails.Sum(od => od.Product.Price))
            })
            .OrderByDescending(s => s.TotalSales).ToListAsync();
        return result;
    }
}