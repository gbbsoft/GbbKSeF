/*
 * Author: Gbb Software 2002
 */

using Azure;
using KSeFAPI.Models;
using System.Globalization;
using System.Security.Cryptography;

namespace TestKSeF
{
    public partial class MainForm : Form
    {

        private List<ConfigurationLine> configurations = new();

        private HttpClient httpClient = new();
        private KSeFAPI.KSeFRestClient? Client = null;
        private DateTimeOffset Challenge_Timestamp;



        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            configurationBindingSource.DataSource = Program.Configuration.Lines;

            // send files
            this.Invoice1_textBox.Text = Properties.Settings.Default.Invoice1;

            // daty
            this.QueryHeader_FromDate_dateTimePicker.Value = DateTime.Today.AddDays(-1);
            this.QueryHeader_ToDate_dateTimePicker.Value = DateTime.Today;

            // incremental
            this.QueryFiles_FromDate_dateTimePicker.Value = DateTime.Now.AddDays(-1);
            this.QueryFiles_ToDate_dateTimePicker.Value = DateTime.Now;

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                // if no configuration than open form to define configuration
                if (Program.Configuration.Lines.Count == 0)
                    Configuration_button_Click(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Configuration_button_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationForm dlg = new();
                dlg.ShowDialog();
                configurationBindingSource.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

        }

        private void CreateClient(ConfigurationLine? CurrConf)
        {
            if (CurrConf == null)
                throw new ApplicationException("Wska¿ konfiguracjê!");

            // create Client
            var Pipe = new Azure.Core.Pipeline.HttpPipeline(new Azure.Core.Pipeline.HttpClientTransport(httpClient));
            Client = new KSeFAPI.KSeFRestClient(new Azure.Core.Pipeline.ClientDiagnostics(Azure.Core.ClientOptions.Default),
                Pipe,
                new Uri(CurrConf.URL)
                );

        }

        private void AuthorisationChallenge_button_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationLine? CurrConf = (ConfigurationLine?)this.Configuration_listBox.SelectedItem;
                CreateClient(CurrConf);
                ArgumentNullException.ThrowIfNull(Client);
                ArgumentNullException.ThrowIfNull(CurrConf);


                // create body
                var body = new KSeFAPI.Models.AuthorisationChallengeRequest(
                                    new KSeFAPI.Models.SubjectIdentifierByCompanyType(CurrConf.NIP));

                // send
                var ret = Client.OnlineSessionAuthorisationChallenge(body);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);

                // process responce
                var resp = (AuthorisationChallengeResponse)ret.Value;
                this.Challenge_textBox.Text = resp.Challenge;
                Challenge_Timestamp = resp.Timestamp;
                this.Timestamp_textBox.Text = Challenge_Timestamp.LocalDateTime.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void InitToken_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                ConfigurationLine CurrConf = (ConfigurationLine)this.Configuration_listBox.SelectedItem;
                bool IsFA2 = this.FA2.Checked;

                // create encrypted token
                string EncryptedToken = KSeFHelpers.Create_EncryptedToken(CurrConf.Token, CurrConf.PublicKey, Challenge_Timestamp);

                // create InitSessionTokenRequest
                Stream body = KSeFHelpers.Create_InitSessionTokenRequest(this.Challenge_textBox.Text, CurrConf.NIP, EncryptedToken, IsFA2);

                // call
                var ret = Client.OnlineSessionTokenInit(body);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (InitSessionResponse)ret.Value;
                this.TokenSesji_textBox.Text = resp.SessionToken.Token;
                this.ReferenceNo_textBox.Text = resp.ReferenceNumber;

                // session token for other function calls
                Client.OurSessionToken = resp.SessionToken.Token;


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }


        }


        private void GetStatus_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineSessionStatusReferenceNumber(this.ReferenceNo_textBox.Text, 20, 0);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (SessionStatusResponse)ret.Value;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(resp.ProcessingCode);
                sb.Append(": ");
                sb.AppendLine(resp.ProcessingDescription);
                sb.Append("NumberOfElements: ");
                sb.AppendLine(resp.NumberOfElements.ToString());
                if (resp.NumberOfElements > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("ElementReferenceNumber,InvoiceNumber: Code-ProcessingDescription, KsefReferenceNumber, AcquisitionTimestamp");

                    foreach (var itm in resp.InvoiceStatusList)
                    {
                        sb.Append(itm.ElementReferenceNumber);
                        sb.Append(", ");
                        sb.Append(itm.InvoiceNumber);
                        sb.Append(": ");
                        sb.Append(itm.ProcessingCode);
                        sb.Append("-");
                        sb.Append(itm.ProcessingDescription);
                        sb.Append(", ");
                        sb.Append(itm.KsefReferenceNumber);
                        sb.Append(", ");
                        if (itm.AcquisitionTimestamp != null)
                            sb.Append(itm.AcquisitionTimestamp.Value.ToLocalTime().ToString());
                        sb.AppendLine();
                    }
                }

                this.Status_textBox.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }


        }

        private void GetStatus2_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client == null)
                {
                    ConfigurationLine CurrConf = (ConfigurationLine)this.Configuration_listBox.SelectedItem;
                    CreateClient(CurrConf);
                }
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.CommonStatus(this.ReferenceNo_textBox.Text);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (StatusResponse)ret.Value;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(resp.ProcessingCode);
                sb.Append(": ");
                sb.AppendLine(resp.ProcessingDescription);
                sb.AppendLine("UPO: ");
                if (!string.IsNullOrWhiteSpace(resp.Upo))
                {
                    byte[] buf = Convert.FromBase64String(resp.Upo);
                    string s = System.Text.UTF8Encoding.UTF8.GetString(buf);
                    sb.AppendLine(s);
                }

                this.Status_textBox.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void Terminate_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineSessionTerminate();
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (TerminateSessionResponse)ret.Value;
                MessageBox.Show(this, resp.ProcessingCode + ": " + resp.ProcessingDescription);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        // ===============================
        // Wysy³anie faktur
        // ==============================

        private void Invoice1_Dlg_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new();
                dlg.FileName = this.Invoice1_textBox.Text;
                dlg.DefaultExt = ".xml";
                dlg.Filter = "Pliki .xml|*.xml";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    this.Invoice1_textBox.Text = dlg.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }



        private void Invoice1_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                Properties.Settings.Default.Invoice1 = this.Invoice1_textBox.Text;
                Properties.Settings.Default.Save();

                // get file and it's hash
                string Hash;
                int FileSize;
                byte[] FileBody;

                FileBody = File.ReadAllBytes(this.Invoice1_textBox.Text);
                FileSize = FileBody.Length;

                using (SHA256 mySHA256 = SHA256.Create())
                {
                    Hash = Convert.ToBase64String(mySHA256.ComputeHash(FileBody));
                }

                // call
                var ret = Client.OnlineInvoiceSend(
                    new SendInvoiceRequest(
                            new File1MBHashType(
                                new HashSHAType("SHA-256", "Base64", Hash),
                                FileSize),
                            new InvoicePayloadPlainType(Convert.ToBase64String(FileBody))
                            )
                        );
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (SendInvoiceResponse)ret.Value;
                this.Invoice1_RefNo_textBox.Text = resp.ElementReferenceNumber;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void InvoiceStatus_button_Click_2(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineInvoiceStatus(this.Invoice1_RefNo_textBox.Text);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (StatusInvoiceResponse)ret.Value;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(resp.ProcessingCode);
                sb.Append(": ");
                sb.AppendLine(resp.ProcessingDescription);
                sb.AppendLine();

                sb.Append("KSeF_RefNo:");
                sb.Append(resp.InvoiceStatus.KsefReferenceNumber);
                sb.Append(", AcqTime: ");
                if (resp.InvoiceStatus.AcquisitionTimestamp != null)
                    sb.Append(resp.InvoiceStatus.AcquisitionTimestamp.Value.ToLocalTime().ToString());

                this.InvoiceStatus_textBox.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }
        private void GetInvoice1_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineInvoiceGet(this.KSefRefNo_textBox.Text);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (string)ret.Value;
                this.GetInvoice1_textBox.Text = resp;

                if (!string.IsNullOrWhiteSpace(this.GetInvoice1_textBox.Text))
                    File.WriteAllText(this.GetInvoice1_textBox.Text, resp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void GetInvoice1_FileName_button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new();
                dlg.FileName = this.GetInvoice_FileName_textBox.Text;
                dlg.DefaultExt = ".xml";
                dlg.Filter = "Pliki .xml|*.xml";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    this.GetInvoice_FileName_textBox.Text = dlg.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }

        private void GetInvoice1AndCorrect_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineInvoiceGet(this.KSefRefNo_textBox.Text);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (string)ret.Value;

                // create correction invoice
                byte[] buf = KSeFHelpers.CreateCorrection(resp,
                                                this.KSefRefNo_textBox.Text,
                                                this.GetInvoice1_CorrNumber_textBox.Text, this.GetInvoice1_CorrReason_textBox.Text);


                // show result
                this.GetInvoice1_textBox.Text = System.Text.UTF8Encoding.UTF8.GetString(buf);

                // save result
                if (!string.IsNullOrWhiteSpace(this.GetInvoice_FileName_textBox.Text))
                {
                    File.WriteAllBytes(this.GetInvoice_FileName_textBox.Text, buf);
                    this.Invoice1_textBox.Text = this.GetInvoice_FileName_textBox.Text; // prepare to resend to KSeF
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }


        // ===============================
        // Odpytywanie o faktury
        // ==============================

        private DateTimeOffset OurConv(DateTime d)
        {
            return new DateTimeOffset(d.Year, d.Month, d.Day, 0, 0, 0, TimeSpan.Zero);
        }

        private void QueryHeader_button_Click(object sender, EventArgs e)
        {

            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                QueryCriteriaInvoiceTypeSubjectType subjectType;
                if (this.QueryHeader_Subject1_radioButton.Checked)
                    subjectType = QueryCriteriaInvoiceTypeSubjectType.Subject1;
                else
                    subjectType = QueryCriteriaInvoiceTypeSubjectType.Subject2;

                // call
                var ret = Client.OnlineQueryInvoice(100, (int)this.QueryHeader_PageNo_numericUpDown.Value,
                            new QueryInvoiceRequest(
                                    new QueryCriteriaInvoiceRangeType(
                                        subjectType,
                                        this.QueryHeader_FromDate_dateTimePicker.Value,
                                        this.QueryHeader_ToDate_dateTimePicker.Value.AddDays(1)
                                        )
                                    )
                            );
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (QueryInvoiceSyncResponse)ret.Value;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("NumberOfElements: ");
                sb.AppendLine(resp.NumberOfElements.ToString());
                if (resp.NumberOfElements > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("KsefReferenceNumber, InvoicingDate, AcquisitionTimestamp, From->To, Net, Vat, Gross, InvoiceReferenceNumber");

                    foreach (var itm in resp.InvoiceHeaderList)
                    {
                        sb.Append(itm.KsefReferenceNumber);
                        sb.Append(", ");
                        sb.Append(itm.InvoicingDate); // bez godzin dla +00
                        sb.Append(", ");
                        sb.Append(itm.AcquisitionTimestamp.ToLocalTime());
                        sb.Append(", ");
                        sb.Append(((SubjectIdentifierByCompanyType)itm.SubjectBy.IssuedByIdentifier).Identifier);
                        sb.Append("->");
                        sb.Append(((SubjectIdentifierToCompanyType)itm.SubjectTo.IssuedToIdentifier).Identifier);
                        sb.Append(", ");
                        sb.Append(itm.Net);
                        sb.Append(", ");
                        sb.Append(itm.Vat);
                        sb.Append(", ");
                        sb.Append(itm.Gross);
                        sb.Append(", ");
                        sb.Append(itm.InvoiceReferenceNumber);
                        sb.AppendLine();
                    }
                }

                this.QueryHeader_textBox.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void QueryFiles_Init_button_Click_1(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineQueryInvoiceInit(
                                new QueryInvoiceRequest(
                                    new QueryCriteriaInvoiceIncrementalType(
                                        QueryCriteriaInvoiceTypeSubjectType.Subject2,
                                        this.QueryFiles_FromDate_dateTimePicker.Value,
                                        this.QueryFiles_ToDate_dateTimePicker.Value
                                        )
                                    )
                                );
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (QueryInvoiceAsyncInitResponse)ret.Value;
                this.QueryFiles_RefNo_textBox.Text = resp.ElementReferenceNumber;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }


        private void QueryFiles_Status_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineQueryInvoiceStatus(this.QueryFiles_RefNo_textBox.Text);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (QueryInvoiceAsyncStatusResponse)ret.Value;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(resp.ProcessingCode);
                sb.Append(": ");
                sb.AppendLine(resp.ProcessingDescription);
                sb.Append("NumberOfElements: ");
                sb.AppendLine(resp.NumberOfElements.ToString());
                sb.Append("NumberOfParts: ");
                sb.AppendLine(resp.NumberOfParts.ToString());
                if (resp.NumberOfParts > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("PartReferenceNumber,PartName, PartNumber, PartExpiration, FileSize, PartRangeFrom, PartRangeTo");

                    foreach (var itm in resp.PartList)
                    {
                        sb.Append(itm.PartReferenceNumber);
                        sb.Append(", ");
                        sb.Append(itm.PartName);
                        sb.Append(": ");
                        sb.Append(itm.PartNumber);
                        sb.Append("-");
                        sb.Append(itm.PartExpiration);
                        sb.Append(", ");
                        sb.Append(itm.PlainPartHash.FileSize);
                        sb.Append(", ");
                        sb.Append(itm.PartRangeFrom);
                        sb.Append(", ");
                        sb.Append(itm.PartRangeTo);
                        sb.AppendLine();
                    }
                }

                this.QueryFiles_Status_textBox.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void QueryFiles_File_button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new();
                dlg.FileName = this.QueryFiles_File_textBox.Text;
                dlg.DefaultExt = ".zip";
                dlg.Filter = "Plik .zip|*.zip";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    this.QueryFiles_File_textBox.Text = dlg.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }

        private void QueryFiles_Get_button_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Client);

                // call
                var ret = Client.OnlineQueryInvoiceStatus(this.QueryFiles_RefNo_textBox.Text);
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);


                var resp = (QueryInvoiceAsyncStatusResponse)ret.Value;
                this.QueryFiles_Status_textBox.Text = $"NumberOfElements={resp.NumberOfElements}\r\nNumberOfParts={resp.NumberOfParts}\r\n";


                if (resp.NumberOfElements == 0)
                    throw new ApplicationException("No files, yes");

                using (SHA256 mySHA256 = SHA256.Create())
                {
                    int PartNo = 0;
                    foreach (var itm in resp.PartList)
                    {
                        PartNo++;
                        this.QueryFiles_Status_textBox.AppendText($"PartNo={PartNo}\r\n");

                        // file name
                        string FileName = this.QueryFiles_File_textBox.Text;
                        string path = Path.GetDirectoryName(FileName) ?? "";
                        string? Name = Path.GetFileNameWithoutExtension(FileName);
                        string Ext = Path.GetExtension(FileName);
                        FileName = Path.Combine(path, Name + "_" + PartNo + Ext);


                        // download
                        var ret2 = Client.OnlineQueryInvoiceFetch(this.QueryFiles_RefNo_textBox.Text, itm.PartReferenceNumber, FileName);
                        if (ret2.Value is KSeFAPI.Models.ExceptionResponse ex2)
                            throw ExceptionToEx(ex2);

                        // hash
                        if (itm.PlainPartHash.HashSHA.Algorithm != "SHA-256")
                            throw new ApplicationException("Unknown hash algorithm: " + itm.PlainPartHash.HashSHA.Algorithm);

                        using (var f = new System.IO.FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var Hash = Convert.ToBase64String(mySHA256.ComputeHash(f));
                            if (Hash != itm.PlainPartHash.HashSHA.Value)
                                throw new ApplicationException("Wrong Hash!");
                        }

                    }

                    MessageBox.Show(this, $"Iloœæ pobranych plików: {PartNo}");

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }

        // ===============================
        // Batch - wysy³anie faktur
        // ==============================
        private void Batch_ZipFile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new();
            dlg.FileName = this.Batch_ZipFile_textBox.Text;
            dlg.DefaultExt = ".zip";
            dlg.Filter = "Plik .zip|*.zip";
            if (dlg.ShowDialog(this) == DialogResult.OK)
                this.Batch_ZipFile_textBox.Text = dlg.FileName;

        }

        private void Batch_SignFile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new();
            dlg.FileName = this.Batch_SignFile_textBox.Text;
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Pliki .xml|*.xml";
            if (dlg.ShowDialog(this) == DialogResult.OK)
                this.Batch_SignFile_textBox.Text = dlg.FileName;
        }

        private void Batch_Init_button_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationLine CurrConf = (ConfigurationLine)this.Configuration_listBox.SelectedItem;
                CreateClient(CurrConf);
                ArgumentNullException.ThrowIfNull(Client);


                string ZipFullName = this.Batch_ZipFile_textBox.Text;

                // prepare Hash
                using SHA256 mySHA256 = SHA256.Create();

                // calculate Hash of whole zip
                KSeFHelpers.BatchInit_Params Params = new();
                Params.WholeZip_Hash = KSeFHelpers.CalculateHash(ZipFullName, mySHA256, out Params.WholeZip_Length);
                Params.WholeZip_Name = Path.GetFileName(ZipFullName);

                // prepare AES
                using Aes cipher = Aes.Create();
                cipher.Mode = CipherMode.CBC;  // Ensure the integrity of the ciphertext if using CBC
                cipher.Padding = PaddingMode.PKCS7;
                Params.SymetricAES_Key = KSeFHelpers.EncryptRSA(cipher.Key, CurrConf.PublicKey); // key encrypt by RSA and public key
                Params.SymetricAES_InitVector = cipher.IV;


                // split zip
                byte[] buf = new byte[1024];
                using (var FromFile = new FileStream(ZipFullName, FileMode.Open, FileAccess.Read))
                {
                    long Pos = 0;
                    int OrderNo = 0;
                    while (Pos < FromFile.Length)
                    {

                        // copy part of file and encrypt 
                        OrderNo++;
                        string PartFullName = ZipFullName + "." + OrderNo + ".aes";
                        using (var ToFile = new FileStream(PartFullName, FileMode.Create))
                        {
                            using var encryptor = cipher.CreateEncryptor();
                            using var csEncrypt = new CryptoStream(ToFile, encryptor, CryptoStreamMode.Write);

                            int KBCounter = (int)this.Batch_MaxSize_numericUpDown.Value;
                            while (KBCounter > 0) // no more than KBCounter kilobytes
                            {
                                int r = FromFile.Read(buf, 0, buf.Length);
                                if (r == 0)
                                    break;

                                Pos += r;
                                csEncrypt.Write(buf, 0, r);

                                KBCounter--;
                            }
                        }

                        // file info about part
                        KSeFHelpers.BatchInit_PartFile PartFile = new();
                        PartFile.FileName = Path.GetFileName(PartFullName);
                        PartFile.Hash = KSeFHelpers.CalculateHash(PartFullName, mySHA256, out PartFile.Length);
                        Params.PartFiles.Add(PartFile);

                    }

                }

                // create file
                string XmlFileName = ZipFullName + ".xml";
                KSeFHelpers.Create_BatchInitRequest(CurrConf.NIP, Params, XmlFileName);

                this.Batch_SignFile_textBox.Text = XmlFileName;
                MessageBox.Show("Now, please sign file: " + XmlFileName);



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }

        private void Batch_Send_button_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationLine CurrConf = (ConfigurationLine)this.Configuration_listBox.SelectedItem;
                CreateClient(CurrConf);
                ArgumentNullException.ThrowIfNull(Client);

                // parameters
                string path = Path.GetDirectoryName(this.Batch_SignFile_textBox.Text) ?? "";

                // call
                Response<object> ret;
                using (var XmlFile = new FileStream(this.Batch_SignFile_textBox.Text, FileMode.Open, FileAccess.Read))
                {
                    ret = Client.BatchInit(XmlFile);
                    if (ret.Value is KSeFAPI.Models.ExceptionResponse ex1)
                        throw ExceptionToEx(ex1);
                }

                var resp = (InitResponse)ret.Value;
                Challenge_Timestamp = resp.Timestamp;
                this.ReferenceNo_textBox.Text = resp.ReferenceNumber;

                // upload
                foreach (var itm in resp.PackageSignature.PackagePartSignatureList)
                {
                    string FileName = Path.Combine(path, itm.PartFileName);

                    using (var XmlFile = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                    {
                        string PartNumber;
                        int i = itm.Url.LastIndexOf("/");
                        PartNumber = itm.Url.Substring(i + 1);

                        ret = Client.BatchUpload(resp.ReferenceNumber, PartNumber, itm.HeaderEntryList, XmlFile);
                        if (ret.Value is KSeFAPI.Models.ExceptionResponse ex2)
                            throw ExceptionToEx(ex2);
                    }
                }

                // finish
                ret = Client.BatchFinish(
                        new FinishRequest(resp.Timestamp, resp.ReferenceNumber)
                    );
                if (ret.Value is KSeFAPI.Models.ExceptionResponse ex)
                    throw ExceptionToEx(ex);

                MessageBox.Show(this, "Send!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }


        }

        // ===============================
        // Tools
        // ==============================


        private Exception ExceptionToEx(ExceptionResponse ex)
        {
            System.Text.StringBuilder sb = new();
            if (ex.Exception != null && ex.Exception.ExceptionDetailList != null)
                foreach (var itm in ex.Exception.ExceptionDetailList)
                {
                    sb.Append(itm.ExceptionCode);
                    sb.Append("-");
                    sb.Append(itm.ExceptionDescription);
                    sb.Append(", ");
                }
            else
                sb.Append("Wyst¹pi³ b³¹d, ale brak jest opisu b³êdu!");
            return new ApplicationException(sb.ToString());
        }

    }
}