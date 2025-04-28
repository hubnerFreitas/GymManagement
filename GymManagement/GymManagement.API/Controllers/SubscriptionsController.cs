using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISubscriptionsService _subscrition;

        public SubscriptionsController(ISubscriptionsService subscriptions)
        {
            _subscrition = subscriptions;
        }

        [HttpPost]
        public IActionResult CreateSubscription(CreateSubscriptionRequest request)
        {
            var subscription = _subscrition.CreateSubscription(request.SubscriptionType.ToString(),
                request.AdminId);

            var response = new SubscriptionResponse(subscription, request.SubscriptionType) ;

            return Ok(response);
        }
    }
}
