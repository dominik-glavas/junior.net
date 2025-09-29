using AbySalto.Junior.Models.Articles;
using AbySalto.Junior.Models.Orders;

namespace AbySalto.Junior.Models.OrderArticles
{
    public class OrderArticle
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int quantity { get; set; }

    }
}