using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle GetBy(long id);
        List<ArticleViewModel> GetList();
    }
}