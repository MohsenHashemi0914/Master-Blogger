using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }

        #region constructor

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        #endregion

        public void OnGet(long id)
        {
            Article = _articleQuery.GerArticleBy(id);
        }

        public IActionResult OnPost(AddComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails", new { id = command.ArticleId });
        }
    }
}