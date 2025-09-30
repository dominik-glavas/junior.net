using AbySalto.Junior.Models.OrderArticles.DTOs;

namespace AbySalto.Junior.Models.Orders.DTOs
{
    public class CreateOrderDTO
    {
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Remark { get; set; }

        public ICollection<OrderArticleDTO> OrderArticles { get; set; }

        public int CurrencyId { get; set; }

        public CreateOrderDTO(string customerName, OrderStatus status, PaymentMethod paymentMethod, string address, string phoneNumber, string remark, List<OrderArticleDTO> orderArticles, int currencyId)
        {
            CustomerName = customerName;
            Status = status;
            PaymentMethod = paymentMethod;
            Address = address;
            PhoneNumber = phoneNumber;
            Remark = remark;
            OrderArticles = orderArticles;
            CurrencyId = currencyId;
        }

        public CreateOrderDTO()
        {
        }
    }
}
