using ErrorOr;
using MediatR;

namespace GymManagement.Application.Services.Subscription.Queries.GetSubscription;

public record GetSubscriptionQuery(Guid SubscriptionId)
    : IRequest<ErrorOr<Domain.Entities.Subscriptions.Subscription>>;