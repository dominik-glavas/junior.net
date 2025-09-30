using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models.Currencies;
using AbySalto.Junior.Models.OrderArticles.DTOs;
using AbySalto.Junior.Models.Orders;
using AbySalto.Junior.Models.Orders.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public RestaurantController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Order")]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO dto)
        {
            try
            {
                var order = new Order(dto);

                _dbContext.Add(order);
                await _dbContext.SaveChangesAsync();

                return Ok($"Successfully created new order with ID: {order.OrderId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Orders")]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrders(bool? sortDescending)
        {
            try
            {
                var orders = _dbContext.Orders
                    .Include(o => o.OrderArticles).ThenInclude(oa => oa.Article).ThenInclude(a => a.Currency)
                    .Select(o => new OrderDTO
                    {
                        OrderId = o.OrderId,
                        CustomerName = o.CustomerName,
                        Status = o.Status,
                        OrderTime = o.OrderTime,
                        PaymentMethod = o.PaymentMethod,
                        Address = o.Address,
                        PhoneNumber = o.PhoneNumber,
                        Remark = o.Remark,
                        OrderArticles = o.OrderArticles.Select(oa => new OrderArticleDTO(oa)).ToList(),
                        CurrencyId = o.CurrencyId,
                        Currency = o.Currency,
                        Total = o.OrderArticles.Sum(oa =>
                        oa.Quantity * (
                            oa.Article.CurrencyId == o.CurrencyId
                                ? oa.Article.Price
                                : _dbContext.ExchangeRates
                                    .First(er => er.FromCurrencyId == oa.Article.CurrencyId && er.ToCurrencyId == o.CurrencyId).Rate
                                    * oa.Article.Price
                            )
                        )
                    });

                if (!sortDescending.HasValue) return await orders.ToListAsync();

                return await (sortDescending.Value ? orders.OrderByDescending(o => o.Total) : orders.OrderBy(o => o.Total)).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Order/{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatus status)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.Status = status;

            await _dbContext.SaveChangesAsync();
            return Ok($"Successfully changed status of order with ID: {order.OrderId}");
        }
    }
}
