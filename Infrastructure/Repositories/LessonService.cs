using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.ViewModels.Common;
using Application.ViewModels.Lessons;
using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class LessonService : GenericRepositoryAsync<GuideLine>, ILessonService
    {
        public LessonService(ToeicOnlineContext dbContext) : base(dbContext)
        {
        }

        public async Task<ApiResult<PagedResult<LessonVm>>> GetGuidelinesPaging(GetLessonsRequest request)
        {
            var query = from ls in _dbContext.GuideLine
                        join lv in _dbContext.Level on ls.LevelId equals lv.Id
                        join tc in _dbContext.Teacher on ls.TeacherId equals tc.Id
                        join cate in _dbContext.Category on ls.categoryId equals cate.Id
                        where request.levelId == null || ls.LevelId == request.levelId
                        && request.teacherId == null || ls.TeacherId == request.teacherId
                        && request.categoryId == null || ls.categoryId == request.categoryId

                        select new { ls, lv, tc, cate};
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.lv.name.Contains(request.Keyword)
                || x.ls.Title.Contains(request.Keyword)
                || x.ls.Content.Contains(request.Keyword)
                || x.tc.UserName.Contains(request.Keyword)
                || x.cate.name.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LessonVm()
                {
                    Id = x.ls.Id,
                    Content = x.ls.Content,
                    Description = x.ls.Description,
                    Level = x.lv.name,
                    Title = x.ls.Title,
                    TeacherName = x.tc.UserName,
                    CategoryName = x.cate.name
                }).ToListAsync();

            //var listResult = await GetPagedReponseAsync(request.PageIndex, request.PageSize);
            //var lessons = _mapper.Map<List<LessonVm>>(listResult);
            var pagedResult = new PagedResult<LessonVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<LessonVm>>(pagedResult);
        }
    }
}
