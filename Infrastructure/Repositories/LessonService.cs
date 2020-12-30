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
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Application.System.Common;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Repositories
{
    public class LessonService : GenericRepositoryAsync<GuideLine>, ILessonService
    {
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public LessonService(ToeicOnlineContext dbContext, IStorageService storageService) : base(dbContext)
        {
            _storageService = storageService;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }


        public async Task<ApiResult<int>> CreateLesson(CreateLessonRequest request)
        {
            var lesson = new GuideLine()
            {
                Content = request.Content,
                Description = request.Description,
                Title = request.Title,
                categoryId = request.categoryId,
                LevelId = request.levelId
            };
            //Save image
            if (request.ThumbnailsImage != null)
            {
                lesson.images = new List<GuideLineImage>()
                {
                    new GuideLineImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailsImage.Length,
                        ImagePath = "ccc",
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _dbContext.GuideLine.Add(lesson);
            await _dbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(lesson.Id);
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

        public async Task<LessonVm> GetById(int lessonId)
        {
            var query = await (from ls in _dbContext.GuideLine
                        join lv in _dbContext.Level on ls.LevelId equals lv.Id
                        join tc in _dbContext.Teacher on ls.TeacherId equals tc.Id
                        join cate in _dbContext.Category on ls.categoryId equals cate.Id
                        where ls.Id == lessonId
                        select new { ls, lv, tc, cate }).FirstOrDefaultAsync();
            var image = await _dbContext.GuideLineImages.Where(x => x.GuideLineId == lessonId && x.IsDefault == true).FirstOrDefaultAsync();

            var lessonViewModel = new LessonVm()
            {
                Id = query.ls.Id,
                Title = query.ls.Title,
                Content = query.ls.Content,
                Description = query.ls.Description,
                CategoryName = query.cate.name,
                Level = query.lv.name,
                TeacherName = query.tc.UserName,
                ThumbnailImage = image != null ? image.ImagePath : "no-image.jpg"
            };
            return lessonViewModel;
        }
    }
}
