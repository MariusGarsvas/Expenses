// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ReceiversRepository.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Expenses.Dapper;
using Expenses.Module;

namespace Expenses.Repositories
{
    public class ReceiversRepository
    {
        private const string SqlLoad = @"
SELECT 
       [ReceiverId]
      ,[Name]
      ,[NameMatch]
      ,[PurposeTemplate]
      ,[MasterExpenceId]
      ,[MasterPercentage]
      ,[OtherExpenceId]
  FROM [Expences].[dbo].[Receivers]";

        private const string ParameterReceiverId = "@ReceiverId";
        private const string ParameterName = "@Name";
        private const string ParameterNameMatch = "@NameMatch";
        private const string ParameterPurposeTemplate = "@PurposeTemplate";
        private const string ParameterMasterExpenceId = "@MasterExpenceId";
        private const string ParameterMasterPercentage = "@MasterPercentage";
        private const string ParameterOtherExpenceId = "@OtherExpenceId";

        private readonly string SqlInsert = $@"INSERT INTO [dbo].[Receivers]
           ([ReceiverId]
           ,[Name]
           ,[NameMatch]
           ,[PurposeTemplate]
           ,[MasterExpenceId]
           ,[MasterPercentage]
           ,[OtherExpenceId])
     VALUES
           ({ParameterReceiverId}
           ,{ParameterName}
           ,{ParameterNameMatch}
           ,{ParameterPurposeTemplate}
           ,{ParameterMasterExpenceId}
           ,{ParameterMasterPercentage}
           ,{ParameterOtherExpenceId})";
        
        private readonly IDapperExecutor<Receiver> _dapperExecutor;

        public ReceiversRepository(IDapperExecutor<Receiver> dapperExecutor)
        {
            _dapperExecutor = dapperExecutor;
        }

        public List<Receiver> LoadAll()
        {
            return _dapperExecutor.QueryList(SqlLoad).ToList();
        }

        public void Insert(Receiver receiver)
        {
            if (receiver.ReceiverId != Guid.Empty)
            {
                throw new ArgumentException("Attempt to insert existing receiver");
            }
            
            receiver.ReceiverId = Guid.NewGuid();
            _dapperExecutor.Execute(
                SqlInsert,
                new DynamicParameters(
                    new Dictionary<string, object>
                    {
                        { ParameterReceiverId, receiver.ReceiverId },
                        { ParameterName, receiver.Name },
                        { ParameterNameMatch, receiver.NameMatch },
                        { ParameterPurposeTemplate, receiver.PurposeTemplate },
                        { ParameterMasterExpenceId, receiver.MasterExpenceId },
                        { ParameterMasterPercentage, receiver.MasterPercentage },
                        { ParameterOtherExpenceId, receiver.OtherExpenceId }
                    }));
        }
    }
}