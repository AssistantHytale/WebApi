using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Constant;
using AssistantHytale.Persistence.Contract;
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

        public async Task<ResultWithValue<List<GuideDetail>>> GetAll()
        {
            List<GuideDetail> guideDetails = await _db.GuideDetails.ToListAsync();
            if (guideDetails == null || !guideDetails.Any()) return new ResultWithValue<List<GuideDetail>>(false, new List<GuideDetail>(), "Could not load GuideDetails");

            return new ResultWithValue<List<GuideDetail>>(true, guideDetails, string.Empty);
        }

        public async Task<ResultWithValueAndPagination<List<GuideDetail>>> GetActiveGuideDetails()
        {
            List<GuideDetail> guideDetails = await _db.GuideDetails
                .Where(gd => gd.Status == AdminApprovalStatus.Approved)
                .ToListAsync();
            if (guideDetails == null || !guideDetails.Any()) return new ResultWithValueAndPagination<List<GuideDetail>>(false, new List<GuideDetail>(), 0, 0, "Could not load GuideDetails");

            var storedProcResult = await StoredProcedureRepository.Execute(_db, 
                StoredProcedure.GuideDetailsWithUserInfo,
                new List<StoredProcedureParameter>
                {
                    StoredProcedureParameter.StringParam("@test", "test"),
                },
                (DataSet reader) =>
                {

                }
            );

            return new ResultWithValueAndPagination<List<GuideDetail>>(true, guideDetails, 0, 0, string.Empty);
        }

        public async Task<ResultWithValueAndPagination<List<GuideDetail>>> GetActiveGuideDetails(string lang)
        {
            List<GuideDetail> guideDetails = await _db.GuideDetails
                .Where(gd => gd.Status == AdminApprovalStatus.Approved)
                .Where(gd => gd.LanguageCode == lang)
                .ToListAsync();

            if (guideDetails == null || !guideDetails.Any()) return new ResultWithValueAndPagination<List<GuideDetail>>(false, new List<GuideDetail>(), 0, 0, "Could not load GuideDetails");

            return new ResultWithValueAndPagination<List<GuideDetail>>(true, guideDetails, 0, 0, string.Empty);
        }

        public async Task<ResultWithValue<GuideDetail>> Get(Guid guid)
        {
            GuideDetail guideDetail = await _db.GuideDetails
                .Where(gd => gd.Guid == guid)
                .FirstOrDefaultAsync();

            if (guideDetail == null) return new ResultWithValue<GuideDetail>(false, new GuideDetail(), $"Could not load GuideDetail for {guid}");

            return new ResultWithValue<GuideDetail>(true, guideDetail, string.Empty);
        }

        public async Task<Result> Add(GuideDetail addItem)
        {
            try
            {
                await _db.GuideDetails.AddAsync(addItem);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Edit(GuideDetail editItem)
        {
            //GuideDetail toEdit = await _db.GuideDetails.FirstAsync(g => g.Guid.Equals(editItem.Guid));
            //if (toEdit == null) return new Result(false, "GuideDetails does not exist in database");

            try
            {
                _db.GuideDetails.Update(editItem);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Delete(Guid guid)
        {
            GuideDetail toDelete = await _db.GuideDetails.FirstAsync(g => g.Guid.Equals(guid));
            if (toDelete == null) return new Result(false, "GuideDetail does not exist in database");

            try
            {
                _db.GuideDetails.Remove(toDelete);
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
