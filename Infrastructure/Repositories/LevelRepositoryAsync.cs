using System.Collections.Generic;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LevelRepositoryAsync : GenericRepositoryAsync<Level> ,ILevelRepositoryAsync
    {
        private readonly DbSet<Level> _levels;
        public LevelRepositoryAsync(ToeicOnlineContext dbContext) : base(dbContext)
        {
            _levels = dbContext.Set<Level>();
        }
    }
}