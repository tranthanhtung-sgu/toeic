using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels.Category;
using Application.ViewModels.Common;

namespace ToeicOnlineAdminApp.Services.Category
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll();
    }
}
