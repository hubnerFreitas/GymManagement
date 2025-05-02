using ErrorOr;
using GymManagement.Domain.Entities.Rooms;
using MediatR;

namespace GymManagement.Application.Services.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    Guid GymId,
    string RoomName) : IRequest<ErrorOr<Room>>;