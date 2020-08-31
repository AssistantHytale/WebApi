using AssistantHytale.Domain.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;

namespace AssistantHytale.Persistence.Repository
{
    public class ServerRepository : IServerRepository
    {
        private readonly int _pageSize;
        private readonly HytaleAssistantContext _db;

        public ServerRepository(HytaleAssistantContext db)
        {
            _db = db;
            _pageSize = 20;
        }

        public async Task<ResultWithValueAndPagination<List<Server>>> GetAll(int page)
        {
            List<Server> servers = await _db.Servers
                .Where(s => s.ApprovalStatus == AdminApprovalStatus.Approved)
                .OrderBy(f => f.CreateDateTime)
                .Skip(page * _pageSize)
                .Take(20)
                .ToListAsync();
            if (servers == null) return new ResultWithValueAndPagination<List<Server>>(false, new List<Server>(), 0, 0,0, "Could not load Servers");
            // TODO Pagination
            return new ResultWithValueAndPagination<List<Server>>(true, servers, page, 0, 0, string.Empty);
        }

        public async Task<ResultWithValue<Server>> Get(Guid guid)
        {
            Server server = await _db.Servers
                .Where(s => s.Guid.Equals(guid))
                .FirstOrDefaultAsync();
            if (server == null) return new ResultWithValue<Server>(false, new Server(), "Could not load specified Server");

            return new ResultWithValue<Server>(true, server, string.Empty);
        }

        public async Task<Result> Add(Server addServer)
        {
            try
            {
                await _db.Servers.AddAsync(addServer);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Edit(Server editServer)
        {
            try
            {
                _db.Servers.Update(editServer);
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
                Server toServer = await _db.Servers.FirstAsync(d => d.Guid.Equals(guid));
                if (toServer == null) return new Result(false, "Could not find the specified Guid");

                _db.Servers.Remove(toServer);
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