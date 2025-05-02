using ErrorOr;
using GymManagement.Domain.Entities.Gyms;
using MediatR;

namespace GymManagement.Application.Services.Gyms.Commands.CreateGym;

public record CreateGymCommand(string Name, Guid SubscriptionId) : IRequest<ErrorOr<Gym>>;