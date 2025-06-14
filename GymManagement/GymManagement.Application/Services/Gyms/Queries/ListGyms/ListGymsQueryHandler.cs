using ErrorOr;
using GymManagement.Application.Services.Common.Interfaces;
using GymManagement.Domain.Entities.Gyms;
using MediatR;

namespace GymManagement.Application.Services.Gyms.Queries.ListGyms;

public class ListGymsQueryHandler : IRequestHandler<ListGymsQuery, ErrorOr<List<Gym>>>
{
    private readonly IGymsRepository _gymsRepository;
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public ListGymsQueryHandler(IGymsRepository gymsRepository, ISubscriptionsRepository subscriptionsRepository)
    {
        _gymsRepository = gymsRepository;
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<List<Gym>>> Handle(ListGymsQuery query, CancellationToken cancellationToken)
    {
        if (!await _subscriptionsRepository.ExistsAsync(query.SubscriptionId))
        {
            return Error.NotFound(description: "Subscription not found");
        }

        return await _gymsRepository.ListBySubscriptionIdAsync(query.SubscriptionId);
    }
}
