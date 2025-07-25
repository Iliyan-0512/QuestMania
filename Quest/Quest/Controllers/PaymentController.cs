using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe.Checkout;
using Stripe;
using QuestApp.Models;

namespace QuestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly QuestDbContext _context;

        public PaymentController(IConfiguration config, QuestDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession(decimal amount, int accessLinkId)
        {
            // проверка дали има такъв access link
            var accessLink = _context.AccessLinks.FirstOrDefault(x => x.Id == accessLinkId);
            if (accessLink == null)
            {
                return NotFound("AccessLink not found.");
            }

            // Stripe client
            var stripeClient = new StripeClient(_config["Stripe:SecretKey"]);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmountDecimal = amount * 100, // Stripe работи в центове
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Access Code: {accessLink.Code}"
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = "https://localhost:7182/success",
                CancelUrl = "https://localhost:7182/cancel",
            };

            var service = new SessionService(stripeClient);
            Session session = await service.CreateAsync(options);

            return Ok(new { sessionId = session.Id, url = session.Url });
        }
    }
}
