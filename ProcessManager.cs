// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ProcessManager.cs" company="CMRRA">
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
using Expenses.Repositories;

namespace Expenses
{
    public class ProcessManager
    {
        private readonly IDapperExecutorFactory _dapperExecutorFactory;
        
        private CsvRecordsRepository _csvRecordsRepository;
        private ConfigurationRepository _configurationRepository;

        private HashSet<string> _ownAccounts;
        private List<ExpenceType> _expenceTypes;

        public ProcessManager(IDapperExecutorFactory dapperExecutorFactory)
        {
            _dapperExecutorFactory = dapperExecutorFactory;
            _csvRecordsRepository = new CsvRecordsRepository(_dapperExecutorFactory.Create<CsvRecord>());
            _configurationRepository = new ConfigurationRepository(_dapperExecutorFactory);
        }

        public HashSet<string> OwnAccounts
        {
            get
            {
                if (_ownAccounts == null)
                {
                    _ownAccounts = _configurationRepository.GetOwnAccounts().ToHashSet();
                }

                return _ownAccounts;
            }
        }

        public List<ExpenceType> ExpenceTypes
        {
            get
            {
                if (_expenceTypes == null)
                {
                    _expenceTypes = _configurationRepository.GetExpenceTypes();
                }

                return _expenceTypes;
            }
        }

        public bool ProcessRecord(CsvRecord record)
        {
            var canProcess = record != null &&
                             record.DirectionValue == Direction.Debit &&        // only debit operations
                             !OwnAccounts.Contains(record.ReceiverAccountNo) &&    // ignore local move operations
                             !_csvRecordsRepository.Exists(record.OperationId);     // record not yet processed
            return canProcess;
        }

        public void Finalize(CsvRecord record, Receiver receiver)
        {
            _csvRecordsRepository.Insert(record, receiver);
        }
        
        
    }
}