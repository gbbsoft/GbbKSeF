namespace TestKSeF
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            Configuration_listBox = new ListBox();
            configurationBindingSource = new BindingSource(components);
            AuthorisationChallenge_button = new Button();
            groupBox1 = new GroupBox();
            Challenge_textBox = new TextBox();
            label4 = new Label();
            Timestamp_textBox = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            FA2 = new RadioButton();
            ReferenceNo_textBox = new TextBox();
            FA1 = new RadioButton();
            InitToken_button = new Button();
            label2 = new Label();
            TokenSesji_textBox = new TextBox();
            label5 = new Label();
            groupBox3 = new GroupBox();
            label26 = new Label();
            GetStatus2_button = new Button();
            GetStatus_button = new Button();
            Status_textBox = new TextBox();
            label7 = new Label();
            groupBox4 = new GroupBox();
            Terminate_button = new Button();
            groupBox5 = new GroupBox();
            Invoice1_RefNo_textBox = new TextBox();
            label6 = new Label();
            Invoice1_Dlg_button = new Button();
            Invoice1_textBox = new TextBox();
            Invoice1_button = new Button();
            groupBox7 = new GroupBox();
            GetInvoice1_CorrReason_textBox = new TextBox();
            label25 = new Label();
            GetInvoice1_CorrNumber_textBox = new TextBox();
            label24 = new Label();
            GetInvoice1AndCorrect_button = new Button();
            label22 = new Label();
            GetInvoice1_FileName_button = new Button();
            KSefRefNo_textBox = new TextBox();
            GetInvoice_FileName_textBox = new TextBox();
            label10 = new Label();
            GetInvoice1_button = new Button();
            GetInvoice1_textBox = new TextBox();
            label9 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox6 = new GroupBox();
            InvoiceStatus_button = new Button();
            InvoiceStatus_textBox = new TextBox();
            label8 = new Label();
            tabPage2 = new TabPage();
            groupBox8 = new GroupBox();
            QueryHeader_Subject2_radioButton = new RadioButton();
            QueryHeader_Subject1_radioButton = new RadioButton();
            QueryHeader_PageNo_numericUpDown = new NumericUpDown();
            label19 = new Label();
            QueryHeader_textBox = new TextBox();
            QueryHeader_button = new Button();
            QueryHeader_ToDate_dateTimePicker = new DateTimePicker();
            label12 = new Label();
            QueryHeader_FromDate_dateTimePicker = new DateTimePicker();
            label11 = new Label();
            tabPage4 = new TabPage();
            groupBox11 = new GroupBox();
            label18 = new Label();
            QueryFiles_File_button = new Button();
            QueryFiles_File_textBox = new TextBox();
            QueryFiles_Get_button = new Button();
            groupBox10 = new GroupBox();
            QueryFiles_Status_button = new Button();
            QueryFiles_Status_textBox = new TextBox();
            label16 = new Label();
            groupBox9 = new GroupBox();
            QueryFiles_RefNo_textBox = new TextBox();
            label15 = new Label();
            QueryFiles_Init_button = new Button();
            QueryFiles_ToDate_dateTimePicker = new DateTimePicker();
            label13 = new Label();
            QueryFiles_FromDate_dateTimePicker = new DateTimePicker();
            label14 = new Label();
            tabPage3 = new TabPage();
            groupBox13 = new GroupBox();
            label21 = new Label();
            Batch_SignFile_button = new Button();
            Batch_SignFile_textBox = new TextBox();
            Batch_Send_button = new Button();
            groupBox12 = new GroupBox();
            label23 = new Label();
            Batch_MaxSize_numericUpDown = new NumericUpDown();
            label17 = new Label();
            label20 = new Label();
            Batch_ZipFile_button = new Button();
            Batch_ZipFile_textBox = new TextBox();
            Batch_Init_button = new Button();
            Configuration_button = new Button();
            ((System.ComponentModel.ISupportInitialize)configurationBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox6.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QueryHeader_PageNo_numericUpDown).BeginInit();
            tabPage4.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox9.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Batch_MaxSize_numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "Konfiguracja:";
            // 
            // Configuration_listBox
            // 
            Configuration_listBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Configuration_listBox.DataSource = configurationBindingSource;
            Configuration_listBox.DisplayMember = "OurFullName";
            Configuration_listBox.FormattingEnabled = true;
            Configuration_listBox.ItemHeight = 15;
            Configuration_listBox.Location = new Point(95, 24);
            Configuration_listBox.Name = "Configuration_listBox";
            Configuration_listBox.Size = new Size(1020, 64);
            Configuration_listBox.TabIndex = 1;
            // 
            // AuthorisationChallenge_button
            // 
            AuthorisationChallenge_button.Location = new Point(6, 22);
            AuthorisationChallenge_button.Name = "AuthorisationChallenge_button";
            AuthorisationChallenge_button.Size = new Size(446, 23);
            AuthorisationChallenge_button.TabIndex = 2;
            AuthorisationChallenge_button.Text = "Nawiąż sesję";
            AuthorisationChallenge_button.UseVisualStyleBackColor = true;
            AuthorisationChallenge_button.Click += AuthorisationChallenge_button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Challenge_textBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Timestamp_textBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(AuthorisationChallenge_button);
            groupBox1.Location = new Point(12, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 117);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nawiązanie sesji";
            // 
            // Challenge_textBox
            // 
            Challenge_textBox.Location = new Point(98, 80);
            Challenge_textBox.Name = "Challenge_textBox";
            Challenge_textBox.Size = new Size(354, 23);
            Challenge_textBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 83);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 7;
            label4.Text = "Challenge:";
            // 
            // Timestamp_textBox
            // 
            Timestamp_textBox.Location = new Point(98, 51);
            Timestamp_textBox.Name = "Timestamp_textBox";
            Timestamp_textBox.Size = new Size(354, 23);
            Timestamp_textBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 54);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 5;
            label3.Text = "timestamp:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(FA2);
            groupBox2.Controls.Add(ReferenceNo_textBox);
            groupBox2.Controls.Add(FA1);
            groupBox2.Controls.Add(InitToken_button);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(TokenSesji_textBox);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(12, 217);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(458, 135);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logowanie tokenem";
            // 
            // FA2
            // 
            FA2.AutoSize = true;
            FA2.Checked = true;
            FA2.Location = new Point(67, 19);
            FA2.Name = "FA2";
            FA2.Size = new Size(55, 19);
            FA2.TabIndex = 12;
            FA2.TabStop = true;
            FA2.Text = "FA (2)";
            FA2.UseVisualStyleBackColor = true;
            // 
            // ReferenceNo_textBox
            // 
            ReferenceNo_textBox.Location = new Point(98, 102);
            ReferenceNo_textBox.Name = "ReferenceNo_textBox";
            ReferenceNo_textBox.Size = new Size(354, 23);
            ReferenceNo_textBox.TabIndex = 12;
            // 
            // FA1
            // 
            FA1.AutoSize = true;
            FA1.Location = new Point(6, 19);
            FA1.Name = "FA1";
            FA1.Size = new Size(55, 19);
            FA1.TabIndex = 11;
            FA1.Text = "FA (1)";
            FA1.UseVisualStyleBackColor = true;
            // 
            // InitToken_button
            // 
            InitToken_button.Location = new Point(6, 44);
            InitToken_button.Name = "InitToken_button";
            InitToken_button.Size = new Size(446, 23);
            InitToken_button.TabIndex = 2;
            InitToken_button.Text = "Loguj się tokenem";
            InitToken_button.UseVisualStyleBackColor = true;
            InitToken_button.Click += InitToken_button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 105);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 11;
            label2.Text = "ReferenceNo:";
            // 
            // TokenSesji_textBox
            // 
            TokenSesji_textBox.Location = new Point(98, 73);
            TokenSesji_textBox.Name = "TokenSesji_textBox";
            TokenSesji_textBox.Size = new Size(354, 23);
            TokenSesji_textBox.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 76);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 9;
            label5.Text = "token sesji:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label26);
            groupBox3.Controls.Add(GetStatus2_button);
            groupBox3.Controls.Add(GetStatus_button);
            groupBox3.Controls.Add(Status_textBox);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(12, 358);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(458, 185);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Status sesji wg ReferenceNo";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(6, 92);
            label26.Name = "label26";
            label26.Size = new Size(90, 15);
            label26.TabIndex = 12;
            label26.Text = "czekamy na 315";
            // 
            // GetStatus2_button
            // 
            GetStatus2_button.Location = new Point(6, 51);
            GetStatus2_button.Name = "GetStatus2_button";
            GetStatus2_button.Size = new Size(446, 23);
            GetStatus2_button.TabIndex = 11;
            GetStatus2_button.Text = "Sprawdź common status / Status paczki wysłanej batchem (bez sesji)";
            GetStatus2_button.UseVisualStyleBackColor = true;
            GetStatus2_button.Click += GetStatus2_button_Click;
            // 
            // GetStatus_button
            // 
            GetStatus_button.Location = new Point(6, 22);
            GetStatus_button.Name = "GetStatus_button";
            GetStatus_button.Size = new Size(446, 23);
            GetStatus_button.TabIndex = 2;
            GetStatus_button.Text = "Sprawdź online status";
            GetStatus_button.UseVisualStyleBackColor = true;
            GetStatus_button.Click += GetStatus_button_Click;
            // 
            // Status_textBox
            // 
            Status_textBox.Location = new Point(98, 80);
            Status_textBox.Multiline = true;
            Status_textBox.Name = "Status_textBox";
            Status_textBox.ScrollBars = ScrollBars.Both;
            Status_textBox.Size = new Size(354, 99);
            Status_textBox.TabIndex = 10;
            Status_textBox.WordWrap = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 77);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 9;
            label7.Text = "Status:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Terminate_button);
            groupBox4.Location = new Point(12, 549);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(458, 64);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Koniec";
            // 
            // Terminate_button
            // 
            Terminate_button.Location = new Point(6, 22);
            Terminate_button.Name = "Terminate_button";
            Terminate_button.Size = new Size(446, 23);
            Terminate_button.TabIndex = 2;
            Terminate_button.Text = "Terminate session";
            Terminate_button.UseVisualStyleBackColor = true;
            Terminate_button.Click += Terminate_button_Click;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(Invoice1_RefNo_textBox);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(Invoice1_Dlg_button);
            groupBox5.Controls.Add(Invoice1_textBox);
            groupBox5.Controls.Add(Invoice1_button);
            groupBox5.Location = new Point(6, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(677, 117);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Wysłanie jednej faktury";
            // 
            // Invoice1_RefNo_textBox
            // 
            Invoice1_RefNo_textBox.Location = new Point(98, 83);
            Invoice1_RefNo_textBox.Name = "Invoice1_RefNo_textBox";
            Invoice1_RefNo_textBox.Size = new Size(354, 23);
            Invoice1_RefNo_textBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 86);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 9;
            label6.Text = "ElementRefNo:";
            // 
            // Invoice1_Dlg_button
            // 
            Invoice1_Dlg_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Invoice1_Dlg_button.Location = new Point(638, 20);
            Invoice1_Dlg_button.Name = "Invoice1_Dlg_button";
            Invoice1_Dlg_button.Size = new Size(33, 23);
            Invoice1_Dlg_button.TabIndex = 4;
            Invoice1_Dlg_button.Text = "...";
            Invoice1_Dlg_button.UseVisualStyleBackColor = true;
            Invoice1_Dlg_button.Click += Invoice1_Dlg_button_Click;
            // 
            // Invoice1_textBox
            // 
            Invoice1_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Invoice1_textBox.Location = new Point(6, 22);
            Invoice1_textBox.Name = "Invoice1_textBox";
            Invoice1_textBox.Size = new Size(626, 23);
            Invoice1_textBox.TabIndex = 3;
            // 
            // Invoice1_button
            // 
            Invoice1_button.Location = new Point(6, 54);
            Invoice1_button.Name = "Invoice1_button";
            Invoice1_button.Size = new Size(446, 23);
            Invoice1_button.TabIndex = 2;
            Invoice1_button.Text = "Wyślij";
            Invoice1_button.UseVisualStyleBackColor = true;
            Invoice1_button.Click += Invoice1_button_Click;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox7.Controls.Add(GetInvoice1_CorrReason_textBox);
            groupBox7.Controls.Add(label25);
            groupBox7.Controls.Add(GetInvoice1_CorrNumber_textBox);
            groupBox7.Controls.Add(label24);
            groupBox7.Controls.Add(GetInvoice1AndCorrect_button);
            groupBox7.Controls.Add(label22);
            groupBox7.Controls.Add(GetInvoice1_FileName_button);
            groupBox7.Controls.Add(KSefRefNo_textBox);
            groupBox7.Controls.Add(GetInvoice_FileName_textBox);
            groupBox7.Controls.Add(label10);
            groupBox7.Controls.Add(GetInvoice1_button);
            groupBox7.Controls.Add(GetInvoice1_textBox);
            groupBox7.Controls.Add(label9);
            groupBox7.Location = new Point(6, 303);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(677, 280);
            groupBox7.TabIndex = 15;
            groupBox7.TabStop = false;
            groupBox7.Text = "Pobranie faktury wg ElementRefNo";
            // 
            // GetInvoice1_CorrReason_textBox
            // 
            GetInvoice1_CorrReason_textBox.Location = new Point(471, 103);
            GetInvoice1_CorrReason_textBox.Name = "GetInvoice1_CorrReason_textBox";
            GetInvoice1_CorrReason_textBox.Size = new Size(118, 23);
            GetInvoice1_CorrReason_textBox.TabIndex = 20;
            GetInvoice1_CorrReason_textBox.Text = "Błędnie wystawiona faktura";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(376, 107);
            label25.Name = "label25";
            label25.Size = new Size(89, 15);
            label25.TabIndex = 19;
            label25.Text = "Powód korekty:";
            // 
            // GetInvoice1_CorrNumber_textBox
            // 
            GetInvoice1_CorrNumber_textBox.Location = new Point(252, 103);
            GetInvoice1_CorrNumber_textBox.Name = "GetInvoice1_CorrNumber_textBox";
            GetInvoice1_CorrNumber_textBox.Size = new Size(118, 23);
            GetInvoice1_CorrNumber_textBox.TabIndex = 18;
            GetInvoice1_CorrNumber_textBox.Text = "Kor/2022/0001";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(157, 107);
            label24.Name = "label24";
            label24.Size = new Size(89, 15);
            label24.TabIndex = 17;
            label24.Text = "Numer korekty:";
            // 
            // GetInvoice1AndCorrect_button
            // 
            GetInvoice1AndCorrect_button.Location = new Point(6, 75);
            GetInvoice1AndCorrect_button.Name = "GetInvoice1AndCorrect_button";
            GetInvoice1AndCorrect_button.Size = new Size(446, 23);
            GetInvoice1AndCorrect_button.TabIndex = 16;
            GetInvoice1AndCorrect_button.Text = "Pobierz fakturę i stwórz korektę \"na zero\"";
            GetInvoice1AndCorrect_button.UseVisualStyleBackColor = true;
            GetInvoice1AndCorrect_button.Click += GetInvoice1AndCorrect_button_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(6, 135);
            label22.Name = "label22";
            label22.Size = new Size(68, 15);
            label22.TabIndex = 15;
            label22.Text = "Zapisz jako:";
            // 
            // GetInvoice1_FileName_button
            // 
            GetInvoice1_FileName_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GetInvoice1_FileName_button.Location = new Point(638, 132);
            GetInvoice1_FileName_button.Name = "GetInvoice1_FileName_button";
            GetInvoice1_FileName_button.Size = new Size(33, 23);
            GetInvoice1_FileName_button.TabIndex = 12;
            GetInvoice1_FileName_button.Text = "...";
            GetInvoice1_FileName_button.UseVisualStyleBackColor = true;
            GetInvoice1_FileName_button.Click += GetInvoice1_FileName_button_Click;
            // 
            // KSefRefNo_textBox
            // 
            KSefRefNo_textBox.Location = new Point(98, 22);
            KSefRefNo_textBox.Name = "KSefRefNo_textBox";
            KSefRefNo_textBox.Size = new Size(354, 23);
            KSefRefNo_textBox.TabIndex = 14;
            // 
            // GetInvoice_FileName_textBox
            // 
            GetInvoice_FileName_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GetInvoice_FileName_textBox.Location = new Point(98, 132);
            GetInvoice_FileName_textBox.Name = "GetInvoice_FileName_textBox";
            GetInvoice_FileName_textBox.Size = new Size(534, 23);
            GetInvoice_FileName_textBox.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 25);
            label10.Name = "label10";
            label10.Size = new Size(68, 15);
            label10.TabIndex = 13;
            label10.Text = "KSeFRefNo:";
            // 
            // GetInvoice1_button
            // 
            GetInvoice1_button.Location = new Point(6, 51);
            GetInvoice1_button.Name = "GetInvoice1_button";
            GetInvoice1_button.Size = new Size(446, 23);
            GetInvoice1_button.TabIndex = 2;
            GetInvoice1_button.Text = "Pobierz fakturę";
            GetInvoice1_button.UseVisualStyleBackColor = true;
            GetInvoice1_button.Click += GetInvoice1_button_Click;
            // 
            // GetInvoice1_textBox
            // 
            GetInvoice1_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GetInvoice1_textBox.Location = new Point(98, 161);
            GetInvoice1_textBox.Multiline = true;
            GetInvoice1_textBox.Name = "GetInvoice1_textBox";
            GetInvoice1_textBox.ScrollBars = ScrollBars.Both;
            GetInvoice1_textBox.Size = new Size(573, 113);
            GetInvoice1_textBox.TabIndex = 10;
            GetInvoice1_textBox.WordWrap = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 164);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 9;
            label9.Text = "Faktura/Korekta:";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(476, 94);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(694, 634);
            tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox6);
            tabPage1.Controls.Add(groupBox5);
            tabPage1.Controls.Add(groupBox7);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(686, 606);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Wysyłanie pojedynczych faktur";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox6.Controls.Add(InvoiceStatus_button);
            groupBox6.Controls.Add(InvoiceStatus_textBox);
            groupBox6.Controls.Add(label8);
            groupBox6.Location = new Point(6, 129);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(677, 168);
            groupBox6.TabIndex = 16;
            groupBox6.TabStop = false;
            groupBox6.Text = "Status faktury wg ElementRefNo";
            // 
            // InvoiceStatus_button
            // 
            InvoiceStatus_button.Location = new Point(6, 22);
            InvoiceStatus_button.Name = "InvoiceStatus_button";
            InvoiceStatus_button.Size = new Size(446, 23);
            InvoiceStatus_button.TabIndex = 2;
            InvoiceStatus_button.Text = "Sprawdź status";
            InvoiceStatus_button.UseVisualStyleBackColor = true;
            InvoiceStatus_button.Click += InvoiceStatus_button_Click_2;
            // 
            // InvoiceStatus_textBox
            // 
            InvoiceStatus_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InvoiceStatus_textBox.Location = new Point(98, 54);
            InvoiceStatus_textBox.Multiline = true;
            InvoiceStatus_textBox.Name = "InvoiceStatus_textBox";
            InvoiceStatus_textBox.ScrollBars = ScrollBars.Both;
            InvoiceStatus_textBox.Size = new Size(573, 99);
            InvoiceStatus_textBox.TabIndex = 10;
            InvoiceStatus_textBox.WordWrap = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 51);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 9;
            label8.Text = "Status:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox8);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(686, 606);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Odpytywanie";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox8.Controls.Add(QueryHeader_Subject2_radioButton);
            groupBox8.Controls.Add(QueryHeader_Subject1_radioButton);
            groupBox8.Controls.Add(QueryHeader_PageNo_numericUpDown);
            groupBox8.Controls.Add(label19);
            groupBox8.Controls.Add(QueryHeader_textBox);
            groupBox8.Controls.Add(QueryHeader_button);
            groupBox8.Controls.Add(QueryHeader_ToDate_dateTimePicker);
            groupBox8.Controls.Add(label12);
            groupBox8.Controls.Add(QueryHeader_FromDate_dateTimePicker);
            groupBox8.Controls.Add(label11);
            groupBox8.Location = new Point(6, 6);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(674, 594);
            groupBox8.TabIndex = 0;
            groupBox8.TabStop = false;
            groupBox8.Text = "Lista faktur z okresu (Invoicing date)";
            // 
            // QueryHeader_Subject2_radioButton
            // 
            QueryHeader_Subject2_radioButton.AutoSize = true;
            QueryHeader_Subject2_radioButton.Checked = true;
            QueryHeader_Subject2_radioButton.Location = new Point(325, 54);
            QueryHeader_Subject2_radioButton.Name = "QueryHeader_Subject2_radioButton";
            QueryHeader_Subject2_radioButton.Size = new Size(119, 19);
            QueryHeader_Subject2_radioButton.TabIndex = 16;
            QueryHeader_Subject2_radioButton.TabStop = true;
            QueryHeader_Subject2_radioButton.Text = "Zakup/otrzymane";
            QueryHeader_Subject2_radioButton.UseVisualStyleBackColor = true;
            // 
            // QueryHeader_Subject1_radioButton
            // 
            QueryHeader_Subject1_radioButton.AutoSize = true;
            QueryHeader_Subject1_radioButton.Location = new Point(201, 54);
            QueryHeader_Subject1_radioButton.Name = "QueryHeader_Subject1_radioButton";
            QueryHeader_Subject1_radioButton.Size = new Size(118, 19);
            QueryHeader_Subject1_radioButton.TabIndex = 15;
            QueryHeader_Subject1_radioButton.Text = "Sprzedaż/wysłane";
            QueryHeader_Subject1_radioButton.UseVisualStyleBackColor = true;
            // 
            // QueryHeader_PageNo_numericUpDown
            // 
            QueryHeader_PageNo_numericUpDown.Location = new Point(66, 53);
            QueryHeader_PageNo_numericUpDown.Name = "QueryHeader_PageNo_numericUpDown";
            QueryHeader_PageNo_numericUpDown.Size = new Size(101, 23);
            QueryHeader_PageNo_numericUpDown.TabIndex = 14;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(8, 55);
            label19.Name = "label19";
            label19.Size = new Size(44, 15);
            label19.TabIndex = 13;
            label19.Text = "Strona:";
            // 
            // QueryHeader_textBox
            // 
            QueryHeader_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            QueryHeader_textBox.Location = new Point(6, 111);
            QueryHeader_textBox.Multiline = true;
            QueryHeader_textBox.Name = "QueryHeader_textBox";
            QueryHeader_textBox.ScrollBars = ScrollBars.Both;
            QueryHeader_textBox.Size = new Size(662, 477);
            QueryHeader_textBox.TabIndex = 12;
            QueryHeader_textBox.WordWrap = false;
            // 
            // QueryHeader_button
            // 
            QueryHeader_button.Location = new Point(6, 82);
            QueryHeader_button.Name = "QueryHeader_button";
            QueryHeader_button.Size = new Size(446, 23);
            QueryHeader_button.TabIndex = 9;
            QueryHeader_button.Text = "Pobierz";
            QueryHeader_button.UseVisualStyleBackColor = true;
            QueryHeader_button.Click += QueryHeader_button_Click;
            // 
            // QueryHeader_ToDate_dateTimePicker
            // 
            QueryHeader_ToDate_dateTimePicker.Format = DateTimePickerFormat.Short;
            QueryHeader_ToDate_dateTimePicker.Location = new Point(258, 22);
            QueryHeader_ToDate_dateTimePicker.Name = "QueryHeader_ToDate_dateTimePicker";
            QueryHeader_ToDate_dateTimePicker.Size = new Size(101, 23);
            QueryHeader_ToDate_dateTimePicker.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(201, 28);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 2;
            label12.Text = "Do dnia:";
            // 
            // QueryHeader_FromDate_dateTimePicker
            // 
            QueryHeader_FromDate_dateTimePicker.Format = DateTimePickerFormat.Short;
            QueryHeader_FromDate_dateTimePicker.Location = new Point(66, 22);
            QueryHeader_FromDate_dateTimePicker.Name = "QueryHeader_FromDate_dateTimePicker";
            QueryHeader_FromDate_dateTimePicker.Size = new Size(101, 23);
            QueryHeader_FromDate_dateTimePicker.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 28);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 0;
            label11.Text = "Od dnia:";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox11);
            tabPage4.Controls.Add(groupBox10);
            tabPage4.Controls.Add(groupBox9);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(686, 606);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Pobieranie plików";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            groupBox11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox11.Controls.Add(label18);
            groupBox11.Controls.Add(QueryFiles_File_button);
            groupBox11.Controls.Add(QueryFiles_File_textBox);
            groupBox11.Controls.Add(QueryFiles_Get_button);
            groupBox11.Location = new Point(3, 364);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(677, 94);
            groupBox11.TabIndex = 17;
            groupBox11.TabStop = false;
            groupBox11.Text = "Pobieranie faktur";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 24);
            label18.Name = "label18";
            label18.Size = new Size(85, 15);
            label18.TabIndex = 11;
            label18.Text = "Plik wynikowy:";
            // 
            // QueryFiles_File_button
            // 
            QueryFiles_File_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            QueryFiles_File_button.Location = new Point(638, 19);
            QueryFiles_File_button.Name = "QueryFiles_File_button";
            QueryFiles_File_button.Size = new Size(33, 23);
            QueryFiles_File_button.TabIndex = 4;
            QueryFiles_File_button.Text = "...";
            QueryFiles_File_button.UseVisualStyleBackColor = true;
            QueryFiles_File_button.Click += QueryFiles_File_button_Click;
            // 
            // QueryFiles_File_textBox
            // 
            QueryFiles_File_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            QueryFiles_File_textBox.Location = new Point(98, 20);
            QueryFiles_File_textBox.Name = "QueryFiles_File_textBox";
            QueryFiles_File_textBox.Size = new Size(534, 23);
            QueryFiles_File_textBox.TabIndex = 3;
            // 
            // QueryFiles_Get_button
            // 
            QueryFiles_Get_button.Location = new Point(6, 54);
            QueryFiles_Get_button.Name = "QueryFiles_Get_button";
            QueryFiles_Get_button.Size = new Size(538, 23);
            QueryFiles_Get_button.TabIndex = 2;
            QueryFiles_Get_button.Text = "pobierz";
            QueryFiles_Get_button.UseVisualStyleBackColor = true;
            QueryFiles_Get_button.Click += QueryFiles_Get_button_Click;
            // 
            // groupBox10
            // 
            groupBox10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox10.Controls.Add(QueryFiles_Status_button);
            groupBox10.Controls.Add(QueryFiles_Status_textBox);
            groupBox10.Controls.Add(label16);
            groupBox10.Location = new Point(3, 126);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(677, 232);
            groupBox10.TabIndex = 16;
            groupBox10.TabStop = false;
            groupBox10.Text = "Status faktury wg QueryElementReferenceNumber :";
            // 
            // QueryFiles_Status_button
            // 
            QueryFiles_Status_button.Location = new Point(6, 22);
            QueryFiles_Status_button.Name = "QueryFiles_Status_button";
            QueryFiles_Status_button.Size = new Size(564, 23);
            QueryFiles_Status_button.TabIndex = 2;
            QueryFiles_Status_button.Text = "Sprawdź status";
            QueryFiles_Status_button.UseVisualStyleBackColor = true;
            QueryFiles_Status_button.Click += QueryFiles_Status_button_Click;
            // 
            // QueryFiles_Status_textBox
            // 
            QueryFiles_Status_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            QueryFiles_Status_textBox.Location = new Point(98, 54);
            QueryFiles_Status_textBox.Multiline = true;
            QueryFiles_Status_textBox.Name = "QueryFiles_Status_textBox";
            QueryFiles_Status_textBox.ScrollBars = ScrollBars.Both;
            QueryFiles_Status_textBox.Size = new Size(573, 172);
            QueryFiles_Status_textBox.TabIndex = 10;
            QueryFiles_Status_textBox.WordWrap = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 51);
            label16.Name = "label16";
            label16.Size = new Size(42, 15);
            label16.TabIndex = 9;
            label16.Text = "Status:";
            // 
            // groupBox9
            // 
            groupBox9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox9.Controls.Add(QueryFiles_RefNo_textBox);
            groupBox9.Controls.Add(label15);
            groupBox9.Controls.Add(QueryFiles_Init_button);
            groupBox9.Controls.Add(QueryFiles_ToDate_dateTimePicker);
            groupBox9.Controls.Add(label13);
            groupBox9.Controls.Add(QueryFiles_FromDate_dateTimePicker);
            groupBox9.Controls.Add(label14);
            groupBox9.Location = new Point(3, 3);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(674, 117);
            groupBox9.TabIndex = 14;
            groupBox9.TabStop = false;
            groupBox9.Text = "Incrementalne pobranie plików (AcquisitionTimestamp)";
            // 
            // QueryFiles_RefNo_textBox
            // 
            QueryFiles_RefNo_textBox.Location = new Point(201, 80);
            QueryFiles_RefNo_textBox.Name = "QueryFiles_RefNo_textBox";
            QueryFiles_RefNo_textBox.Size = new Size(354, 23);
            QueryFiles_RefNo_textBox.TabIndex = 13;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(11, 83);
            label15.Name = "label15";
            label15.Size = new Size(184, 15);
            label15.TabIndex = 10;
            label15.Text = "QueryElementReferenceNumber :";
            // 
            // QueryFiles_Init_button
            // 
            QueryFiles_Init_button.Location = new Point(6, 51);
            QueryFiles_Init_button.Name = "QueryFiles_Init_button";
            QueryFiles_Init_button.Size = new Size(564, 23);
            QueryFiles_Init_button.TabIndex = 9;
            QueryFiles_Init_button.Text = "Init";
            QueryFiles_Init_button.UseVisualStyleBackColor = true;
            QueryFiles_Init_button.Click += QueryFiles_Init_button_Click_1;
            // 
            // QueryFiles_ToDate_dateTimePicker
            // 
            QueryFiles_ToDate_dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            QueryFiles_ToDate_dateTimePicker.Format = DateTimePickerFormat.Custom;
            QueryFiles_ToDate_dateTimePicker.Location = new Point(281, 22);
            QueryFiles_ToDate_dateTimePicker.Name = "QueryFiles_ToDate_dateTimePicker";
            QueryFiles_ToDate_dateTimePicker.Size = new Size(150, 23);
            QueryFiles_ToDate_dateTimePicker.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(224, 28);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 2;
            label13.Text = "Do dnia:";
            // 
            // QueryFiles_FromDate_dateTimePicker
            // 
            QueryFiles_FromDate_dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            QueryFiles_FromDate_dateTimePicker.Format = DateTimePickerFormat.Custom;
            QueryFiles_FromDate_dateTimePicker.Location = new Point(66, 22);
            QueryFiles_FromDate_dateTimePicker.Name = "QueryFiles_FromDate_dateTimePicker";
            QueryFiles_FromDate_dateTimePicker.Size = new Size(152, 23);
            QueryFiles_FromDate_dateTimePicker.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(8, 28);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 0;
            label14.Text = "Od dnia:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox13);
            tabPage3.Controls.Add(groupBox12);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(686, 606);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Wysyłanie batch-em (nie wymaga sesji)";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            groupBox13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox13.Controls.Add(label21);
            groupBox13.Controls.Add(Batch_SignFile_button);
            groupBox13.Controls.Add(Batch_SignFile_textBox);
            groupBox13.Controls.Add(Batch_Send_button);
            groupBox13.Location = new Point(3, 118);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(680, 84);
            groupBox13.TabIndex = 20;
            groupBox13.TabStop = false;
            groupBox13.Text = "Wysłanie podpisanego pliku";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(8, 23);
            label21.Name = "label21";
            label21.Size = new Size(110, 15);
            label21.TabIndex = 19;
            label21.Text = "Podpisany plik xml:";
            // 
            // Batch_SignFile_button
            // 
            Batch_SignFile_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Batch_SignFile_button.Location = new Point(640, 18);
            Batch_SignFile_button.Name = "Batch_SignFile_button";
            Batch_SignFile_button.Size = new Size(33, 23);
            Batch_SignFile_button.TabIndex = 18;
            Batch_SignFile_button.Text = "...";
            Batch_SignFile_button.UseVisualStyleBackColor = true;
            Batch_SignFile_button.Click += Batch_SignFile_button_Click;
            // 
            // Batch_SignFile_textBox
            // 
            Batch_SignFile_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Batch_SignFile_textBox.Location = new Point(134, 19);
            Batch_SignFile_textBox.Name = "Batch_SignFile_textBox";
            Batch_SignFile_textBox.Size = new Size(500, 23);
            Batch_SignFile_textBox.TabIndex = 17;
            // 
            // Batch_Send_button
            // 
            Batch_Send_button.Location = new Point(6, 48);
            Batch_Send_button.Name = "Batch_Send_button";
            Batch_Send_button.Size = new Size(564, 23);
            Batch_Send_button.TabIndex = 14;
            Batch_Send_button.Text = "Wyslij podpisany plik i części pliku .zip";
            Batch_Send_button.UseVisualStyleBackColor = true;
            Batch_Send_button.Click += Batch_Send_button_Click;
            // 
            // groupBox12
            // 
            groupBox12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox12.Controls.Add(label23);
            groupBox12.Controls.Add(Batch_MaxSize_numericUpDown);
            groupBox12.Controls.Add(label17);
            groupBox12.Controls.Add(label20);
            groupBox12.Controls.Add(Batch_ZipFile_button);
            groupBox12.Controls.Add(Batch_ZipFile_textBox);
            groupBox12.Controls.Add(Batch_Init_button);
            groupBox12.Location = new Point(3, 3);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(680, 109);
            groupBox12.TabIndex = 0;
            groupBox12.TabStop = false;
            groupBox12.Text = "Tworzenie pliku xml do podpisu:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(195, 53);
            label23.Name = "label23";
            label23.Size = new Size(137, 15);
            label23.TabIndex = 22;
            label23.Text = "KB (do 50MB = 51200KB)";
            // 
            // Batch_MaxSize_numericUpDown
            // 
            Batch_MaxSize_numericUpDown.Location = new Point(134, 48);
            Batch_MaxSize_numericUpDown.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            Batch_MaxSize_numericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Batch_MaxSize_numericUpDown.Name = "Batch_MaxSize_numericUpDown";
            Batch_MaxSize_numericUpDown.Size = new Size(55, 23);
            Batch_MaxSize_numericUpDown.TabIndex = 21;
            Batch_MaxSize_numericUpDown.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(8, 50);
            label17.Name = "label17";
            label17.Size = new Size(115, 15);
            label17.TabIndex = 20;
            label17.Text = "Max wielkość części:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(8, 23);
            label20.Name = "label20";
            label20.Size = new Size(120, 15);
            label20.TabIndex = 19;
            label20.Text = "Plik zip z plikami xml:";
            // 
            // Batch_ZipFile_button
            // 
            Batch_ZipFile_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Batch_ZipFile_button.Location = new Point(640, 18);
            Batch_ZipFile_button.Name = "Batch_ZipFile_button";
            Batch_ZipFile_button.Size = new Size(33, 23);
            Batch_ZipFile_button.TabIndex = 18;
            Batch_ZipFile_button.Text = "...";
            Batch_ZipFile_button.UseVisualStyleBackColor = true;
            Batch_ZipFile_button.Click += Batch_ZipFile_button_Click;
            // 
            // Batch_ZipFile_textBox
            // 
            Batch_ZipFile_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Batch_ZipFile_textBox.Location = new Point(134, 19);
            Batch_ZipFile_textBox.Name = "Batch_ZipFile_textBox";
            Batch_ZipFile_textBox.Size = new Size(500, 23);
            Batch_ZipFile_textBox.TabIndex = 17;
            // 
            // Batch_Init_button
            // 
            Batch_Init_button.Location = new Point(8, 77);
            Batch_Init_button.Name = "Batch_Init_button";
            Batch_Init_button.Size = new Size(562, 23);
            Batch_Init_button.TabIndex = 14;
            Batch_Init_button.Text = "Dziel plik .zip na części i twórz plik .xml do podpisania";
            Batch_Init_button.UseVisualStyleBackColor = true;
            Batch_Init_button.Click += Batch_Init_button_Click;
            // 
            // Configuration_button
            // 
            Configuration_button.Location = new Point(14, 42);
            Configuration_button.Name = "Configuration_button";
            Configuration_button.Size = new Size(75, 23);
            Configuration_button.TabIndex = 17;
            Configuration_button.Text = "Zmień...";
            Configuration_button.UseVisualStyleBackColor = true;
            Configuration_button.Click += Configuration_button_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 740);
            Controls.Add(Configuration_button);
            Controls.Add(tabControl1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Configuration_listBox);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "KSeF by Gbb Software";
            Load += Form1_Load;
            Shown += MainForm_Shown;
            ((System.ComponentModel.ISupportInitialize)configurationBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)QueryHeader_PageNo_numericUpDown).EndInit();
            tabPage4.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Batch_MaxSize_numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox Configuration_listBox;
        private BindingSource configurationBindingSource;
        private Button AuthorisationChallenge_button;
        private GroupBox groupBox1;
        private TextBox Challenge_textBox;
        private Label label4;
        private TextBox Timestamp_textBox;
        private Label label3;
        private GroupBox groupBox2;
        private Button InitToken_button;
        private TextBox ReferenceNo_textBox;
        private Label label2;
        private TextBox TokenSesji_textBox;
        private Label label5;
        private GroupBox groupBox3;
        private Button GetStatus_button;
        private TextBox Status_textBox;
        private Label label7;
        private Button GetStatus2_button;
        private GroupBox groupBox4;
        private Button Terminate_button;
        private GroupBox groupBox5;
        private TextBox Invoice1_textBox;
        private Button Invoice1_button;
        private Button Invoice1_Dlg_button;
        private TextBox Invoice1_RefNo_textBox;
        private Label label6;
        private GroupBox groupBox7;
        private Button GetInvoice1_button;
        private TextBox GetInvoice1_textBox;
        private Label label9;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox KSefRefNo_textBox;
        private Label label10;
        private GroupBox groupBox8;
        private TextBox QueryHeader_textBox;
        private Button QueryHeader_button;
        private DateTimePicker QueryHeader_ToDate_dateTimePicker;
        private Label label12;
        private DateTimePicker QueryHeader_FromDate_dateTimePicker;
        private Label label11;
        private TabPage tabPage4;
        private GroupBox groupBox6;
        private Button InvoiceStatus_button;
        private TextBox InvoiceStatus_textBox;
        private Label label8;
        private GroupBox groupBox9;
        private Button QueryFiles_Init_button;
        private DateTimePicker QueryFiles_ToDate_dateTimePicker;
        private Label label13;
        private DateTimePicker QueryFiles_FromDate_dateTimePicker;
        private Label label14;
        private GroupBox groupBox10;
        private Button QueryFiles_Status_button;
        private TextBox QueryFiles_Status_textBox;
        private Label label16;
        private GroupBox groupBox11;
        private Label label18;
        private Button QueryFiles_File_button;
        private TextBox QueryFiles_File_textBox;
        private Button QueryFiles_Get_button;
        private GroupBox groupBox12;
        private Button Batch_Init_button;
        private NumericUpDown QueryHeader_PageNo_numericUpDown;
        private Label label19;
        private GroupBox groupBox13;
        private Label label21;
        private Button Batch_SignFile_button;
        private TextBox Batch_SignFile_textBox;
        private Button Batch_Send_button;
        private Label label23;
        private NumericUpDown Batch_MaxSize_numericUpDown;
        private Label label17;
        private Label label20;
        private Button Batch_ZipFile_button;
        private TextBox Batch_ZipFile_textBox;
        private TextBox QueryFiles_RefNo_textBox;
        private Label label15;
        private RadioButton QueryHeader_Subject2_radioButton;
        private RadioButton QueryHeader_Subject1_radioButton;
        private Label label22;
        private Button GetInvoice1_FileName_button;
        private TextBox GetInvoice_FileName_textBox;
        private Button GetInvoice1AndCorrect_button;
        private TextBox GetInvoice1_CorrReason_textBox;
        private Label label25;
        private TextBox GetInvoice1_CorrNumber_textBox;
        private Label label24;
        private Label label26;
        private Button Configuration_button;
        private RadioButton FA2;
        private RadioButton FA1;
    }
}