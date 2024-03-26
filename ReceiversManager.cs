// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ReceiversManager.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Expenses.Dapper;
using Expenses.Module;
using Expenses.Repositories;

namespace Expenses
{
    public class ReceiversManager
    {
        private ReceiversRepository _receiversRepository;
        private List<Receiver> _receivers;
        
        public ReceiversManager(IDapperExecutorFactory dapperExecutorFactory)
        {
            _receiversRepository = new ReceiversRepository(dapperExecutorFactory.Create<Receiver>());
            _receivers = _receiversRepository.LoadAll();
        }

        public Receiver GetMatchingReceiver(CsvRecord record)
        {
            var matchingNameReceivers = _receivers
                .Where(x => x.NameMatch.Equals(record.Receiver, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingNameReceivers.Count == 1)
            {
                var receiver = matchingNameReceivers.First();
                if (string.IsNullOrEmpty(receiver.PurposeTemplate))
                {
                    return receiver;
                }
            }

            var purposeMatchedReceivers = new List<Receiver>();
            foreach (var receiver in matchingNameReceivers)
            {
                if (Regex.IsMatch(record.Purpose, receiver.PurposeTemplate))
                {
                    purposeMatchedReceivers.Add(receiver);
                }
            }
            
            if (purposeMatchedReceivers.Count > 1)
            {
                var regexes = string.Join("\n", purposeMatchedReceivers.Select(x => x.PurposeTemplate));
                throw new AmbiguousMatchException(
                    $"Record purpose [{record.Purpose}] matched several receivers regex: /n{regexes}");
            }

            return purposeMatchedReceivers.FirstOrDefault();
        }

        public void Insert(Receiver receiver)
        {
            _receiversRepository.Insert(receiver);
            _receivers.Add(receiver);
        }
    }
}