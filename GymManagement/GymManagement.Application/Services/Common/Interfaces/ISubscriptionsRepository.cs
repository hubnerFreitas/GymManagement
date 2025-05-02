namespace GymManagement.Application.Services.Common.Interfaces;

public interface ISubscriptionsRepository
{
    Task AddSubscriptionAsync(Domain.Entities.Subscriptions.Subscription subscription);
    Task<bool> ExistsAsync(Guid id);
    Task<Domain.Entities.Subscriptions.Subscription?> GetByAdminIdAsync(Guid adminId);
    Task<Domain.Entities.Subscriptions.Subscription?> GetByIdAsync(Guid id);
    Task<List<Domain.Entities.Subscriptions.Subscription>> ListAsync();
    Task RemoveSubscriptionAsync(Domain.Entities.Subscriptions.Subscription subscription);
    Task UpdateAsync(Domain.Entities.Subscriptions.Subscription subscription);
}