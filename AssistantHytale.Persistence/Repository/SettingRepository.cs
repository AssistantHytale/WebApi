using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using Newtonsoft.Json;

namespace AssistantHytale.Persistence.Repository
{
    public class SettingRepository : ISettingRepository
    {
        private readonly HytaleAssistantContext _db;

        public SettingRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public async Task<ResultWithValue<List<Setting>>> GetAllSettings()
        {
            try
            {
                List<Setting> settings = await _db.Settings.ToListAsync();
                return new ResultWithValue<List<Setting>>(true, settings, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<List<Setting>>(false, new List<Setting>(), ex.Message);
            }
        }

        public async Task<ResultWithValue<List<Setting>>> GetAllSettings(SettingType settingType)
        {
            try
            {
                List<Setting> settings = await _db.Settings.Where(s => s.Type == settingType).ToListAsync();
                return new ResultWithValue<List<Setting>>(true, settings, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<List<Setting>>(false, new List<Setting>(), ex.Message);
            }
        }

        public async Task<ResultWithValue<Setting>> GetCurrentSetting(SettingType settingType)
        {
            try
            {
                Setting setting = await _db.Settings
                    .Where(v => v.Type == settingType)
                    .Where(v => DateTime.Now > v.ActiveDate)
                    .OrderByDescending(v => v.ActiveDate).FirstOrDefaultAsync();
                if (setting == null) return new ResultWithValue<Setting>(false, new Setting(), $"Could not load current setting for {settingType}");

                return new ResultWithValue<Setting>(true, setting, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<Setting>(false, new Setting(), ex.Message);
            }
        }

        public async Task<ResultWithValue<T>> GetCurrentSetting<T>(SettingType settingType)
        {
            try
            {
                Setting setting = await _db.Settings
                    .Where(v => v.Type == settingType)
                    .Where(v => DateTime.Now > v.ActiveDate)
                    .OrderByDescending(v => v.ActiveDate).FirstOrDefaultAsync();
                if (setting == null) return new ResultWithValue<T>(false, default, $"Could not load current setting for {settingType}");

                T result = JsonConvert.DeserializeObject<T>(setting.Value);

                return new ResultWithValue<T>(true, result, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<T>(false, default, ex.Message);
            }
        }

        public async Task<Result> AddSetting(Setting addSetting)
        {
            try
            {
                await _db.Settings.AddAsync(addSetting);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> EditSetting(Setting editSetting)
        {
            try
            {
                _db.Settings.Update(editSetting);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> DeleteSetting(Guid guid)
        {
            try
            {
                Setting settingToDelete = await _db.Settings.FirstAsync(d => d.Guid.Equals(guid));
                if (settingToDelete == null) return new Result(false, "Could not find the specified Guid");

                _db.Settings.Remove(settingToDelete);
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
