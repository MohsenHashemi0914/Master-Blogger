using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        void Remove(long id);
        void Activate(long id);
        EditArticle GetBy(long id);
        List<ArticleViewModel> GetList();
    }
}