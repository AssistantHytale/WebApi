using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface ISettingRepository: IBaseRepository<Setting>
    {
        Task<ResultWithValue<List<Setting>>> GetAllSettings(SettingType settingType);
        Task<ResultWithValue<Setting>> GetCurrentSetting(SettingType settingType);
        Task<ResultWithValue<T>> GetCurrentSetting<T>(SettingType settingType);
    }
}