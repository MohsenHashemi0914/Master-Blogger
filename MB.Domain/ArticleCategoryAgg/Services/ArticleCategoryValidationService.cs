using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidationService : IArticleCategoryValidationService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidationService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(x => x.Title == title))
                throw new DuplicatedRecordException("This record already exists in database");
        }
    }
}