using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.DTOs;
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
            CreateMap<Project, ProjectBindingModel>();
            CreateMap<ProjectBindingModel, Project>();

        }

        private void ConfigureClients()
        {
            CreateMap<Partner, PartnerViewModel>();
        }

        private void ConfigureSolutions()
        {
            CreateMap<Solution, SolutionViewModel>();
            CreateMap<Solution, SolutionBindingModel>();
            CreateMap<SolutionBindingModel, Solution>();
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
            CreateMap<Product, ProductBindingModel>();
            CreateMap<ProductBindingModel, Product>();
        }
    }
}
