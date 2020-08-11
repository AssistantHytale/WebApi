using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Repository
{
    public class GuideDetailRepository : IGuideDetailRepository
    {
        private readonly HytaleAssistantContext _db;

        public GuideDetailRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public async Task<ResultWithValue<List<GuideDetail>>> GetGuideDetails()
        {
            List<GuideDetail> guideDetails = await _db.GuideDetails.ToListAsync();
            if (guideDetails == null || !guideDetails.Any()) return new ResultWithValue<List<GuideDetail>>(false, new List<GuideDetail>(), "Could not load GuideDetails");

            return new ResultWithValue<List<GuideDetail>>(true, guideDetails, string.Empty);
        }

        public async Task<ResultWithValue<List<GuideDetail>>> GetActiveGuideDetails(LanguageType lang)
        {
            List<GuideMetaGuideDetail> guideMetaGuideDetails = await _db.GuideMetas
                .Where(gm => gm.Status == AdminApprovalStatus.Approved)
                .SelectMany(gm => gm.GuideMetaGuideDetails).ToListAsync();
            List<GuideDetail> guideDetails = guideMetaGuideDetails
                .Where(gmgd => gmgd.LanguageType == lang)
                .Select(gl => gl.GuideDetail)
                .ToList();

            if (guideDetails == null || !guideDetails.Any()) return new ResultWithValue<List<GuideDetail>>(false, new List<GuideDetail>(), "Could not load GuideDetails");

            return new ResultWithValue<List<GuideDetail>>(true, guideDetails, string.Empty);
        }

        public async Task<ResultWithValue<GuideDetail>> GetGuideDetail(Guid guid, LanguageType lang)
        {
            List<GuideMetaGuideDetail> guideMetaGuideDetails = await _db.GuideMetas
                .SelectMany(gm => gm.GuideMetaGuideDetails).ToListAsync();
            GuideDetail guideDetail = guideMetaGuideDetails.FirstOrDefault(gm => gm.GuideMetaGuid == guid)?.GuideDetail;
            
            if (guideDetail == null) return new ResultWithValue<GuideDetail>(false, new GuideDetail(), $"Could not load GuideDetail for {guid}");

            return new ResultWithValue<GuideDetail>(true, guideDetail, string.Empty);
        }

        public async Task<Result> CreateGuideDetail(Guid guideMetaGuid, GuideDetail guideDetail, LanguageType lang)
        {
            try
            {
                await _db.GuideDetails.AddAsync(guideDetail);
                await _db.GuideMetaGuideDetails.AddAsync(new GuideMetaGuideDetail
                {
                    GuideMetaGuid = guideMetaGuid,
                    GuideDetailGuid = guideDetail.Guid,
                    LanguageType = lang
                });
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> UpdateGuideDetail(GuideDetail guideDetail, LanguageType lang)
        {
            GuideMeta existingGuideMeta = await _db.GuideMetas.FirstAsync(g => g.Guid.Equals(guideDetail.Guid));
            if (existingGuideMeta == null) return new Result(false, "GuideMeta does not exist in database");

            try
            {
                GuideDetail existingGuideDetail = await _db.GuideMetaGuideDetails
                    .Where(gmgd => gmgd.GuideDetailGuid.Equals(guideDetail.Guid) && gmgd.LanguageType == lang)
                    .Select(gmgd => gmgd.GuideDetail).FirstOrDefaultAsync();

                if (existingGuideDetail == null) return await CreateGuideDetail(existingGuideMeta.Guid, guideDetail, lang);

                _db.GuideDetails.Update(guideDetail);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> DeleteGuideDetail(Guid guid)
        {
            GuideDetail guideToEdit = await _db.GuideDetails.FirstAsync(g => g.Guid.Equals(guid));
            if (guideToEdit == null) return new Result(false, "GuideDetail does not exist in database");

            try
            {
                _db.GuideDetails.Remove(guideToEdit);
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
