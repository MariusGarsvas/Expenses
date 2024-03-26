// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDapperExecutor.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace Expenses.Dapper
{
    public interface IDapperExecutor<T>
    {
        T QuerySingle(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<T> QuerySingleAsync(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);

        IEnumerable<T> QueryList(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<IEnumerable<T>> QueryListAsync(
            string sql,
            DynamicParameters parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CancellationToken cancellationToken = new CancellationToken());

        TScalar ExecuteScalar<TScalar>(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<TScalar> ExecuteScalarAsync<TScalar>(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<int> ExecuteAsync(
            string sql,
            DynamicParameters parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CancellationToken cancellationToken = new CancellationToken());
        
        int Execute(
            string sql,
            DynamicParameters parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CancellationToken cancellationToken = new CancellationToken());
    }
}