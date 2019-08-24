using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.DTOs.BindingModels;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;

namespace Intillegio.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureProjects();
            ConfigurePartners();
            ConfigureSolutions();
            ConfigureBlogs();
            ConfigureShops();
            ConfigureTeamMembers();
            ConfigureEvents();
        }

        private void ConfigureProjects()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Project, ProjectBindingModel>();
            CreateMap<ProjectBindingModel, Project>();
        }

        private void ConfigurePartners()
        {
            CreateMap<Partner, PartnerViewModel>();
        }

        private void ConfigureSolutions()
        {
            CreateMap<Solution, SolutionViewModel>();
            CreateMap<Solution, SolutionBindingModel>();
            CreateMap<SolutionBindingModel, Solution>();
        }
        private void ConfigureEvents()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Event, EventBindingModel>();
            CreateMap<EventBindingModel, Event>();
        }

        private void ConfigureBlogs()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(sr => sr.CategoryName.CategoryName));
            CreateMap<Article, ArticleBindingModel>();
            CreateMap<ArticleBindingModel, Article>();
        }

        private void ConfigureShops()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductBindingModel>();
            CreateMap<ProductBindingModel, Product>();
        }

        private void ConfigureTeamMembers() 
        {
            CreateMap<TeamMember, TeamMemberViewModel>();
            CreateMap<TeamMember, AdminTeamMemberViewModel>();
            CreateMap<TeamMember, TeamMemberBindingModel>();
            CreateMap<TeamMemberBindingModel, TeamMember>();
            CreateMap<AdminTeamMemberBindingModel, TeamMember>();
            CreateMap<TeamMember, AdminTeamMemberBindingModel >();
        }
    }
}
