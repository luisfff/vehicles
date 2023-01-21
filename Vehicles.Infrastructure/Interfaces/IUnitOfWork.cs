namespace Vehicles.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    Task CompleteAsync();
}