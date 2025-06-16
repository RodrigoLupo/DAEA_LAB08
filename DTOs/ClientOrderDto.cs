namespace Lab8_RodrigoLupo.DTOs;

public class ClientOrderDto
{
    public string ClientName { get; set; }
    public List<OrderDto> Orders { get; set; }
}