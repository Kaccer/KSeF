using KBKSeF.Interfaces;
using KBKSeF.Services;
using KSeF.Exceptions;
using KSeF.Models;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace KBKSeF
{
    public partial class Form1 : Form
    {
        private readonly IPresenter presenter;
        private string lastPage = "1";
        public Form1(IPresenter presenter)
        {
            InitializeComponent();

            this.presenter = presenter;

            buttonAuthorize.Enabled = false;
            buttonSearch.Enabled = false;
            buttonStatusCheck.Enabled = false;
            comboBoxFilterColumn.Enabled = false;
            textBoxFilterText.Enabled = false;
            comboBoxPages.Enabled = false;
            dateTimePickerInvoiceTill.Value = DateTime.Now.AddDays(-1);
            dateTimePickerInvoiceSince.Value = DateTime.Now.AddDays(-8);
            radioButtonSellInvoice.Checked = true;
        }

        private async void buttonAuthorize_Click(object sender, EventArgs e)
        {
            var nip = this.textBoxNIP.Text;
            try
            {
                await presenter.PresentAuthorize(nip);
                textBoxError.Text = string.Empty;
                buttonStatusCheck.Enabled = true;
            }
            catch (System.Exception ex) when (ex is FaultyChallengeResponseException || ex is FaultyInitializeTokenResponseException)
            {
                textBoxError.Text = ex.Message;
            }

        }

        private async void buttonStatusCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var status = await presenter.PresentStatusCheck();
                labelStatus.Text = status.ToString();
                if (status == 315)
                {
                    buttonSearch.Enabled = true;
                }
                textBoxError.Text = string.Empty;
            }
            catch (FaultyCheckStatusResponseException ex)
            {
                textBoxError.Text = ex.Message;
            }
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            await GetSearchData(1);
        }

        private async Task GetSearchData(int page)
        {
            try
            {
                var since = dateTimePickerInvoiceSince.Value;
                var till = dateTimePickerInvoiceTill.Value;
                var isSellInvoice = radioButtonSellInvoice.Checked;

                var result = await presenter.PresentSearch(since, till, isSellInvoice, page);
                dataGridViewInvoices.DataSource = result.Item1;
                List<string> previousPages = (List<string>)comboBoxPages.DataSource;
                var newPages = result.Item2;
                if (previousPages == null || !previousPages.SequenceEqual(newPages))
                    comboBoxPages.DataSource = result.Item2;
                if (result.Item2.Count > 1)
                {
                    comboBoxPages.Enabled = true;

                }
                else
                {
                    comboBoxPages.Enabled = false;
                }
                comboBoxFilterColumn.Items.Clear();
                foreach (DataGridViewColumn column in dataGridViewInvoices.Columns)
                {
                    comboBoxFilterColumn.Items.Add(column.Name);
                }
                comboBoxFilterColumn.Enabled = true;
                textBoxError.Text = string.Empty;
            }
            catch (FaultySearchResponseException ex)
            {
                textBoxError.Text = ex.Message;
            }
        }

        private void textBoxNIP_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txtBox && txtBox.Text.Length > 0)
            {
                buttonAuthorize.Enabled = true;
            }
        }

        private void textBoxNIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void comboBoxFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilterText.Enabled = true;
        }

        private void textBoxFilterText_TextChanged(object sender, EventArgs e)
        {
            var isSellInvoice = radioButtonSellInvoice.Checked;
            var columnName = comboBoxFilterColumn.Text;
            var columnValue = textBoxFilterText.Text;
            dataGridViewInvoices.DataSource = presenter.PresentSearchFiltered(columnName, columnValue, isSellInvoice);
        }

        private async void comboBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var page = comboBoxPages.Text;
            if (!page.Equals(lastPage))
            {
                lastPage = page;
                var newPage = int.Parse(page);
                await GetSearchData(newPage);
            }
        }
    }
}