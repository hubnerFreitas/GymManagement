using ErrorOr;
using MediatR;

namespace GymManagement.Application.Services.Gyms.Commands.DeleteGym;

public record DeleteGymCommand(Guid SubscriptionId, Guid GymId) : IRequest<ErrorOr<Deleted>>;