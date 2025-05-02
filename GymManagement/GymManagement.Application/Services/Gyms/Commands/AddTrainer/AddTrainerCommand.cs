using ErrorOr;
using MediatR;

namespace GymManagement.Application.Services.Gyms.Commands.AddTrainer;

public record AddTrainerCommand(Guid SubscriptionId, Guid GymId, Guid TrainerId)
    : IRequest<ErrorOr<Success>>;