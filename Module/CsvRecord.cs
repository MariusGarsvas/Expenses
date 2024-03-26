// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CsvRecord.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;

namespace Expenses.Module
{
    public class CsvRecord
    {
        public Guid Id { get; set; }
        public string OperationType { get; set; }
        public string DateString { get; set; }
        public string TimeString { get; set; }
        public decimal Amount { get; set; }
        public string Direction { get; set; } // Credit or Debit
        public string DocumentNo { get; set; }
        public string OperationId { get; set; }
        public string Purpose { get; set; }
        
        public string ReceiverAccountNo { get; set; }
        public string Receiver { get; set; }

        public Direction DirectionValue => (Direction)Direction[0];
    }
}