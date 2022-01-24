using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty] public RenameArticleCategory ArticleCategory { get; set; }

        #region constructor

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion

        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.GetArticleCategoryForRename(id);
        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}