namespace TodolistApi.Core.Domain.Abstraction
{
    public interface IPaginateRepository<T>
    {
        Task<IEnumerable<T>> GetByPage(int page, int limit);
        Task<int> GetTotalPage(int limit);
    }
}
