using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        #region constructor

        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        #endregion

        public void Create(CreateArticle command)
        {
            var article = new Domain.ArticleAgg.Article(command.Title, command.ShortDescription,
                command.Image, command.Content, command.ArticleCategoryId);

            _articleRepository.Add(article);
            _articleRepository.SaveChanges();
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.GetBy(command.Id);
            if (article == null)
                return;

            article.Edit(command.Title, command.ShortDescription,
                command.Image, command.Content,
                command.ArticleCategoryId);

            _articleRepository.SaveChanges();
        }

        public EditArticle GetBy(long id)
        {
            var article = _articleRepository.GetBy(id);
            return new EditArticle
            {
                Id = article.Id,
                ArticleCategoryId = article.ArticleCategoryId,
                Content = article.Content,
                Image = article.Image,
                ShortDescription = article.ShortDescription,
                Title = article.Title
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}