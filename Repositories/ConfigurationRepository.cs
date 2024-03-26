// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ConfigurationRepository.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Expenses.Dapper;
using Expenses.Module;

namespace Expenses.Repositories
{
    public class ConfigurationRepository
    {
        private const string SqlGetOwnAccounts = @"select [AccountNo] from [OwnAccounts]";
        private const string SqlGetExpenceTypes = @"SELECT [Id],[Name] FROM [ExpenceTypes]";
        
        private readonly IDapperExecutorFactory _dapperExecutorFactory;

        public ConfigurationRepository(IDapperExecutorFactory dapperExecutorFactory)
        {
            _dapperExecutorFactory = dapperExecutorFactory;
        }

        public List<string> GetOwnAccounts()
        {
            var dapper = _dapperExecutorFactory.Create<string>();
            var retVal = dapper.QueryList(SqlGetOwnAccounts).ToList();
            return retVal;
        }

        public List<ExpenceType> GetExpenceTypes()
        {
            var dapper = _dapperExecutorFactory.Create<ExpenceType>();
            var retVal = dapper.QueryList(SqlGetExpenceTypes).ToList();
            return retVal;
        }
    }
}