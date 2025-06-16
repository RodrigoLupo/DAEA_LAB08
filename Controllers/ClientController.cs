using Lab8_RodrigoLupo.Repositories;
using Lab8_RodrigoLupo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_RodrigoLupo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly GetClientesbyName _getClientesbyName;
    private readonly GetClientThanOrders _getClientThanOrders;
    private readonly GetProductsbyClient _getProductsbyClient;
    private readonly IClientRepository _clientRepository;
    public ClientController(GetClientesbyName getClientesbyName,
        GetClientThanOrders getClientThanOrders,
        GetProductsbyClient getProductsbyClient,
        IClientRepository clientRepository)

    {
        _getClientesbyName = getClientesbyName;
        _getClientThanOrders = getClientThanOrders;
        _getProductsbyClient = getProductsbyClient;
        _clientRepository = clientRepository;
    }
    [HttpGet("GetClientesByName/{name}")]
    public async Task<IActionResult> GetClientesByName(string name)
    {
        var result = await _getClientesbyName.GetClientesByName(name);
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetClientThanOrders")]
    public async Task<IActionResult> GetClientThanOrders()
    {
        var result = await _getClientThanOrders.GetClientWithMostOrders();
        if (result == null )
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetProductsbyClient/{clientId}")]
    public async Task<IActionResult> GetProductsbyClient(int clientId)
    {
        var result = await _getProductsbyClient.GetProductsByClient(clientId);
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetClientWithOrders")]
    public async Task<IActionResult> GetClientWithOrders()
    {
        var result = await _clientRepository.GetClientWithOrders();
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetClientByProductCount")]
    public async Task<IActionResult> GetClientByProductCount()
    {
        var result = await _clientRepository.GetClientsByProductCount();
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    
}