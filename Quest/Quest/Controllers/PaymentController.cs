using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestApp.Models;
using Stripe.Checkout;
using Stripe;

namespace QuestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly QuestDbContext _context;
        private readonly IConfiguration _config;

        public PaymentController(QuestDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession(decimal amount, int accessLinkId)
        {
            // Проверка дали AccessLink съществува
            var accessLink = await _context.AccessLinks.FindAsync(accessLinkId);
            if (accessLink == null)
            {
                return NotFound("Access link not found.");
            }

            // Инициализация на Stripe
            StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmountDecimal = amount * 100,
                            Currency = "bgn",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Access Link Payment"
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = "https://localhost:7182/success",
                CancelUrl = "https://localhost:7182/cancel"
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            // Запис в Payment таблицата (предварително, може да изчакаш уебхук ако искаш)
            var payment = new Payment
            {
                AccessLinkId = accessLinkId,
                StripePaymentId = session.Id,
                PaidAt = DateTime.UtcNow,
                Amount = amount,
                IsConfirmed = false // ще стане true след Stripe Webhook
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(new { sessionId = session.Id, url = session.Url });
        }
    }
}
