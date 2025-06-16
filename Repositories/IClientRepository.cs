using Lab8_RodrigoLupo.DTOs;
using Lab8_RodrigoLupo.Models;

namespace Lab8_RodrigoLupo.Repositories;

public interface IClientRepository
{
    Task<List<ClientOrderDto>> GetClientWithOrders();
    Task<List<dynamic>> GetClientsByProductCount();
}