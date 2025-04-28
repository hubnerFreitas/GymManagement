using GymManagement.Contracts.Enum;

namespace GymManagement.Contracts.Subscriptions
{
    public record CreateSubscriptionRequest(Guid AdminId, SubscriptionType SubscriptionType);
}
