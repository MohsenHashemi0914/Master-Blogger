namespace MB.Application.Contracts.Article
{
    public class EditArticle : CreateArticle
    {
        public long ArticleCategoryId { get; set; }
    }
}