// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDapperExecutorFactory.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Expenses.Dapper
{
    public interface IDapperExecutorFactory
    {
        IDapperExecutor<T> Create<T>();
    }
}