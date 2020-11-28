using System.Threading.Tasks;
using Application.ViewModels.Class;
using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IClassRepositoryAsync : IGenericRepositoryAsync<Class>
    {
        Task DeleteById(int Id);
        Task UpdateClass(int Id, ClassCreateModel classCreateModel);
    }
}