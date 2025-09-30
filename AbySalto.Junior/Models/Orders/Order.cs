using AbySalto.Junior.Models.Currencies;
using AbySalto.Junior.Models.OrderArticles;
using AbySalto.Junior.Models.Orders.DTOs;

namespace AbySalto.Junior.Models.Orders
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime OrderTime { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Remark { get; set; }

        public ICollection<OrderArticle> OrderArticles { get; set; } = new List<OrderArticle>();

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public Order(CreateOrderDTO dto)
        {
            CustomerName = dto.CustomerName;
            Status = dto.Status;
            OrderTime = DateTime.Now;
            PaymentMethod = dto.PaymentMethod;
            Address = dto.Address;
            PhoneNumber = dto.PhoneNumber;
            Remark = dto.Remark;
            OrderArticles = dto.OrderArticles.Select(oa => new OrderArticle
                {
                    ArticleId = oa.ArticleId,
                    Quantity = oa.Quantity
                })
                .ToList();
            CurrencyId = dto.CurrencyId;
        }

        public Order() { }
    }
}
