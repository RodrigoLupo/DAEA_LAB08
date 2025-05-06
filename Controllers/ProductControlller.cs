using Lab8_RodrigoLupo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_RodrigoLupo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly GetProductsGreatherThan _getProductsGreatherThan;
    private readonly GetProductExpensive _getProductExpensive;
    private readonly GetAverageOfProducts _getAverageOfProducts;
    private readonly GetNullDescriptionsInProducts _getNullDescriptionsInProducts;
    private readonly GetClientsbyProduct _getClientsbyProduct;

    public ProductController(GetProductsGreatherThan getProductsGreatherThan,
        GetProductExpensive getProductExpensive,
        GetAverageOfProducts getAverageOfProducts,
        GetNullDescriptionsInProducts getNullDescriptionsInProducts,
        GetClientsbyProduct getClientsbyProduct)

    {
        _getProductsGreatherThan = getProductsGreatherThan;
        _getProductExpensive = getProductExpensive;
        _getAverageOfProducts = getAverageOfProducts;
        _getNullDescriptionsInProducts = getNullDescriptionsInProducts;
        _getClientsbyProduct = getClientsbyProduct;
    }
    
    [HttpGet("GetProductsGreatherThan/{price}")]
    public async Task<IActionResult> GetProductsGreatherThan(decimal price)
    {
        var result = await _getProductsGreatherThan.GetProductsGreatherThanValue(price);
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetProductExpensive")]
    public async Task<IActionResult> GetProductExpensive()
    {
        var result = await _getProductExpensive.GetProductThanExpensive();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetAveragePrice")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var result = await _getAverageOfProducts.GetAveragePrice();
        if (result == 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetNullDescriptionsInProducts")]
    public async Task<IActionResult> GetNullDescriptionsInProducts()
    {
        var result = await _getNullDescriptionsInProducts.GetNullDescriptions();
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetClientsByProductId/{ProductId}")]
    public async Task<IActionResult> GetClientsByProductId(int ProductId)
    {
        var result = await _getClientsbyProduct.GetClientsByProduct(ProductId);
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
}