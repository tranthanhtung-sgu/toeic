using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Level;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public LevelRepositoryAsync(ToeicOnlineContext dbContext, IMapper mapper) : base(dbContext)
        {
            _levels = dbContext.Set<Level>();
            _mapper = mapper;
        }

        public async Task DeleteById(int Id)
        {
            var level = await GetByIdAsync(Id);
            _levels.Remove(level);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLevel(int Id, LevelViewModel level)
        {
            var level1 = _mapper.Map<Level>(level);
            var result = await GetByIdAsync(Id);
            result.sign = level.sign;
            result.name = level.name;
            await UpdateAsync(result);
        }
    }
}