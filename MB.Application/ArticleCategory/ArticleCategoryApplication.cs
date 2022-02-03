using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Framework.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application.ArticleCategory
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        #region constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidationService _articleCategoryValidationService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
            IArticleCategoryValidationService articleCategoryValidationService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidationService = articleCategoryValidationService;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public List<ArticleCategoryViewModel> List()
        {
            return _articleCategoryRepository.GetAll()
                .Select(x => new ArticleCategoryViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
                }).OrderByDescending(x => x.Id).ToList();
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            if (_articleCategoryRepository.Exists(x => x.Title == command.Title)) return;

            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Title, _articleCategoryValidationService);
            _articleCategoryRepository.Add(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            if (_articleCategoryRepository.Exists(x => x.Title == command.Title)) return;

            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            if (articleCategory != null)
            {
                articleCategory.Rename(command.Title);
            }

            _unitOfWork.CommitTran();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();

            var articleCategory = _articleCategoryRepository.GetBy(id);
            if (articleCategory != null)
            {
                articleCategory.Remove();
            }

            _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();

            var articleCategory = _articleCategoryRepository.GetBy(id);
            if (articleCategory != null)
            {
                articleCategory.Activate();
                _unitOfWork.CommitTran();
            }
        }

        public RenameArticleCategory GetArticleCategoryForRename(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }
    }
}