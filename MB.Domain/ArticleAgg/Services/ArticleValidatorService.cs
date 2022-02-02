using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleRepository.Exists(x => x.Title == title))
                throw new DuplicatedRecordException("This record already exists in database");
        }
    }
}