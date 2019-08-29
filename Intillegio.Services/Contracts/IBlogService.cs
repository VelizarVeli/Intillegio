using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;

namespace Intillegio.Services.Contracts
{
    public interface IBlogService:ICategoryService
    {
        Task<IEnumerable<ArticleViewModel>> GetAllArticles();
        Task<IEnumerable<ArticleViewModel>> GetArticles();
        Task<ArticleBindingModel> GetArticleDetailsAsync(int id);
        Task<IEnumerable<AdminArticleViewModel>> GetAllArticlesForAdmin();
        Task<AdminArticleBindingModel> GetArticleDetailsForAdminAsync(int id);
        Task AddArticleAsync(AdminArticleBindingModel article);
        Task DeleteArticleAsync(int id);
        Task ArticleEditAsync(AdminEditArticleBindingModel article, int id);
        Task<AdminEditArticleBindingModel> GetArticleDetailsForAdminEditAsync(int id);
    }
}
