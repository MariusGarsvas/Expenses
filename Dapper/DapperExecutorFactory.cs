// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DapperExecutorFactory.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System.Data;

namespace Expenses.Dapper
{
    public class DapperExecutorFactory : IDapperExecutorFactory
    {
        private readonly IDbConnection _sqlConnection;

        public DapperExecutorFactory(IDbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public IDapperExecutor<T> Create<T>()
        {
            return new DapperExecutor<T>(_sqlConnection);
        }
    }
}