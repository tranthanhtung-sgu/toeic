using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.Level;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ToeicOnlineAdminApp.Services.Level
{
    public class LevelApiClient : BaseApiClient,ILevelApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LevelApiClient(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base (httpContextAccessor, configuration)
        {  
        }

        public async Task<ApiResult<PagedResult<LevelViewModel>>> GetAll()
        {
            var data = await GetAsync<ApiResult<PagedResult<LevelViewModel>>> (
                $"/api/Level");
            return data;
        }
    }
}
