using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.Level;
using Domain.Models;
namespace Application.Interfaces
{
    public interface ILevelRepositoryAsync : IGenericRepositoryAsync<Level>
    {
        Task DeleteById(int Id);
        Task UpdateLevel(int Id, LevelViewModel level);
        Task<List<LevelViewModel>> GetAllLevel();
    }
}