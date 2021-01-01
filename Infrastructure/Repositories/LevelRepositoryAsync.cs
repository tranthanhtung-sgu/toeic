using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Common;
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
            _levels = _dbContext.Set<Level>();
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
            var result = await GetByIdAsync(Id);
            result.sign = level.sign;
            result.name = level.name;
            await UpdateAsync(result);
        }
        public async Task<List<LevelViewModel>> GetAllLevel ()
        {
            var levels = await _dbContext.Level
                .Select(x => new LevelViewModel()
                {
                    Id = x.Id,
                    name = x.name,
                    sign = x.sign
                }).ToListAsync();
            return levels;
        }
    }
}