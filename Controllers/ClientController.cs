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
    public ClientController(GetClientesbyName getClientesbyName,
        GetClientThanOrders getClientThanOrders,
        GetProductsbyClient getProductsbyClient)

    {
        _getClientesbyName = getClientesbyName;
        _getClientThanOrders = getClientThanOrders;
        _getProductsbyClient = getProductsbyClient;
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
    [HttpGet("GetClientThanOrders/{clientId}")]
    public async Task<IActionResult> GetClientThanOrders(int clientId)
    {
        var result = await _getClientThanOrders.GetClientsWithMoreThanOrders(clientId);
        if (result == null || !result.Any())
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
}