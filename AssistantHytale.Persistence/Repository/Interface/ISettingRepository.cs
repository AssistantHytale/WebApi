using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface ISettingRepository
    {
        Task<ResultWithValue<List<Setting>>> GetAllSettings();
        Task<ResultWithValue<List<Setting>>> GetAllSettings(SettingType settingType);
        Task<ResultWithValue<Setting>> GetCurrentSetting(SettingType settingType);
        Task<Result> AddSetting(Setting addSetting);
        Task<Result> EditSetting(Setting editSetting);
        Task<Result> DeleteSetting(Guid guid);
        Task<ResultWithValue<T>> GetCurrentSetting<T>(SettingType settingType);
    }
}