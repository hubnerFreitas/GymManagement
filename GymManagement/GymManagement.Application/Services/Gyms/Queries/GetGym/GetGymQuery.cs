using ErrorOr;
using GymManagement.Domain.Entities.Gyms;
using MediatR;

namespace GymManagement.Application.Services.Gyms.Queries.GetGym;

public record GetGymQuery(Guid SubscriptionId, Guid GymId) : IRequest<ErrorOr<Gym>>;