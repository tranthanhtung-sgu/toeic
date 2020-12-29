using Application.ViewModels.Class;
using Application.ViewModels.Lessons;
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
            CreateMap<ClassCreateModel, Category>();
            CreateMap<ClassCreateModel, Category>().ReverseMap();
            CreateMap<LessonVm, GuideLine>();
            CreateMap<LessonVm, GuideLine>().ReverseMap(); ;
        }
    }
}