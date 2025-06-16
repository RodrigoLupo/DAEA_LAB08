using Lab8_RodrigoLupo.Repositories;
using Lab8_RodrigoLupo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_RodrigoLupo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController: ControllerBase
{
    private readonly GetDetailProductinOrder _getDetailProductinOrder;
    private readonly GetTotalProductsInOrden _getTotalProductsInOrden;
    private readonly GetOrderInDate _getOrderInDate;
    private readonly GetOrdersAndDetailsWithProducts _getOrdersAndDetailsWithProducts;
    private readonly IOrderRepository _orderRepository;
    public OrderController(GetDetailProductinOrder getDetailProductinOrder,
        GetTotalProductsInOrden getTotalProductsInOrden,
        GetOrderInDate getOrderInDate,
        GetOrdersAndDetailsWithProducts getOrdersAndDetailsWithProducts,
        IOrderRepository orderRepository)
    {
        _getDetailProductinOrder = getDetailProductinOrder;
        _getTotalProductsInOrden = getTotalProductsInOrden;
        _getOrderInDate = getOrderInDate;
        _getOrdersAndDetailsWithProducts = getOrdersAndDetailsWithProducts;
        _orderRepository = orderRepository;
    }
    
    [HttpGet("GetDetailProductInOrder/{orderId}")]
    public async Task<IActionResult> GetDetailProductInOrder(int orderId)
    {
        var result = await _getDetailProductinOrder.GetDetailProductInOrder(orderId);
        if (!result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetTotalProductsInOrder/{orderId}")]
    public async Task<IActionResult> GetTotalProductsInOrder(int orderId)
    {
        var result = await _getTotalProductsInOrden.GetTotalProductsInOrder(orderId);
        if (result == 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetOrderInDate/{date}")]
    public async Task<IActionResult> GetOrderInDate(DateTime date)
    {
        var result = await _getOrderInDate.GetOrdersAfterDate(date);
        if (!result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetOrdersAndDetailsWithProducts")]
    public async Task<IActionResult> GetOrdersAndDetailsWithProducts()
    {
        var result = await _getOrdersAndDetailsWithProducts.OrdersAndDetailsWithProducts();
        if (!result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpGet("GetOrdersWithDetailsProducts")]
    public async Task<IActionResult> GetOrdersWithDetailsProducts()
    {
        var result = await _orderRepository.GetOrdersWithDetailsProducts();
        if (!result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpGet("GetSalesByClient")]
    public async Task<IActionResult> GetSalesByClient()
    {
        var result = await _orderRepository.GetSalesByClient();
        if (!result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
}