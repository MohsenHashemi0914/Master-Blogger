﻿using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        #region constructor

        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;
        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
        }

        #endregion

        public void Create(CreateArticle command)
        {
            var article = new Domain.ArticleAgg.Article(command.Title, command.ShortDescription,
                command.Image, command.Content, command.ArticleCategoryId, _articleValidatorService);

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

        public void Remove(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article == null) return;

            article.Remove();
            _articleRepository.SaveChanges();
        }

        public void Activate(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article == null) return;

            article.Restore();
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