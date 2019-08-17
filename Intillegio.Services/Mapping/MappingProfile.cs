using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs.BindingModels;
using Intillegio.Models;

namespace Intillegio.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureProjects();
            ConfigureClients();
            ConfigureSolutions();
            ConfigureBlogs();
            ConfigureShops();
        }

        private void ConfigureProjects()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
           
        }

        private void ConfigureClients()
        {
            CreateMap<Partner, PartnerViewModel>();
        }

        private void ConfigureSolutions()
        {
            CreateMap<Solution, SolutionViewModel>();
        }

        private void ConfigureBlogs()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<Article, ArticleBindingModel>();
            CreateMap<ArticleBindingModel, Article>();
        }

        private void ConfigureShops()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
