using System.Data;

namespace LearningTDD.InfraData.Dapper
{
    public interface IDapperContext
    {
        IDbConnection GetConnection { get; }
        IDbTransaction BeginTransaction();

        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object args);
        T Get<T>(int id) where T : class;

        Task<int> InsertAsync<T>(T entityToInsert, IDbTransaction transaction) where T : class;
        Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction transaction) where T : class;
        Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction transaction) where T : class;
    }
}
