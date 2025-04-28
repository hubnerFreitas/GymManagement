namespace GymManagement.Application.Services
{
    public class SubscriptionService : ISubscriptionsService
    {
        Guid ISubscriptionsService.CreateSubscription(string subscriptionType, Guid AdminId)
        {
            return Guid.NewGuid();
        }
    }
}
