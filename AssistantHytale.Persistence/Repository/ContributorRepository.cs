using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;

namespace AssistantHytale.Persistence.Repository
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly HytaleAssistantContext _db;

        public ContributorRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public async Task<ResultWithValue<List<Contributor>>> GetAll()
        {
            List<Contributor> contributors = await _db.Contributors.OrderBy(f => f.SortRank).ToListAsync();
            if (contributors == null) return new ResultWithValue<List<Contributor>>(false, new List<Contributor>(), "Could not load Contributors");

            return new ResultWithValue<List<Contributor>>(true, contributors, string.Empty);
        }

        public Task<ResultWithValue<Contributor>> Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Add(Contributor addItem)
        {
            try
            {
                await _db.Contributors.AddAsync(addItem);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Edit(Contributor editItem)
        {
            try
            {
                _db.Contributors.Update(editItem);
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
            try
            {
                Contributor toDelete = await _db.Contributors.FirstAsync(d => d.Guid.Equals(guid));
                if (toDelete == null) return new Result(false, "Could not find the specified Guid");

                _db.Contributors.Remove(toDelete);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<ResultWithValue<int>> NumberOfContributors()
        {
            try
            {
                int numberOfContributors = await _db.Contributors.CountAsync();
                return new ResultWithValue<int>(true, numberOfContributors, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<int>(false, 0, ex.Message);
            }
        }
    }
}
