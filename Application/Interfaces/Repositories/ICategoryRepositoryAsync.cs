using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels.Category;
using Application.ViewModels.Common;
using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface ICategoryRepositoryAsync : IGenericRepositoryAsync<Category>
    {
        Task<List<CategoryVm>> GetAllCategory();
    }
}
