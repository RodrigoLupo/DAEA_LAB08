using System.Collections;
using Lab8_RodrigoLupo.Models;

namespace Lab8_RodrigoLupo.Repositories.Unit;

public class UnitOfWork: IUnitOfWork
{
    private readonly Hashtable? _repositories;
    private readonly PedidosDbContext _context;
    public UnitOfWork(PedidosDbContext context)
    {
        _context = context;
        _repositories = new Hashtable();
    }
    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }
    
    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;
        if (_repositories.ContainsKey(type))
        {
            return (IGenericRepository<TEntity>)_repositories[type];
        }
        var repositoryType = typeof(GenericRepository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IGenericRepository<TEntity>)repositoryInstance;
        }
        throw new Exception($"No se pudo crear la instancia del repositorio para el tipo {type}");
    }
}