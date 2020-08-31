using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Contract;
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

        public Task<ResultWithValueAndPagination<List<GuideDetail>>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultWithValueAndPagination<List<GuideDetailsWithUserInfo>>> GetActiveGuideDetails(int page) => await GetActiveGuideDetails(page, string.Empty);

        public async Task<ResultWithValueAndPagination<List<GuideDetailsWithUserInfo>>> GetActiveGuideDetails(int page, string lang)
        {
            Pagination pagination = new Pagination();
            List<GuideDetailsWithUserInfo> guideDetails = new List<GuideDetailsWithUserInfo>();

            Result storedProcResult = await StoredProcedureRepository.Execute(_db,
                StoredProcedure.GuideDetailsWithUserInfo,
                new List<StoredProcedureParameter>
                {
                    StoredProcedureParameter.IntParam("@page", 1),
                    StoredProcedureParameter.IntParam("@pageSize", 20),
                    StoredProcedureParameter.StringParam("@langCode", lang),
                },
                dbDataSetReader: dataSet =>
                {
                    pagination = Pagination.FromDataRow(dataSet.Tables[0].Rows[0]);

                    DataTable resultsTable = dataSet.Tables[1];
                    foreach (DataRow row in resultsTable.Rows)
                    {
                        guideDetails.Add(GuideDetailsWithUserInfo.FromDataRow(row));
                    }
                }
            );

            return storedProcResult.PaginationFromResult(guideDetails, pagination);
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
