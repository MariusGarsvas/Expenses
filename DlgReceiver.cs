// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DlgReceiver.cs" company="CMRRA">
// //   CMRRA
// // </copyright>
// // <summary>
// //
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Expenses.Module;

namespace Expenses
{
    public partial class DlgReceiver : Form
    {
        private readonly CsvRecord _record;
        private readonly List<ExpenceType> _expenceTypes;
        private Receiver _receiver;

        public DlgReceiver(CsvRecord record, List<ExpenceType> expenceTypes)
        {
            _record = record;
            _receiver = new Receiver
            {
                NameMatch = record.Receiver,
                MasterPercentage = 100M
            };
            
            _expenceTypes = expenceTypes;
            InitializeComponent();
            tbRecordReceiver.Text = _record.Receiver;
            tbRecordPurpose.Text = _record.Purpose;

            foreach (var expenceType in _expenceTypes)
            {
                lbMasterExpenceType.Items.Add(expenceType);
                lbOtherExpenceType.Items.Add(expenceType);
            }
        }

        public Receiver Receiver => _receiver;

        private void btnSave_Click(object sender, EventArgs e)
        {
            _receiver.Name = tbName.Text;
            _receiver.MasterExpenceId = (lbMasterExpenceType.SelectedItem as ExpenceType).Id;
            if (_receiver.MasterPercentage < 100)
            {
                _receiver.OtherExpenceId = (lbOtherExpenceType.SelectedItem as ExpenceType).Id;
            }

            _receiver.PurposeTemplate = tbPurposeTemplate.Text;
            Close();
        }

        private void tbPercent_TextChanged(object sender, EventArgs e)
        {
            int percentValue = 0;
            if (int.TryParse(tbPercent.Text, out percentValue))
            {
                _receiver.MasterPercentage = percentValue;
                tbOtherPercentage.Text = _receiver.OtherPercentage.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                var match = Regex.Match(_record.Purpose, tbPurposeTemplate.Text);
                chbMatch.Checked = match.Success;
                tbMatchResult.Text = match.Value;
            }
            catch
            {
                chbMatch.Checked = false;
                tbMatchResult.Text = string.Empty;
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            tbPurposeTemplate.Text = "^([*]{12})(\\d{4})\\S+()";
        }
    }
}