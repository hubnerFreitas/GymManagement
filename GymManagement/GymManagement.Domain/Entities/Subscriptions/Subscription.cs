﻿using ErrorOr;
using GymManagement.Domain.Entities.Gyms;
using Throw;

namespace GymManagement.Domain.Entities.Subscriptions
{
    public class Subscription
    {
        private readonly List<Guid> _gymIds = new();
        private readonly int _maxGyms;

        public Guid Id { get; private set; }
        public SubscriptionType SubscriptionType { get; private set; }

        public Guid AdminId { get; }

        public Subscription(
            SubscriptionType subscription,
            Guid adminID,
            Guid? id = null)
        {
            SubscriptionType = subscription;
            AdminId = adminID;
            Id = id ?? Guid.NewGuid();
        }

        private Subscription()
        {
        }

        public ErrorOr<Success> AddGym(Gym gym)
        {
            _gymIds.Throw().IfContains(gym.Id);

            if (_gymIds.Count >= _maxGyms)
            {
                return SubscriptionErrors.CannotHaveMoreGymsThanTheSubscriptionAllows;
            }

            _gymIds.Add(gym.Id);

            return Result.Success;
        }

        public int GetMaxGyms() => SubscriptionType.Name switch
        {
            nameof(SubscriptionType.Free) => 1,
            nameof(SubscriptionType.Starter) => 1,
            nameof(SubscriptionType.Pro) => 3,
            _ => throw new InvalidOperationException()
        };

        public int GetMaxRooms() => SubscriptionType.Name switch
        {
            nameof(SubscriptionType.Free) => 1,
            nameof(SubscriptionType.Starter) => 3,
            nameof(SubscriptionType.Pro) => int.MaxValue,
            _ => throw new InvalidOperationException()
        };

        public int GetMaxDailySessions() => SubscriptionType.Name switch
        {
            nameof(SubscriptionType.Free) => 4,
            nameof(SubscriptionType.Starter) => int.MaxValue,
            nameof(SubscriptionType.Pro) => int.MaxValue,
            _ => throw new InvalidOperationException()
        };

        public bool HasGym(Guid gymId)
        {
            return _gymIds.Contains(gymId);
        }

        public void RemoveGym(Guid gymId)
        {
            _gymIds.Throw().IfNotContains(gymId);

            _gymIds.Remove(gymId);
        }
    }
}
