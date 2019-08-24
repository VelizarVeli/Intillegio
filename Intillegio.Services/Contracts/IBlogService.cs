using System.Collections.Generic;
using System.Threading.Tasks;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;

namespace Intillegio.Services.Contracts
{
    public interface IBlogService
    {
        Task<IEnumerable<ArticleViewModel>> GetAllArticles();
        Task<IEnumerable<ArticleViewModel>> GetArticles();
        Task<ArticleBindingModel> GetArticleDetailsAsync(int id);
        Task<BlogViewModel> BlogArticles();
        Task<IEnumerable<AdminArticleViewModel>> GetAllArticlesForAdmin();
    }
}
