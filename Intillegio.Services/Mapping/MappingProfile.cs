using System.Linq;
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
            CreateMap<Project, AdminProjectViewModel>();
            CreateMap<Project, ProjectBindingModel>();
            CreateMap<ProjectBindingModel, Project>();
            //CreateMap<AdminProjectBindingModel, Project>()
            //    .ForMember(d => d.Features, opt => opt.MapFrom(sr => sr.Features.Select(y => y.Name).ToList()));
            CreateMap<Project, AdminProjectBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.Category.CategoryName))
                .ForMember(d => d.Features, opt => opt.MapFrom(sr => sr.Features.Select(y => y.ProjectFeature).ToList()));
        }

        private void ConfigurePartners()
        {
            CreateMap<Partner, PartnerViewModel>();
            CreateMap<Partner, AdminPartnerViewModel>();
            CreateMap<Partner, AdminPartnerBindingModel>();
            CreateMap<AdminPartnerBindingModel, Partner>();
        }

        private void ConfigureSolutions()
        {
            CreateMap<Solution, SolutionViewModel>();
            CreateMap<Solution, AdminSolutionViewModel>();
            CreateMap<Solution, AdminSolutionBindingModel>();
            CreateMap<AdminSolutionBindingModel, Solution>();

        }
        private void ConfigureEvents()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Event, AdminEventViewModel>();
            CreateMap<Event, EventBindingModel>();
            CreateMap<EventBindingModel, Event>();
            CreateMap<Event, AdminEventBindingModel>()
                .ForMember(d => d.StartDate, opt => opt.MapFrom(sr => sr.StartDateTime))
                .ForMember(des => des.StartTime, opt => opt.MapFrom(sr => sr.StartDateTime));
            CreateMap<AdminEventBindingModel, Event>();
        }

        private void ConfigureBlogs()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(sr => sr.CategoryName.CategoryName));
            CreateMap<Article, ArticleBindingModel>();
            CreateMap<ArticleBindingModel, Article>();
            CreateMap<Article, AdminArticleBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.CategoryName.CategoryName));
            CreateMap<AdminArticleBindingModel, Article>();
        }

        private void ConfigureShops()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, AdminProductViewModel>();
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
            CreateMap<TeamMember, AdminTeamMemberBindingModel>();
        }
    }
}
