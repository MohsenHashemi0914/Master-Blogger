﻿using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        List<ArticleViewModel> GetList();
    }
}