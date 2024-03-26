using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using Expenses.Dapper;
using Expenses.Mapping;
using Expenses.Module;
using Expenses.Repositories;

namespace Expenses
{
    public partial class MainForm : Form
    {
        private readonly ProcessManager _processManager;
        private readonly ReceiversManager _receiversManager;
        public MainForm()
        {
            InitializeComponent();
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
            var dapperExecutorFactory = new DapperExecutorFactory(connection);
            _processManager = new ProcessManager(dapperExecutorFactory);
            _receiversManager = new ReceiversManager(dapperExecutorFactory);
        }

        private void toolBtnAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var records = new List<CsvRecord>();
                var stream = openFileDialog.OpenFile();

                using (var csv = new CsvReader(new StreamReader(stream),
                           new CsvConfiguration(CultureInfo.CurrentCulture)
                           {
                               BadDataFound = null,
                               Delimiter = ";"
                           }))
                {
                    csv.Context.RegisterClassMap<CsvRecordMap>();
                    
                    //csv.Read(); // header

                    while (csv.Read())
                    {
                        records.Add(csv.GetRecord<CsvRecord>());
                    }
                    Console.WriteLine("done");
                }

                foreach (var record in records)
                {
                    if (_processManager.ProcessRecord(record))
                    {
                        var matchingReceiver = _receiversManager.GetMatchingReceiver(record);
                        if (matchingReceiver == null)
                        {
                            var dlg = new DlgReceiver(record, _processManager.ExpenceTypes);
                            dlg.ShowDialog(this);
                            matchingReceiver = dlg.Receiver;
                            _receiversManager.Insert(matchingReceiver);
                        }
                        
                        _processManager.Finalize(record, matchingReceiver);
                    }
                }
            }
        }
    }
}