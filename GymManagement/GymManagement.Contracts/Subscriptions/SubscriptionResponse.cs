using GymManagement.Contracts.Enum;

namespace GymManagement.Contracts.Subscriptions
{
    public record SubscriptionResponse(Guid Id, SubscriptionType Subscription);
}
