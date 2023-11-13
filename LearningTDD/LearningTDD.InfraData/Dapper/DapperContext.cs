using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTDD.InfraData.Dapper
{
    public class DapperContext : IDapperContext
    {
        public IDapperContext Connection { get; set; }
        //public DapperContext(IParameters appParameters)
        //{
        //    Connection = appParameters.Connection;
        //}

        public IDbConnection GetConnection => Connection.GetConnection;
        public IDbTransaction BeginTransaction() => Connection.BeginTransaction();

        public Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction transaction) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync<T>(T entityToInsert, IDbTransaction transaction) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object args)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction transaction) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
