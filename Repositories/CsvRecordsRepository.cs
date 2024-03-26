// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CsvRecordsRepository.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Dapper;
using Expenses.Dapper;
using Expenses.Module;

namespace Expenses.Repositories
{
    public class CsvRecordsRepository
    {
        private const string ParameterOperationType = "@OperationType";
        private const string ParameterDate = "@Date";
        private const string ParameterTimeStamp = "@TimeStamp";
        private const string ParameterAmount = "@Amount";
        private const string ParameterDirection = "@Direction";
        private const string ParameterDocumentNo = "@DocumentNo";
        private const string ParameterOperationId = "@OperationId";
        private const string ParameterPurpose = "@Purpose";
        private const string ParameterReceiver = "@Receiver";
        
        private const string ParameterExpenceId = "@ExpenceId";
        private const string ParameterReceiverId = "@ReceiverId";
        private const string ParameterExpenceTypeId = "@ExpenceTypeId";
        
        
        private const string SqlGetIdByOperationId = @"SELECT top 1 * FROM [dbo].[Expences] WHERE OperationId="+ParameterOperationId;
        
        private readonly string SqlInsert = $@"
INSERT INTO [dbo].[Expences]
           ([ExpenceId]
           ,[OperationType]
           ,[Date]
           ,[TimeStamp]
           ,[Amount]
           ,[Direction]
           ,[DocumentNo]
           ,[OperationId]
           ,[Purpose]
           ,[Receiver])
     VALUES
           ({ParameterExpenceId}
           ,{ParameterOperationType}
           ,{ParameterDate}
           ,{ParameterTimeStamp}
           ,{ParameterAmount}
           ,{ParameterDirection}
           ,{ParameterDocumentNo}
           ,{ParameterOperationId}
           ,{ParameterPurpose}
           ,{ParameterReceiver})";

        private readonly string SqlInsertCalculated = $@"
INSERT INTO [dbo].[CalculatedRows]
           ([ExpenceId]
           ,[ReceiverId]
           ,[ExpenceTypeId]
           ,[Amount]
           ,[Date])
     VALUES
           ({ParameterExpenceId}
           ,{ParameterReceiverId}
           ,{ParameterExpenceTypeId}
           ,{ParameterAmount}
           ,{ParameterDate})";
        
        private readonly IDapperExecutor<CsvRecord> _dapperExecutor;

        public CsvRecordsRepository(IDapperExecutor<CsvRecord> dapperExecutor)
        {
            _dapperExecutor = dapperExecutor;
        }

        public bool Exists(string operationId)
        {
            var recordId = _dapperExecutor.ExecuteScalar<Guid?>(
                SqlGetIdByOperationId,
                new DynamicParameters(
                        new Dictionary<string, object>
                        { 
                            { ParameterOperationId, operationId }
                        }));

            return recordId.HasValue;
        }

        public void Insert(CsvRecord record, Receiver receiver)
        {
            var timeStamp = DateTime.ParseExact(
                $"{record.DateString} {record.TimeString}",
                $"{Format.Date} {Format.Time}",
                CultureInfo.InvariantCulture);
            
            record.Id = Guid.NewGuid();
            
            _dapperExecutor.Execute(
                SqlInsert,
                new DynamicParameters(
                    new Dictionary<string, object>
                    {
                        { ParameterExpenceId, record.Id },
                        { ParameterOperationType, record.OperationType },
                        { ParameterDate, timeStamp.Date },
                        { ParameterTimeStamp, timeStamp },
                        { ParameterAmount, record.Amount },
                        { ParameterDirection, record.Direction },
                        { ParameterDocumentNo, record.DocumentNo },
                        { ParameterOperationId, record.OperationId },
                        { ParameterPurpose, record.Purpose },
                        { ParameterReceiver, record.Receiver }
                    }
                ));

            InsertCalculatedData(record, receiver, receiver.MasterExpenceId, receiver.MasterPercentage, timeStamp);
            if (receiver.OtherExpenceId.HasValue && receiver.OtherPercentage > 0)
            {
                InsertCalculatedData(record, receiver, receiver.OtherExpenceId.Value, receiver.OtherPercentage, timeStamp);
            }
        }

        private void InsertCalculatedData(CsvRecord record, Receiver receiver, int expenceTypeId, decimal percentage, DateTime date)
        {
            var amount = (record.Amount * percentage) / 100;
            _dapperExecutor.Execute(
                SqlInsertCalculated,
                new DynamicParameters(
                    new Dictionary<string, object>
                    {
                        { ParameterExpenceId, record.Id },
                        { ParameterReceiverId, receiver.ReceiverId },
                        { ParameterExpenceTypeId, expenceTypeId },
                        { ParameterAmount, amount },
                        { ParameterDate, date },
                    }
                ));
        }
    }
}