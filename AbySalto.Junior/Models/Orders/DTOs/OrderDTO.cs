using AbySalto.Junior.Models.Currencies;
using AbySalto.Junior.Models.OrderArticles.DTOs;

namespace AbySalto.Junior.Models.Orders.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime OrderTime { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Remark { get; set; }

        public ICollection<OrderArticleDTO> OrderArticles { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal Total { get; set; } = 0;

        public OrderDTO()
        {

        }
    }
}
