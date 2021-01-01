using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.ViewModels.Category;
using Application.ViewModels.Common;
using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        private readonly DbSet<Category> _category;
        private readonly IMapper _mapper;
        public CategoryRepositoryAsync(ToeicOnlineContext dbContext, IMapper mapper) : base(dbContext)
        {
            _category = dbContext.Set<Category>();
            _mapper = mapper;
        }
        public async Task<List<CategoryVm>> GetAllCategory()
        {
            var categories = await _dbContext.Category
                .Select(x => new CategoryVm()
                {
                    Id = x.Id,
                    name = x.name
                }).ToListAsync();
            return categories;
        }
    }
}
