namespace AbySalto.Junior.Models.Articles.DTOs
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }

        public ArticleDTO(Article article)
        {
            ArticleId = article.ArticleId;
            Name = article.Name;
            Price = article.Price;
            CurrencyId = article.CurrencyId;
        }

        public ArticleDTO()
        {
            
        }
    }
}
