using GymManagement.Contracts.Enum;

namespace GymManagement.Contracts.Subscriptions
{
    public record CreateSubscriptionRequest(
        SubscriptionType SubscriptionType,
        Guid AdminId);
}
