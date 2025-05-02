using ErrorOr;
using MediatR;

namespace GymManagement.Application.Services.Subscription.Commands.DeleteSubscription;

public record DeleteSubscriptionCommand(Guid SubscriptionId) : IRequest<ErrorOr<Deleted>>;