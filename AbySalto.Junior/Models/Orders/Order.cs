using AbySalto.Junior.Models.Articles;
using AbySalto.Junior.Models.Currencies;
using AbySalto.Junior.Models.OrderArticles;

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

        public decimal TotalPrice { get; set; }
        public Currency Currency { get; set; }

        public Order(string customer, OrderStatus status, DateTime orderTime, PaymentMethod paymentMethod, string address, string phoneNumber, string remark, Currency currency)
        {
            CustomerName = customer;
            Status = status;
            OrderTime = orderTime;
            PaymentMethod = paymentMethod;
            Address = address;
            PhoneNumber = phoneNumber;
            Remark = remark;
            Currency = currency;
        }

        public Order() { }
    }
}
