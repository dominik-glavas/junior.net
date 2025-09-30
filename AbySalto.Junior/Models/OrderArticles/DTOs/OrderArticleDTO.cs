using AbySalto.Junior.Models.Articles.DTOs;

namespace AbySalto.Junior.Models.OrderArticles.DTOs
{
    public class OrderArticleDTO
    {
        public int ArticleId { get; set; }
        public ArticleDTO? Article { get; set; }
        public int Quantity { get; set; }

        public OrderArticleDTO(int articleId, int quantity)
        {
            ArticleId = articleId;
            Quantity = quantity;
        }

        public OrderArticleDTO(OrderArticle orderArticle)
        {
            ArticleId = orderArticle.ArticleId;
            Article = new ArticleDTO(orderArticle.Article);
            Quantity = orderArticle.Quantity;
        }

        public OrderArticleDTO()
        {
            
        }
    }
}
