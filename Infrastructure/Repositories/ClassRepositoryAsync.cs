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
    public class ClassRepositoryAsync : GenericRepositoryAsync<Level> ,IClassRepositoryAsync
    {
        private readonly DbSet<Level> _classes;
        public ClassRepositoryAsync(ToeicOnlineContext dbContext) : base(dbContext)
        {
            _classes = dbContext.Set<Level>();
        }
    }
}