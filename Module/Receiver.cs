// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Receiver.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using CsvHelper.Configuration.Attributes;

namespace Expenses.Module
{
    public class Receiver
    {
        public Guid ReceiverId { get; set; }
        public string Name { get; set; }
        public string NameMatch { get; set; }
        public string PurposeTemplate { get; set; }
        public int MasterExpenceId { get; set; }
        public decimal MasterPercentage { get; set; }
        public int? OtherExpenceId { get; set; }

        public decimal OtherPercentage => 100 - MasterPercentage;
    }
}