namespace MB.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidationService
    {
        void CheckThatThisRecordAlreadyExists(string title);
    }
}