using ErrorOr;
using MediatR;

namespace GymManagement.Application.Services.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(Guid GymId, Guid RoomId)
    : IRequest<ErrorOr<Deleted>>;