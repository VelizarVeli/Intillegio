using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Models;

namespace Intillegio.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureProjects();
            ConfigureClients();
        }

        private void ConfigureProjects()
        {
            CreateMap<Project, LastProjectsViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
           
        }

        private void ConfigureClients()
        {
            CreateMap<Client, ClientViewModel>();
        }
    }
}
