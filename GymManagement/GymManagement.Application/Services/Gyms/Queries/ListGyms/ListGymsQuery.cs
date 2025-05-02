using ErrorOr;
using MediatR;
using GymManagement.Domain.Entities.Gyms;

namespace GymManagement.Application.Services.Gyms.Queries.ListGyms;

public record ListGymsQuery(Guid SubscriptionId) : IRequest<ErrorOr<List<Gym>>>;