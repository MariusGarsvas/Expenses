// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DapperExecutor.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace Expenses.Dapper
{
    public class DapperExecutor<T> : IDapperExecutor<T>
    {
        private const int MaxRetries = 10;

        private const int WaitSeconds = 3;

        private const int NoTimeout = 0;

        private readonly IDbConnection _sqlConnection;

        public DapperExecutor(IDbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        private IDbConnection OpenConnection
        {
            get
            {
                lock (_sqlConnection)
                {
                    var connectAttempt = MaxRetries;
                    while (_sqlConnection.State != ConnectionState.Open && (connectAttempt--) > 0)
                    {
                        _sqlConnection.Open();
                        if (_sqlConnection.State == ConnectionState.Open)
                        {
                            break;
                        }

                        Task.Delay(TimeSpan.FromSeconds(WaitSeconds)).Wait();
                    }

                    return _sqlConnection;
                }
            }
        }

        public T QuerySingle(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return OpenConnection.QuerySingleOrDefault<T>(sql, parameters, transaction, commandTimeout ?? NoTimeout);
        }

        public async Task<T> QuerySingleAsync(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await OpenConnection.QuerySingleOrDefaultAsync<T>(sql, parameters, transaction, commandTimeout ?? NoTimeout);
        }

        public IEnumerable<T> QueryList(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return OpenConnection.Query<T>(sql, parameters, transaction, false, commandTimeout ?? NoTimeout);
        }

        public async Task<IEnumerable<T>> QueryListAsync(
            string sql,
            DynamicParameters parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return await OpenConnection.QueryAsync<T>(
                       new CommandDefinition(
                           sql,
                           parameters,
                           transaction,
                           commandTimeout ?? NoTimeout,
                           null,
                           CommandFlags.None,
                           cancellationToken));
        }

        public TScalar ExecuteScalar<TScalar>(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return OpenConnection.ExecuteScalar<TScalar>(sql, parameters, transaction, commandTimeout ?? NoTimeout);
        }

        public async Task<TScalar> ExecuteScalarAsync<TScalar>(string sql, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await OpenConnection.ExecuteScalarAsync<TScalar>(sql, parameters, transaction, commandTimeout ?? NoTimeout);
        }

        /// <summary>
        /// Executes command async
        /// </summary>
        /// <param name="sql">Sql command to execute</param>
        /// <param name="parameters">Command parameters</param>
        /// <param name="transaction">Command transaction</param>
        /// <param name="commandTimeout">Command timeout</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Number of rows affected</returns>
        public async Task<int> ExecuteAsync(
            string sql,
            DynamicParameters parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return await OpenConnection.ExecuteAsync(
                       new CommandDefinition(
                           sql,
                           parameters,
                           transaction,
                           commandTimeout ?? NoTimeout,
                           null,
                           CommandFlags.None,
                           cancellationToken));
        }

        public int Execute(string sql,
            DynamicParameters parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return OpenConnection.Execute(new CommandDefinition(
                sql,
                parameters,
                transaction,
                commandTimeout ?? NoTimeout,
                null,
                CommandFlags.None,
                cancellationToken));
        }
    }
}