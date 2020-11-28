using Application.ViewModels.Class;
using Application.ViewModels.Level;
using AutoMapper;
using Domain.Models;

namespace API.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<LevelViewModel, Level>();
            CreateMap<LevelViewModel, Level>().ReverseMap();
            CreateMap<ClassCreateModel, Class>();
            CreateMap<ClassCreateModel, Class>().ReverseMap();
        }
    }
}