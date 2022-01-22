using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        void Remove(long id);
        void Activate(long id);
        RenameArticleCategory GetArticleCategoryForRename(long id);
    }
}