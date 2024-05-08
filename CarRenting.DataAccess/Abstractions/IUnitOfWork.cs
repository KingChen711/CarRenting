namespace CarRenting.DataAccess.Abstractions;

public interface IUnitOfWork
{

    Task SaveAsync();
}