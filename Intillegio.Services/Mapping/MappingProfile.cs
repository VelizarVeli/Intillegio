﻿using System.Linq;
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
            ConfigureArticles();
            ConfigureProducts();
            ConfigureTeamMembers();
            ConfigureEvents();
            ConfigureQuickLinks();
        }

        private void ConfigureProjects()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Project, AdminProjectViewModel>();
            CreateMap<Project, ProjectBindingModel>();
            CreateMap<ProjectBindingModel, Project>();
            CreateMap<AdminProjectBindingModel, Project>()
            .ForMember(d => d.Category, opt => opt.Ignore())
            .ForMember(d => d.Partner, opt => opt.Ignore());
            CreateMap<Project, AdminProjectBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.Category.CategoryName))
                .ForMember(d => d.Features, opt => opt.MapFrom(sr => sr.Features.Select(y => y.ProjectFeature).ToList()));
            CreateMap<AdminEditProjectBindingModel, Project>()
                .ForMember(d => d.Category, opt => opt.Ignore())
                .ForMember(d => d.Partner, opt => opt.Ignore());
            CreateMap<Project, AdminEditProjectBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.Category.CategoryName))
                .ForMember(d => d.Features, opt => opt.MapFrom(sr => sr.Features.Select(y => y.ProjectFeature).ToList()));
        }

        private void ConfigureQuickLinks()
        {
            CreateMap<QuickLinksViewModel, QuickLink>();
            CreateMap<QuickLink, QuickLinksViewModel>();
            CreateMap<AdminQuickLinkBindingModel, QuickLink>();
            CreateMap<QuickLink, AdminQuickLinkBindingModel>();
        }

        private void ConfigurePartners()
        {
            CreateMap<Partner, PartnerViewModel>();
            CreateMap<Partner, AdminPartnerViewModel>();
            CreateMap<Partner, AdminPartnerBindingModel>();
            CreateMap<AdminPartnerBindingModel, Partner>();
            CreateMap<UserViewModel, IntillegioUser>();
            CreateMap<IntillegioUser, UserViewModel>();
        }

        private void ConfigureSolutions()
        {
            CreateMap<Solution, SolutionViewModel>();
            CreateMap<Solution, SolutionBindingModel>();
            CreateMap<SolutionBindingModel, Solution>();
            CreateMap<Solution, AdminSolutionViewModel>();
            CreateMap<Solution, AdminSolutionBindingModel>();
            CreateMap<AdminSolutionBindingModel, Solution>();
            CreateMap<Solution, SolutionDropDownViewModel>();

        }
        private void ConfigureEvents()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Event, AdminEventViewModel>();
            CreateMap<Event, EventBindingModel>()
                .ForMember(des => des.StartDate, opt => opt.MapFrom(sr => sr.StartDateTime))
                .ForMember(des => des.StartTime, opt => opt.MapFrom(sr => sr.StartDateTime));
            CreateMap<EventBindingModel, Event>();
            CreateMap<Event, AdminEventBindingModel>()
                .ForMember(des => des.StartDate, opt => opt.MapFrom(sr => sr.StartDateTime))
                .ForMember(des => des.StartTime, opt => opt.MapFrom(sr => sr.StartDateTime));
            CreateMap<AdminEventBindingModel, Event>();
            CreateMap<AdminEditEventBindingModel, Event>();
            CreateMap<Event, AdminEditEventBindingModel>();
        }

        private void ConfigureArticles()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(sr => sr.CategoryName.CategoryName));
            CreateMap<Article, ArticleBindingModel>();
            CreateMap<ArticleBindingModel, Article>();
            CreateMap<Article, AdminArticleBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.CategoryName.CategoryName));
            CreateMap<AdminArticleBindingModel, Article>();
            CreateMap<AdminEditArticleBindingModel, Article>()
                .ForMember(d => d.CategoryName, opt => opt.Ignore());
            CreateMap<Article, AdminEditArticleBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.CategoryName.CategoryName));
            CreateMap<AdminEditProductBindingModel, Product>()
                .ForMember(d => d.Category, opt => opt.Ignore());
            CreateMap<Product, AdminEditProductBindingModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(sr => sr.Category.CategoryName));
        }

        private void ConfigureProducts()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, AdminProductViewModel>();
            CreateMap<Product, ProductBindingModel>();
            CreateMap<ProductBindingModel, Product>();
            CreateMap<Product, AdminProductBindingModel>();
            CreateMap<AdminProductBindingModel, Product>()
                .ForMember(d => d.Category, opt => opt.Ignore());
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
