﻿using GymManagement.Application.Services.Subscription.Commands.CreateSubscription;
using GymManagement.Application.Services.Subscription.Commands.DeleteSubscription;
using GymManagement.Application.Services.Subscription.Queries.GetSubscription;
using GymManagement.Contracts.Enum;
using GymManagement.Contracts.Subscriptions;
using GymManagement.Domain.Entities.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Entities.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers;

[Route("[controller]")]
public class SubscriptionsController : ApiController
{
    private readonly ISender _mediator;

    public SubscriptionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        if (!DomainSubscriptionType.TryFromName(
            request.SubscriptionType.ToString(),
            out var subscriptionType))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid subscription type");
        }

        var command = new CreateSubscriptionCommand(
            subscriptionType,
            request.AdminId);

        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.Match(
            subscription => CreatedAtAction(
                nameof(GetSubscription),
                new { subscriptionId = subscription.Id },
                new SubscriptionResponse(
                    subscription.Id,
                    ToDto(subscription.SubscriptionType))),
            Problem);
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var getSubscriptionsResult = await _mediator.Send(query);

        return getSubscriptionsResult.Match(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,
                ToDto(subscription.SubscriptionType))),
            Problem);
    }

    [HttpDelete("{subscriptionId:guid}")]
    public async Task<IActionResult> DeleteSubscription(Guid subscriptionId)
    {
        var command = new DeleteSubscriptionCommand(subscriptionId);

        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.Match(
            _ => NoContent(),
            Problem);
    }

    private static Contracts.Enum.SubscriptionType ToDto(DomainSubscriptionType subscriptionType)
    {
        return subscriptionType.Name switch
        {
            nameof(DomainSubscriptionType.Free) => Contracts.Enum.SubscriptionType.Free,
            nameof(DomainSubscriptionType.Starter) => Contracts.Enum.SubscriptionType.Starter,
            nameof(DomainSubscriptionType.Pro) => Contracts.Enum.SubscriptionType.Pro,
            _ => throw new InvalidOperationException(),
        };
    }
}