namespace KBKSeF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxNIP = new TextBox();
            buttonAuthorize = new Button();
            dataGridViewInvoices = new DataGridView();
            label2 = new Label();
            labelStatus = new Label();
            buttonStatusCheck = new Button();
            buttonSearch = new Button();
            dateTimePickerInvoiceSince = new DateTimePicker();
            dateTimePickerInvoiceTill = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            radioButtonSellInvoice = new RadioButton();
            radioButtonBuyInvoice = new RadioButton();
            groupBoxInvoiceType = new GroupBox();
            textBoxError = new RichTextBox();
            textBoxFilterText = new TextBox();
            comboBoxFilterColumn = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBoxPages = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoices).BeginInit();
            groupBoxInvoiceType.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 28);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Wprowadź NIP\r\n";
            // 
            // textBoxNIP
            // 
            textBoxNIP.Location = new Point(27, 60);
            textBoxNIP.MaxLength = 10;
            textBoxNIP.Name = "textBoxNIP";
            textBoxNIP.Size = new Size(195, 23);
            textBoxNIP.TabIndex = 1;
            textBoxNIP.TextChanged += textBoxNIP_TextChanged;
            textBoxNIP.KeyPress += textBoxNIP_KeyPress;
            // 
            // buttonAuthorize
            // 
            buttonAuthorize.Location = new Point(27, 99);
            buttonAuthorize.Name = "buttonAuthorize";
            buttonAuthorize.Size = new Size(195, 23);
            buttonAuthorize.TabIndex = 2;
            buttonAuthorize.Text = "Autoryzuj";
            buttonAuthorize.UseVisualStyleBackColor = true;
            buttonAuthorize.Click += buttonAuthorize_Click;
            // 
            // dataGridViewInvoices
            // 
            dataGridViewInvoices.AllowUserToAddRows = false;
            dataGridViewInvoices.AllowUserToDeleteRows = false;
            dataGridViewInvoices.AllowUserToOrderColumns = true;
            dataGridViewInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInvoices.Location = new Point(228, 126);
            dataGridViewInvoices.Name = "dataGridViewInvoices";
            dataGridViewInvoices.ReadOnly = true;
            dataGridViewInvoices.RowTemplate.Height = 25;
            dataGridViewInvoices.Size = new Size(641, 312);
            dataGridViewInvoices.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 152);
            label2.Name = "label2";
            label2.Size = new Size(135, 15);
            label2.TabIndex = 4;
            label2.Text = "Status (oczekiwany 315):";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(168, 152);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 15);
            labelStatus.TabIndex = 5;
            // 
            // buttonStatusCheck
            // 
            buttonStatusCheck.Location = new Point(27, 126);
            buttonStatusCheck.Name = "buttonStatusCheck";
            buttonStatusCheck.Size = new Size(195, 23);
            buttonStatusCheck.TabIndex = 6;
            buttonStatusCheck.Text = "Sprawdź status";
            buttonStatusCheck.UseVisualStyleBackColor = true;
            buttonStatusCheck.Click += buttonStatusCheck_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(794, 42);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(77, 43);
            buttonSearch.TabIndex = 7;
            buttonSearch.Text = "Wyszukaj";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dateTimePickerInvoiceSince
            // 
            dateTimePickerInvoiceSince.Location = new Point(228, 60);
            dateTimePickerInvoiceSince.Name = "dateTimePickerInvoiceSince";
            dateTimePickerInvoiceSince.Size = new Size(200, 23);
            dateTimePickerInvoiceSince.TabIndex = 9;
            // 
            // dateTimePickerInvoiceTill
            // 
            dateTimePickerInvoiceTill.Location = new Point(434, 60);
            dateTimePickerInvoiceTill.Name = "dateTimePickerInvoiceTill";
            dateTimePickerInvoiceTill.Size = new Size(200, 23);
            dateTimePickerInvoiceTill.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(228, 42);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 11;
            label3.Text = "Faktury od:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(434, 42);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 12;
            label4.Text = "Faktury do:";
            // 
            // radioButtonSellInvoice
            // 
            radioButtonSellInvoice.AutoSize = true;
            radioButtonSellInvoice.Location = new Point(6, 22);
            radioButtonSellInvoice.Name = "radioButtonSellInvoice";
            radioButtonSellInvoice.Size = new Size(134, 19);
            radioButtonSellInvoice.TabIndex = 13;
            radioButtonSellInvoice.TabStop = true;
            radioButtonSellInvoice.Text = "Faktura sprzedażowa";
            radioButtonSellInvoice.UseVisualStyleBackColor = true;
            // 
            // radioButtonBuyInvoice
            // 
            radioButtonBuyInvoice.AutoSize = true;
            radioButtonBuyInvoice.Location = new Point(6, 46);
            radioButtonBuyInvoice.Name = "radioButtonBuyInvoice";
            radioButtonBuyInvoice.Size = new Size(120, 19);
            radioButtonBuyInvoice.TabIndex = 14;
            radioButtonBuyInvoice.TabStop = true;
            radioButtonBuyInvoice.Text = "Faktura zakupowa";
            radioButtonBuyInvoice.UseVisualStyleBackColor = true;
            // 
            // groupBoxInvoiceType
            // 
            groupBoxInvoiceType.Controls.Add(radioButtonSellInvoice);
            groupBoxInvoiceType.Controls.Add(radioButtonBuyInvoice);
            groupBoxInvoiceType.Location = new Point(640, 12);
            groupBoxInvoiceType.Name = "groupBoxInvoiceType";
            groupBoxInvoiceType.Size = new Size(148, 71);
            groupBoxInvoiceType.TabIndex = 15;
            groupBoxInvoiceType.TabStop = false;
            groupBoxInvoiceType.Text = "Rodzaj faktury";
            // 
            // textBoxError
            // 
            textBoxError.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxError.ForeColor = Color.IndianRed;
            textBoxError.Location = new Point(27, 188);
            textBoxError.Name = "textBoxError";
            textBoxError.Size = new Size(195, 250);
            textBoxError.TabIndex = 16;
            textBoxError.Text = "";
            // 
            // textBoxFilterText
            // 
            textBoxFilterText.Location = new Point(665, 99);
            textBoxFilterText.Name = "textBoxFilterText";
            textBoxFilterText.Size = new Size(206, 23);
            textBoxFilterText.TabIndex = 17;
            textBoxFilterText.TextChanged += textBoxFilterText_TextChanged;
            // 
            // comboBoxFilterColumn
            // 
            comboBoxFilterColumn.FormattingEnabled = true;
            comboBoxFilterColumn.Location = new Point(349, 99);
            comboBoxFilterColumn.Name = "comboBoxFilterColumn";
            comboBoxFilterColumn.Size = new Size(200, 23);
            comboBoxFilterColumn.TabIndex = 18;
            comboBoxFilterColumn.SelectedIndexChanged += comboBoxFilterColumn_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(231, 102);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 19;
            label5.Text = "Filtrowana kolumna";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(555, 103);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 20;
            label6.Text = "Filtrowana wartość";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(751, 447);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 21;
            label7.Text = "Strona";
            // 
            // comboBoxPages
            // 
            comboBoxPages.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPages.FormattingEnabled = true;
            comboBoxPages.Location = new Point(806, 444);
            comboBoxPages.Name = "comboBoxPages";
            comboBoxPages.Size = new Size(61, 23);
            comboBoxPages.TabIndex = 22;
            comboBoxPages.Text = "1";
            comboBoxPages.SelectedIndexChanged += comboBoxPages_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 475);
            Controls.Add(comboBoxPages);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBoxFilterColumn);
            Controls.Add(textBoxFilterText);
            Controls.Add(textBoxError);
            Controls.Add(groupBoxInvoiceType);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dateTimePickerInvoiceTill);
            Controls.Add(dateTimePickerInvoiceSince);
            Controls.Add(buttonSearch);
            Controls.Add(buttonStatusCheck);
            Controls.Add(labelStatus);
            Controls.Add(label2);
            Controls.Add(dataGridViewInvoices);
            Controls.Add(buttonAuthorize);
            Controls.Add(textBoxNIP);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoices).EndInit();
            groupBoxInvoiceType.ResumeLayout(false);
            groupBoxInvoiceType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNIP;
        private Button buttonAuthorize;
        private DataGridView dataGridViewInvoices;
        private Label label2;
        private Label labelStatus;
        private Button buttonStatusCheck;
        private Button buttonSearch;
        private DateTimePicker dateTimePickerInvoiceSince;
        private DateTimePicker dateTimePickerInvoiceTill;
        private Label label3;
        private Label label4;
        private RadioButton radioButtonSellInvoice;
        private RadioButton radioButtonBuyInvoice;
        private GroupBox groupBoxInvoiceType;
        private RichTextBox textBoxError;
        private TextBox textBoxFilterText;
        private ComboBox comboBoxFilterColumn;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboBoxPages;
    }
}