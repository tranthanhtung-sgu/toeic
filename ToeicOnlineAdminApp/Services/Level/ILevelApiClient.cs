using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.Level;

namespace ToeicOnlineAdminApp.Services.Level
{
    public interface ILevelApiClient
    {
        Task<ApiResult<PagedResult<LevelViewModel>>> GetAll();
    }
}
