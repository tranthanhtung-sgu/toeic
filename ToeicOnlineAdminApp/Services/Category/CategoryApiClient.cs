using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.ViewModels.Category;
using Application.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ToeicOnlineAdminApp.Services.Category
{
    public class CategoryApiClient : BaseApiClient,ICategoryApiClient
    {

        public CategoryApiClient(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base(httpContextAccessor, configuration)
        {
        }

        public async Task<List<CategoryVm>> GetAll()
        {
            var data = await GetAsync<List<CategoryVm>>(
                $"/api/category");
            return data;

        }
    }
}
