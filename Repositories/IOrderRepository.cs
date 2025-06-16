using Lab8_RodrigoLupo.DTOs;

namespace Lab8_RodrigoLupo.Repositories;

public interface IOrderRepository
{
    Task<List<OrderDetailsDto>> GetOrdersWithDetailsProducts();
    Task<List<SalesByClientDto>> GetSalesByClient();
}