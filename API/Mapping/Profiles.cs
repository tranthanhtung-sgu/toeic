using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace API.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Level, LevelCreateRequest>();
        }
    }
}