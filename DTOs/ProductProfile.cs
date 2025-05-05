using Lab8_RodrigoLupo.Models;

namespace Lab8_RodrigoLupo.DTOs;

using AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductOut>();
    }
}
