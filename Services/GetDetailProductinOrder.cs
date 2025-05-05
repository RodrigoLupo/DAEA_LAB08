using AutoMapper;
using Lab8_RodrigoLupo.DTOs;
using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetDetailProductinOrder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDetailProductinOrder(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<ProductInOrder>> GetDetailProductInOrder(int orderId)
    {
        var allOrderDetails = await _unitOfWork.GetRepository<Orderdetail>().GetAll();

        var productIds = allOrderDetails
            .Where(c => c.Orderid == orderId)
            .Select(c => c.Productid)
            .Distinct(); 

        var products = await _unitOfWork.GetRepository<Product>().GetByIds(productIds);
        var mappedProducts = _mapper.Map<IEnumerable<ProductOut>>(products);
        var result = new ProductInOrder
        {
            IdOrden = orderId,
            Products = mappedProducts.ToArray()
        };

        return new List<ProductInOrder> { result };
    }
}