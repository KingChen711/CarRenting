namespace CarRenting.DataAccess.Abstractions;

public interface IUnitOfWork
{
    ICarRepository Car { get; }
    Task SaveAsync();
}