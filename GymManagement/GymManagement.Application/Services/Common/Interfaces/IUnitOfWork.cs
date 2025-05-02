namespace GymManagement.Application.Services.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}