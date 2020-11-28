using System;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.ViewModels.Class;
using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClassRepositoryAsync : GenericRepositoryAsync<Class> ,IClassRepositoryAsync
    {
        private readonly DbSet<Class> _classes;
        private readonly IMapper _mapper;
        public ClassRepositoryAsync(ToeicOnlineContext dbContext, IMapper mapper) : base(dbContext)
        {
            _classes = dbContext.Set<Class>();
            _mapper = mapper;
            
        }
        public async Task DeleteById(int Id)
        {
            var lophoc = await GetByIdAsync(Id);
            _classes.Remove(lophoc);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClass(int Id, ClassCreateModel classCreateModel)
        {
            var lophoc = _mapper.Map<Class>(classCreateModel);
            var result = await GetByIdAsync(Id);
            result.name = classCreateModel.name;
            result.price = classCreateModel.price;
            result.startDate = classCreateModel.startDate;
            result.endDate = classCreateModel.endDate;
            await UpdateAsync(result);
        }
    }
}