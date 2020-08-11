using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Repository
{
    public class GuideMetaRepository : IGuideMetaRepository
    {
        private readonly HytaleAssistantContext _db;

        public GuideMetaRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public async Task<ResultWithValue<List<GuideMeta>>> GetGuideMetas()
        {
            List<GuideMeta> guideMetas = await _db.GuideMetas.ToListAsync();
            if (guideMetas == null || !guideMetas.Any()) return new ResultWithValue<List<GuideMeta>>(false, new List<GuideMeta>(), "Could not load GuideMetas");

            return new ResultWithValue<List<GuideMeta>>(true, guideMetas, string.Empty);
        }

        public async Task<ResultWithValue<List<GuideMeta>>> GetGuideMetasForUser(Guid userGuid)
        {
            List<GuideMeta> guideMetas = await _db.GuideMetas
                .Where(gm => gm.UserGuid.Equals(userGuid))
                .ToListAsync();
            if (guideMetas == null || !guideMetas.Any()) return new ResultWithValue<List<GuideMeta>>(false, new List<GuideMeta>(), "Could not load GuideMetas");

            return new ResultWithValue<List<GuideMeta>>(true, guideMetas, string.Empty);
        }

        public async Task<ResultWithValue<GuideMeta>> GetGuideMeta(Guid guid)
        {
            GuideMeta latestGuideMeta = await _db.GuideMetas.FirstOrDefaultAsync(gm => gm.Guid == guid);
            if (latestGuideMeta == null) return new ResultWithValue<GuideMeta>(false, new GuideMeta(), $"Could not load GuideMeta for {guid}");

            return new ResultWithValue<GuideMeta>(true, latestGuideMeta, string.Empty);
        }

        public async Task<Result> CreateGuideMeta(GuideMeta guideMeta)
        {
            try
            {
                await _db.GuideMetas.AddAsync(guideMeta);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> UpdateGuideMeta(GuideMeta guideMeta)
        {
            GuideMeta guideToEdit = await _db.GuideMetas.FirstAsync(g => g.Guid.Equals(guideMeta.Guid));
            if (guideToEdit == null) return new Result(false, "GuideMeta does not exist in database");

            guideToEdit.Likes = guideMeta.Likes;
            guideToEdit.Views = guideMeta.Views;
            //guideToEdit.Status = guideMeta.FileRelativePath;

            try
            {
                _db.GuideMetas.Update(guideToEdit);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> DeleteGuideMeta(Guid guid)
        {
            GuideMeta guideToEdit = await _db.GuideMetas.FirstAsync(g => g.Guid.Equals(guid));
            if (guideToEdit == null) return new Result(false, "GuideMeta does not exist in database");
            
            try
            {
                _db.GuideMetas.Remove(guideToEdit);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> LikeGuide(Guid guid)
        {
            GuideMeta guideMeta = await _db.GuideMetas.FirstAsync(u => u.Guid.Equals(guid));
            if (guideMeta == null) return new Result(false, "Guide does not exist in database");

            guideMeta.Likes += 1;

            try
            {
                _db.GuideMetas.Update(guideMeta);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        private async Task<Result> AddView(GuideMeta guideMeta)
        {
            guideMeta.Views += 1;

            try
            {
                _db.GuideMetas.Update(guideMeta);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
