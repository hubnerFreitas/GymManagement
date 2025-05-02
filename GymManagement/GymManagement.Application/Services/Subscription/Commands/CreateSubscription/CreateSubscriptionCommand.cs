using ErrorOr;
using GymManagement.Domain.Entities.Subscriptions;
using MediatR;

namespace GymManagement.Application.Services.Subscription.Commands.CreateSubscription;

public record CreateSubscriptionCommand(
    SubscriptionType SubscriptionType,
    Guid AdminId) : IRequest<ErrorOr<Domain.Entities.Subscriptions.Subscription>>;