using MB.Application.Article;
using MB.Application.ArticleCategory;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class BootStrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<IArticleCategoryValidationService, ArticleCategoryValidationService>();

            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
