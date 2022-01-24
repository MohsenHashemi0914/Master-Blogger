﻿using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}