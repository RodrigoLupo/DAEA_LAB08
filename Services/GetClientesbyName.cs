using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories.Unit;

namespace Lab8_RodrigoLupo.Services;

public class GetClientesbyName
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientesbyName(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<Client>> GetClientesByName(string name)
    {
        var clientes = await _unitOfWork.GetRepository<Client>().GetAll();
        var filteredClientes = clientes.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredClientes;
    }
}