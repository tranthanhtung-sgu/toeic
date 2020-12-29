using System;
using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Repositories
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {

        public CategoryRepositoryAsync(ToeicOnlineContext dbContext) : base(dbContext)
        {
        } 
    }
}
