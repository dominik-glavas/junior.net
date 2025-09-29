using AbySalto.Junior.Models.Currencies;
using AbySalto.Junior.Models.OrderArticles;
using AbySalto.Junior.Models.Orders;

namespace AbySalto.Junior.Models.Articles
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public ICollection<OrderArticle> OrderArticles { get; set; } = new List<OrderArticle>();

        public Article(string name, decimal price, Currency currency)
        {
            Name = name;
            Price = price;
            Currency = currency;
        }

        public Article()
        {

        }
    }
}