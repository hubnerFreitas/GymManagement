using Throw;

namespace GymManagement.Domain.Entities.Admins;

public class Admin
{
    public Guid UserId { get; }
    public Guid? SubscriptionId { get; private set; } = null;
    public Guid Id { get; private set; }

    public Admin(
        Guid userId,
        Guid? subscriptionId = null,
        Guid? id = null)
    {
        UserId = userId;
        SubscriptionId = subscriptionId;
        Id = id ?? Guid.NewGuid();
    }

    private Admin() { }

    public void SetSubscription(Subscriptions.Subscription subscription)
    {
        SubscriptionId.HasValue.Throw().IfTrue();

        SubscriptionId = subscription.Id;
    }

    public void DeleteSubscription(Guid subscriptionId)
    {
        SubscriptionId.ThrowIfNull().IfNotEquals(subscriptionId);

        SubscriptionId = null;
    }
}