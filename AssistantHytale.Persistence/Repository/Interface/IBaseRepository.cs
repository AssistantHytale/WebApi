using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        Task<ResultWithValue<List<T>>> GetAll();
        Task<ResultWithValue<T>> Get(Guid guid);
        Task<Result> Add(T addItem);
        Task<Result> Edit(T editItem);
        Task<Result> Delete(Guid guid);
    }
}
