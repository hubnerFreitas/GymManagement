using ErrorOr;
using GymManagement.Application.Services.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Services.Subscription.Queries.GetSubscription;

public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Domain.Entities.Subscriptions.Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public GetSubscriptionQueryHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Domain.Entities.Subscriptions.Subscription>> Handle(GetSubscriptionQuery query, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionsRepository.GetByIdAsync(query.SubscriptionId);

        return subscription is null
            ? Error.NotFound(description: "Subscription not found")
            : subscription;
    }
}
