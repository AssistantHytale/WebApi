using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Constant;
using AssistantHytale.Persistence.Contract;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Repository
{
    public class GuideContentRepository: IGuideContentRepository
    {
        private readonly HytaleAssistantContext _db;

        public GuideContentRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public Task<ResultWithValueAndPagination<List<GuideContent>>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultWithValue<GuideContent>> Get(Guid guid)
        {
            GuideContent guideDetail = await _db.GuideContents
                .Where(gd => gd.Guid == guid)
                .FirstOrDefaultAsync();

            if (guideDetail == null) return new ResultWithValue<GuideContent>(false, new GuideContent(), $"Could not load GuideContent for {guid}");

            return new ResultWithValue<GuideContent>(true, guideDetail, string.Empty);
        }

        public async Task<Result> Add(GuideContent addItem)
        {
            try
            {
                await _db.GuideContents.AddAsync(addItem);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Edit(GuideContent editItem)
        {
            //GuideDetail toEdit = await _db.GuideDetails.FirstAsync(g => g.Guid.Equals(editItem.Guid));
            //if (toEdit == null) return new Result(false, "GuideDetails does not exist in database");

            try
            {
                _db.GuideContents.Update(editItem);
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
            GuideContent toDelete = await _db.GuideContents.FirstAsync(g => g.Guid.Equals(guid));
            if (toDelete == null) return new Result(false, "GuideContent does not exist in database");

            try
            {
                _db.GuideContents.Remove(toDelete);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<ResultWithValue<GuideFullContent>> GetFullContentById(Guid guid)
        {
            GuideFullContent guideDetails = new GuideFullContent();

            Result storedProcResult = await StoredProcedureRepository.Execute(_db,
                StoredProcedure.GetGuideContentWithSections,
                new List<StoredProcedureParameter>
                {
                    StoredProcedureParameter.GuidParam("@guideContent", guid),
                },
                dbDataSetReader: dataSet =>
                {
                    DataRow contentRow = dataSet.Tables[0].Rows[0];
                    DataTable sectionTable = dataSet.Tables[1];
                    List<DataTable> sectionItemTables = new List<DataTable>();
                    for (int sectionItemTableIndex = 0; sectionItemTableIndex < dataSet.Tables.Count; sectionItemTableIndex++)
                    {
                        if (sectionItemTableIndex < 2) continue;
                        sectionItemTables.Add(dataSet.Tables[sectionItemTableIndex]);
                    }

                    guideDetails = GuideFullContent.FromDataTable(contentRow, sectionTable, sectionItemTables);
                }
            );

            return ResultWithValue<GuideFullContent>.FromResult(storedProcResult, guideDetails);
        }
    }
}
