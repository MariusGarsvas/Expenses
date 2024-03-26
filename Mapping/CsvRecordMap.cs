// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CsvRecordMap.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using CsvHelper.Configuration;
using Expenses.Module;

namespace Expenses.Mapping
{
    public sealed class CsvRecordMap : ClassMap<CsvRecord>
    {
        public CsvRecordMap()
        {
            Map(m => m.OperationType).Index(0);
            Map(m => m.DateString).Index(1);
            Map(m => m.TimeString).Index(2);
            Map(m => m.Amount).Index(3);
            Map(m => m.Direction).Index(5);
            Map(m => m.DocumentNo).Index(8);
            Map(m => m.OperationId).Index(9);
            Map(m => m.Purpose).Index(12);
            Map(m => m.ReceiverAccountNo).Index(15);
            Map(m => m.Receiver).Index(16);
        }
    }
}