/*
 * Author: Gbb Software 2002
 */

using System.Data;
using Microsoft.VisualBasic;

namespace GbbLibWin;

public partial class OurDataGridView : DataGridView
{

    // context menu
    System.Windows.Forms.ContextMenuStrip ContextMenuStrip1 = new();
    System.Windows.Forms.ToolStripMenuItem Copy_ToolStripMenuItem = new();
    System.Windows.Forms.ToolStripMenuItem Paste_ToolStripMenuItem = new();
    System.Windows.Forms.ToolStripSeparator ToolStripSeparator1 = new();
    System.Windows.Forms.ToolStripMenuItem Find_ToolStripMenuItem = new();
    System.Windows.Forms.ToolStripSeparator ToolStripSeparator2 = new();
    System.Windows.Forms.ToolStripMenuItem ExportToTxt_ToolStripMenuItem = new();
    //System.Windows.Forms.ToolStripMenuItem ExportAllToTxt_ToolStripMenuItem = new();
    //System.Windows.Forms.ToolStripMenuItem UpdateFromExcel_ToolStripMenuItem = new();
    System.Windows.Forms.ToolStripSeparator ToolStripSeparator4 = new();
    System.Windows.Forms.ToolStripMenuItem Clear_ToolStripMenuItem = new();
    System.Windows.Forms.ToolStripMenuItem Delete_ToolStripMenuItem = new();
    System.Windows.Forms.ToolStripSeparator ToolStripSeparator5 = new();
    System.Windows.Forms.ToolStripMenuItem PasteToEnd_ToolStripMenuItem = new();

    public OurDataGridView()
    {
        InitializeComponent();

        // context menu
        ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Copy_ToolStripMenuItem, Paste_ToolStripMenuItem, ToolStripSeparator1,
            Find_ToolStripMenuItem, ToolStripSeparator2,
            ExportToTxt_ToolStripMenuItem, //ExportAllToTxt_ToolStripMenuItem, UpdateFromExcel_ToolStripMenuItem, 
            ToolStripSeparator4,
            Clear_ToolStripMenuItem, Delete_ToolStripMenuItem, ToolStripSeparator5,
            PasteToEnd_ToolStripMenuItem});
        ContextMenuStrip1.Opening += ContextMenuStrip1_Opening;
        this.ContextMenuStrip = ContextMenuStrip1;


        Copy_ToolStripMenuItem.Text = "Copy";
        Paste_ToolStripMenuItem.Text = "Paste";
        Find_ToolStripMenuItem.Text = "Find...";
        ExportToTxt_ToolStripMenuItem.Text = "Export to txt";
        //ExportAllToTxt_ToolStripMenuItem, UpdateFromExcel_ToolStripMenuItem, 
        Clear_ToolStripMenuItem.Text = "Clear";
        Delete_ToolStripMenuItem.Text = "Delete";
        PasteToEnd_ToolStripMenuItem.Text = "Paste (append on end)";

        Copy_ToolStripMenuItem.Click += Copy_ToolStripMenuItem_Click;
        Paste_ToolStripMenuItem.Click += Paste_ToolStripMenuItem_Click;
        Find_ToolStripMenuItem.Click += Find_ToolStripMenuItem_Click;
        ExportToTxt_ToolStripMenuItem.Click += ExportToTxt_ToolStripMenuItem_Click;
        //ExportAllToTxt_ToolStripMenuItem, UpdateFromExcel_ToolStripMenuItem, 
        Clear_ToolStripMenuItem.Click += Clear_ToolStripMenuItem_Click;
        Delete_ToolStripMenuItem.Click += Delete_ToolStripMenuItem_Click;
        PasteToEnd_ToolStripMenuItem.Click += PasteToEnd_ToolStripMenuItem_Click;

        this.KeyDown += DataGridView_KeyDown;
        this.DataError += DataGridView_DataError;
        this.RowValidating += DataGridView_RowValidating;
        this.RowValidated += DataGridView_RowValidated;
        this.UserDeletingRow += DataGridView_UserDeletingRow;

    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        base.OnHandleDestroyed(e);

        //Time_Save.Stop();
    }


    protected override void OnPreviewKeyDown(System.Windows.Forms.PreviewKeyDownEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.C)
            // Ctrl+C -> Copy
            this.OurCopyToClipboard();
        else if (e.Control && e.KeyCode == Keys.V)
            // Ctrl+V -> Paste
            this.OurPaste();
        else
            base.OnPreviewKeyDown(e);
    }


    private void DataGridView_KeyDown(object? sender, System.Windows.Forms.KeyEventArgs e)
    {
        try
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                e.Handled = true;
                this.OurFindNext_UI();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.OemQuotes)
                this.OurCopyFromAboveToCurr();
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.OemSemicolon)
                this.OurPutDateToCurr();
            else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.F2)
                this.OurOpenZoom_UI();
            else if (e.Control && e.KeyCode == Keys.Right)
            {
                this.OurFastMove(1, 0, e.Shift, e.KeyData);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Left)
            {
                this.OurFastMove(-1, 0, e.Shift, e.KeyData);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Down)
            {
                this.OurFastMove(0, 1, e.Shift, e.KeyData);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Up)
            {
                this.OurFastMove(0, -1, e.Shift, e.KeyData);
                e.Handled = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }

    // 
    // Fast move cursor
    // 
    public bool OurFastMove(int deltaX, int deltaY, bool isShift, System.Windows.Forms.Keys keys)
    {
        // check arguments
        if (deltaX == 0)
        {
            if (deltaY != 1 && deltaY != -1)
                throw new ArgumentException();
        }
        else if (deltaX != -1 && deltaX != 1 && deltaY != 0)
            throw new ArgumentException();

        if (this.CurrentCell == null)
            return false;
        if (this.CurrentCell.RowIndex < 0)
            return false;
        if (this.CurrentCell.ColumnIndex < 0)
            return false;

        int x;
        int y;

        x = this.CurrentCell.ColumnIndex;
        y = this.CurrentCell.RowIndex;

        if (this[x, y].Value != null)
        {
            // do one move
            if (x + deltaX >= 0 && x + deltaX <= this.ColumnCount - 1 && y + deltaY >= 0 && y + deltaY <= this.RowCount - 1)
            {
                x += deltaX;
                y += deltaY;
            }
        }

        if (this[x, y].Value != null)
        {
            if (this.CurrentCell is DataGridViewCheckBoxCell && deltaX == 0)
            {
                // checkbox column -> find also change of value
                int v;
                v = (int)this.CurrentCell.Value;
                do
                {
                    if (x + deltaX < 0 || x + deltaX > this.ColumnCount - 1 || y + deltaY < 0 || y + deltaY > this.RowCount - 1)
                        break;
                    x += deltaX;
                    y += deltaY;
                    if (this[x, y].Value == null || (int)this[x, y].Value != v)
                    {
                        x -= deltaX;
                        y -= deltaY;
                        break;
                    }
                }
                while (true);
            }
            else
                // normal
                // find end of data
                do
                {
                    if (x + deltaX < 0 || x + deltaX > this.ColumnCount - 1 || y + deltaY < 0 || y + deltaY > this.RowCount - 1)
                        break;
                    x += deltaX;
                    y += deltaY;
                    if (this[x, y].Value == null)
                    {
                        x -= deltaX;
                        y -= deltaY;
                        break;
                    }
                }
                while (true);
        }
        else
            // find start of data
            do
            {
                if (x + deltaX < 0 || x + deltaX > this.ColumnCount - 1 || y + deltaY < 0 || y + deltaY > this.RowCount - 1)
                    break;
                x += deltaX;
                y += deltaY;
                if (this[x, y].Value != null)
                    break;
            }
            while (true);

        if (isShift)
        {
            // not used!
            int xx = this.CurrentCellAddress.X;
            int yy = this.CurrentCellAddress.Y;
            var keys2 = keys;
            if ((keys2 & Keys.Control) != 0)
                keys2 = (Keys)(keys2 - Keys.Control); // remove control key
            while (xx != x || yy != y)
            {
                if (xx > x)
                {
                    this.ProcessLeftKey(keys2);
                    xx -= 1;
                }
                else if (xx < x)
                {
                    this.ProcessRightKey(keys2);
                    xx += 1;
                }

                if (yy > y)
                {
                    this.ProcessUpKey(keys2);
                    yy -= 1;
                }
                else if (yy < y)
                {
                    this.ProcessDownKey(keys2);
                    yy += 1;
                }
            }
        }
        else
        {
            this.CurrentCell = this[x, y];
            this.CurrentCell = this[x, y];
        }
        return true;
    }

    private void AddIfNotSelected(List<DataGridViewCell> l, DataGridViewCell cell)
    {
        if (cell.Selected)
        {
            if (l.Remove(cell))
                l.Remove(cell);
        }
        else
            l.Add(cell);
    }

    // 
    // Copy from above cell
    // 

    /// <summary>
    ///     ''' Copy value from cell above current
    ///     ''' </summary>
    ///     ''' <returns></returns>
    ///     ''' <remarks></remarks>
    public bool OurCopyFromAboveToCurr()
    {
        if (this.CurrentCell == null)
            return false;
        if (this.CurrentCell.RowIndex <= 0)
            return false;
        if (this.CurrentCell.ReadOnly)
            return false;

        this.NotifyCurrentCellDirty(true); // this can change current cell!
        this.CurrentCell.Value = this.Rows[this.CurrentCell.RowIndex - 1].Cells[this.CurrentCell.ColumnIndex].Value;
        this.NotifyCurrentCellDirty(false);

        return true;
    }

    public bool OurPutDateToCurr()
    {
        if (this.CurrentCell == null)
            return false;
        if (this.CurrentCell.ReadOnly)
            return false;

        this.NotifyCurrentCellDirty(true); // this can change current cell!
        this.CurrentCell.Value = DateTime.Today;
        this.NotifyCurrentCellDirty(false);

        return true;
    }


    // 
    // Copy operation
    // 

    private void Copy_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        OurCopyToClipboard();
    }

    public bool OurClear()
    {
        if (this.ReadOnly)
            return false;

        bool IsDataSet;
        IsDataSet = false;

        object ptr;
        ptr = this.DataSource;
        while (ptr != null)
        {
            if (ptr is BindingSource)
                ptr = ((BindingSource)ptr).DataSource;
            else
            {
                if (ptr is DataSet)
                    IsDataSet = true;
                break;
            }
        }

        try
        {
            this.m_IsInMasivePasteOrClear = true;
            foreach (DataGridViewCell c in this.SelectedCells)
            {
                if (!c.ReadOnly)
                {
                    DataGridViewCellCancelEventArgs arg = new DataGridViewCellCancelEventArgs(c.ColumnIndex, c.RowIndex);
                    this.OnCellBeginEdit(arg);
                    if (!arg.Cancel)
                    {
                        this.NotifyCurrentCellDirty(true); // this can change current cell!
                        if (IsDataSet)
                            c.Value = DBNull.Value;
                        else
                            c.Value = null;
                        this.NotifyCurrentCellDirty(false);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
            return false;
        }
        finally
        {
            this.m_IsInMasivePasteOrClear = false;
        }
        return true;
    }

    /// <summary>
    ///     ''' Copy selected cells to clipboard
    ///     ''' </summary>
    ///     ''' <param name="OnlyAsText">true -> to better copy numbers, but without formating</param>
    ///     ''' <returns></returns>
    public bool OurCopyToClipboard(bool OnlyAsText = false)
    {
        try
        {
            Clipboard.Clear();
            int i;
            i = this.GetCellCount(DataGridViewElementStates.Selected);
            if (i == 1)
                this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            else if (i > 1)
                this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject d;
            d = this.GetClipboardContent();
            if (d == null)
                return false;
            if (OnlyAsText)
            {
                string s;
                s = d.GetText();
                s = s.Replace(char.ConvertFromUtf32(160), "");
                Clipboard.SetDataObject(s);
            }
            else
                Clipboard.SetDataObject(d);

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
            return false;
        }
    }

    /// <summary>
    ///     ''' Same as OurCopyToString but in english culture
    ///     ''' </summary>
    ///     ''' <returns></returns>
    ///     ''' <remarks></remarks>
    public string? OurCopyToString2()
    {
        System.Globalization.CultureInfo oldCI;
        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        try
        {
            return this.OurCopyToString();
        }
        finally
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
        }
    }

    protected string? OurCopyToStringInternal()
    {
        string? ret;
        System.Windows.Forms.DataObject o;
        ret = null;
        int i;
        i = this.GetCellCount(DataGridViewElementStates.Selected);
        if (i == 1)
        {
            // Add the selection to the clipboard.
            this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            o = this.GetClipboardContent();
            ret = o.GetText();
        }
        else if (i > 1)
        {
            // Add the selection to the clipboard.
            this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            o = this.GetClipboardContent();
            ret = o.GetText();
        }

        // remove first tab character on every line
        if (ret != null)
        {
            string[] ss;
            ss = ret.Split(new char[] { '\n' }); //Constants.vbLf 
            for (i = 0; i <= ss.GetUpperBound(0); i++)
            {
                if (ss[i].StartsWith("\t"))
                    ss[i] = ss[i].Substring(1);
            }

            System.Text.StringBuilder b = new System.Text.StringBuilder();
            foreach (string s in ss)
            {
                b.Append(s);
                b.Append("\n"); //Constants.vbLf
            }
            ret = b.ToString();
        }
        return ret;
    }

    public string? OurCopyToString()
    {
        try
        {
            return OurCopyToStringInternal();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
            return null;
        }
    }

    private delegate System.Windows.Forms.DataObject ClipContent();
    private delegate string CopyToString();
    private delegate void dGetRowContent(int RowNo, System.IO.StreamWriter file);
    private const int ROWS_PER_ONCE = 1000;

    public void OurCopyAllToFile(System.ComponentModel.BackgroundWorker ReportingChannel, ref bool Canceled, string FileName, bool InEnglishCulture)
    {
        System.Globalization.CultureInfo oldCI;
        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
        if (InEnglishCulture)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        try
        {
            //Form f = this.FindForm;

            using (var file = System.IO.File.CreateText(FileName))
            {
                //bool WasHeader = false;

                this.ClearSelection();

                // get column names
                this.Invoke(new dGetRowContent(GetRowContent), new object[] { -1, file });
                


                var RowCnt = this.RowCount;

                int rowNo = 0;
                while (rowNo < RowCnt)
                {
                    // info
                    if (ReportingChannel != null && ReportingChannel.WorkerReportsProgress && rowNo % ROWS_PER_ONCE == 0)
                        ReportingChannel.ReportProgress((int)(rowNo * 100 / (double)RowCnt), rowNo.ToString());

                    this.Invoke(new dGetRowContent(GetRowContent), new object[] { rowNo, file });

                    rowNo += ROWS_PER_ONCE;
                    if (ReportingChannel != null)
                    {
                        if (ReportingChannel.CancellationPending)
                        {
                            Canceled = true;
                            break;
                        }
                    }
                }

                file.Close();
            }
        }
        finally
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
        }
    }

    private void GetRowContent(int RowNo, System.IO.StreamWriter file)
    {
        if (RowNo == -1)
        {
            bool first = true;
            for (var col = 0; col <= this.ColumnCount - 1; col++)
            {
                if (!first)
                    file.Write("\t"); //Constants.vbTab
                else
                    first = false;
                string s;
                s = this.Columns[col].HeaderText;
                if (s.IndexOf("\t") >= 0) //Constants.vbTab
                    s = s.Replace("\t", " ");
                file.Write(s);
            }
            file.WriteLine();
        }
        else
            for (var row = 0; row <= ROWS_PER_ONCE - 1; row++)
            {
                if (RowNo >= this.RowCount)
                    break;
                bool first = true;
                for (var col = 0; col <= this.ColumnCount - 1; col++)
                {
                    if (!first)
                        file.Write("\t"); //Constants.vbTab
                    else
                        first = false;
                    string s;
                    // we assume that all rows are shared! http://msdn.microsoft.com/en-us/library/ha5xt0d9.aspx
                    s = (string)this.Rows.SharedRow(0).Cells[col].GetEditedFormattedValue(RowNo, DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.ClipboardContent);
                    if (s.IndexOf("\t") >= 0) //Constants.vbTab
                        s = s.Replace("\t", " ");
                    file.Write(s);
                }
                file.WriteLine();
                RowNo += 1;
            }
    }






    private void ExportToTxt_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        try
        {
            string? s;
            s = this.OurCopyToString2();
            if (s != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.CheckPathExists = true;
                dlg.Filter = "Text files (*.txt)|*.txt|CSV file (*.csv)|*.csv|All files (*.*)|*.*";
                dlg.OverwritePrompt = true;
                dlg.Title = "Save to file";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(dlg.FileName, s, false);
                    MessageBox.Show(this.FindForm(), "File created: " + dlg.FileName );
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }


    /// <summary>
    ///     ''' Hide unused posiotion on menu
    ///     ''' </summary>
    ///     ''' <param name="sender"></param>
    ///     ''' <param name="e"></param>
    ///     ''' <remarks></remarks>
    private void ContextMenuStrip1_Opening(System.Object? sender, System.ComponentModel.CancelEventArgs e)
    {
        try
        {
            this.PasteToEnd_ToolStripMenuItem.Enabled = this.OurCanPasteFromClipboardToNewRows(true);
            this.Paste_ToolStripMenuItem.Enabled = this.OurCanPasteFromClipboardToNewRows(false);
            this.Delete_ToolStripMenuItem.Enabled = this.AllowUserToDeleteRows;
            this.Clear_ToolStripMenuItem.Enabled = !this.ReadOnly;
            //this.UpdateFromExcel_ToolStripMenuItem.Visible = !string.IsNullOrEmpty(this.UpdateFromExcel_KeyColumnName);
            //this.UpdateFromExcel_ToolStripMenuItem.Enabled = CanUpdateFromExcel();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }

    /// <summary>
    ///     ''' Do 'paste as new' from menu
    ///     ''' </summary>
    ///     ''' <param name="sender"></param>
    ///     ''' <param name="e"></param>
    ///     ''' <remarks></remarks>
    private void PasteToEnd_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        try
        {
            this.PasteFromClipboard(true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }

    /// <summary>
    ///     ''' Paste from current cell
    ///     ''' </summary>
    ///     ''' <param name="sender"></param>
    ///     ''' <param name="e"></param>
    ///     ''' <remarks></remarks>
    private void Paste_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        try
        {
            this.PasteFromClipboard(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }


    /// <summary>
    ///     ''' Check if paste to new rows can be run
    ///     ''' </summary>
    ///     ''' <returns></returns>
    ///     ''' <remarks></remarks>
    public bool OurCanPasteFromClipboardToNewRows(bool AppendToEnd)
    {
        if (AppendToEnd)
        {
            if (this.AllowUserToAddRows && Clipboard.ContainsText())
                return true;
        }
        else if (!this.ReadOnly && Clipboard.ContainsText())
            return true;
        return false;
    }

    private class Point : System.IComparable
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int CompareTo(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            Point o = (Point)obj;
            if (this.Y < o.Y)
                return -1;
            if (this.Y > o.Y)
                return 1;
            if (this.X < o.X)
                return -1;
            if (this.X > o.X)
                return 1;
            return 0;
        }
    }



    public bool OurIsInMasivePaste
    {
        get
        {
            return m_IsInMasivePasteOrClear;
        }
    }
    private bool m_IsInMasivePasteOrClear;

    public bool OurPaste_BlockMultiLine { get; set; }


    /// <summary>
    ///     ''' Do paste to new rows
    ///     ''' </summary>
    ///     ''' <param name="AppendToEnd">true -> append to end; false -> start from current cell</param>
    ///     ''' <returns></returns>
    ///     ''' <remarks></remarks>
    public bool PasteFromClipboard(bool AppendToEnd)
    {
        bool ret = false;
        this.Cursor = Cursors.WaitCursor;
        try
        {
            this.m_IsInMasivePasteOrClear = true;

            if (OurCanPasteFromClipboardToNewRows(AppendToEnd))
            {
                System.ComponentModel.IBindingList bl =(System.ComponentModel.IBindingList) this.DataSource;
                // Dim pasteTarget As DataGridViewCell

                string s;
                s = Clipboard.GetText();

                int FirstCol;
                int row;
                if (AppendToEnd)
                {
                    FirstCol = 0;
                    while (!this.Columns[FirstCol].Visible)
                        FirstCol += 1;
                    row = this.RowCount - 1;
                }
                else
                {
                    if (this.CurrentCellAddress.X < 0 || this.CurrentCellAddress.Y < 0)
                        return false;
                    FirstCol = this.CurrentCellAddress.X;
                    row = this.CurrentCellAddress.Y;
                }

                // remove last enter
                if (s.EndsWith(Constants.vbCr))
                    s = s.Substring(0, s.Length - 1);
                else if (s.EndsWith("\r\n")) //Constants.vbNewLine
                    s = s.Substring(0, s.Length - 2);

                string[] ssR; // rows
                s = Strings.Replace(s, "\n", "")??""; //Constants.vbLf
                if (s == null)
                    s = "";
                ssR = s.Split(Constants.vbCr);


                // if first column is empty on all rows -> start from second row+second column, because data are from our Multicells Copy 
                int startCol;
                int startRow;
                startCol = 1;
                startRow = 1; // first row is with column names
                foreach (string r in ssR)
                {
                    if (!r.StartsWith(Constants.vbTab))
                    {
                        startCol = 0;
                        startRow = 0;
                        break;
                    }
                }

                if (this.SelectedCells.Count > 1 && !AppendToEnd)
                {
                    // special copy paste to selected area

                    int ssRow;
                    int ssCol;
                    ssRow = startRow;
                    ssCol = startCol;

                    // 
                    // Dim l As New List(Of Drawing.Point)
                    SortedList<Point, Point> l = new SortedList<Point, Point>();
                    foreach (DataGridViewCell cell in this.SelectedCells)
                    {
                        Point p = new Point(cell.ColumnIndex, cell.RowIndex);
                        l.Add(p, p);
                    }

                    int lastRow;
                    int lastCol;
                    {
                        var withBlock = l.Keys[0];
                        lastRow = withBlock.Y;
                        lastCol = withBlock.X;
                    }


                    string[]? ssC; // cells
                    ssC = null;

                    if (ssR.GetUpperBound(0) >= startRow)
                    {
                        foreach (Point cell in l.Keys)
                        {
                            if (lastRow != cell.Y)
                            {
                                lastRow = cell.Y;
                                // next row of data
                                ssRow += 1;
                                if (ssRow > ssR.GetUpperBound(0))
                                    ssRow = startRow;
                                ssCol = startCol;
                                ssC = null;
                            }
                            if (ssC == null)
                                ssC = ssR[ssRow].Split(Constants.vbTab);

                            if (ssCol > ssC.GetUpperBound(0))
                                ssCol = startCol;

                            if (ssCol <= ssC.GetUpperBound(0))
                            {
                                // set value
                                this.CurrentCell = this[cell.X, cell.Y];
                                this.CurrentCell = this[cell.X, cell.Y];
                                this.NotifyCurrentCellDirty(true); // this can change current cell!
                                PasteToCell(ssC[ssCol], this.CurrentCell, ref ret);
                                this.NotifyCurrentCellDirty(false);
                            }

                            ssCol += 1;
                        }
                        // return to start -> save data
                        if (l.Count > 0)
                        {
                            {
                                var withBlock = l.Keys[0];
                                this.CurrentCell = this[withBlock.X, withBlock.Y];
                                this.CurrentCell = this[withBlock.X, withBlock.Y];
                            }
                        }
                    }
                }
                else
                {
                    int FirstRow = row;
                    for (int ssRow = startRow; ssRow <= ssR.Count() - 1; ssRow++)
                    {
                        string sr;
                        sr = ssR[ssRow];

                        // start next row
                        int col;
                        col = FirstCol;

                        string?[] ssC; // cells
                        if (string.IsNullOrEmpty(sr))
                        {
                            ssC = new string[1];
                            ssC[0] = null;
                        }
                        else
                            ssC = sr.Split(Constants.vbTab);
                        for (int ssCol = startCol; ssCol <= ssC.Count() - 1; ssCol++)
                        {
                            string? sC;
                            sC = ssC[ssCol];

                            // skip hidden columns
                            do
                            {
                                if (col >= this.ColumnCount)
                                    break;
                                if (this[col, row].Visible)
                                    break;
                                col += 1;
                            }
                            while (true);
                            if (col < this.ColumnCount)
                            {
                                // set value
                                this.CurrentCell = this[col, row];
                                this.CurrentCell = this[col, row]; // again, because can be changed
                                this.NotifyCurrentCellDirty(true); // this can change CurrentCell and pasteTarget!
                                if (this.CurrentCell != null && this.CurrentCell.RowIndex == row 
                                    && this.CurrentCell.ColumnIndex == col
                                    && sC!=null)
                                    PasteToCell(sC, this.CurrentCell, ref ret);
                                this.NotifyCurrentCellDirty(false);
                                col += 1;
                            }
                        }
                        row = row + 1;
                        if (row >= this.RowCount)
                            break;
                        if (this.OurPaste_BlockMultiLine)
                            break;
                    }
                    // return to start -> save data
                    if (FirstRow < this.RowCount && FirstCol < this.ColumnCount)
                    {
                        this.CurrentCell = this[FirstCol, FirstRow];
                        this.CurrentCell = this[FirstCol, FirstRow];
                    }
                }
            }
        }
        finally
        {
            this.m_IsInMasivePasteOrClear = false;
            this.Cursor = Cursors.Default;
        }
        return ret;
    }


    /// <summary>
    ///     ''' Copy from string to cell
    ///     ''' </summary>
    ///     ''' <param name="s"></param>
    ///     ''' <param name="pasteTarget"></param>
    ///     ''' <param name="ret"></param>
    ///     ''' <remarks></remarks>
    private void PasteToCell(string? s, DataGridViewCell pasteTarget, ref bool ret)
    {
        if (!pasteTarget.ReadOnly)
        {
            // check if can edit
            DataGridViewCellCancelEventArgs arg = new DataGridViewCellCancelEventArgs(pasteTarget.ColumnIndex, pasteTarget.RowIndex);
            this.OnCellBeginEdit(arg);
            if (!arg.Cancel)
            {

                // ListBoxes
                if (pasteTarget is OurDataGridViewComboBoxCell2)
                {
                    OurDataGridViewComboBoxCell2 cb = (OurDataGridViewComboBoxCell2)pasteTarget;
                    if (cb.Items != null && cb.Items.Count > 0)
                    {
                        // find text on list
                        bool ok = true;
                        if (string.IsNullOrEmpty(cb.DisplayMember))
                        {
                            // no display member -> take ToString
                            if (string.IsNullOrEmpty(s))
                                cb.Value = null;
                            else
                            {
                                ok = false;
                                foreach (object itm in cb.Items)
                                {
                                    if (string.Equals(itm.ToString(), s, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        ok = true;
                                        if (!string.IsNullOrEmpty(cb.ValueMember))
                                            cb.Value = itm.GetType().GetProperty(cb.ValueMember)?.GetValue(itm, null);
                                        else
                                            cb.Value = itm;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (cb.Items[0] is DataRowView)
                        {
                            // special case for DataRowView
                            if (string.IsNullOrEmpty(s))
                                cb.Value = DBNull.Value;
                            else
                            {
                                ok = false;
                                foreach (DataRowView itm in cb.Items)
                                {
                                    if (string.Equals( itm.Row[cb.DisplayMember] as string , s, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        ok = true;
                                        if (!string.IsNullOrEmpty(cb.ValueMember))
                                            cb.Value = itm.Row[cb.ValueMember];
                                        else
                                            cb.Value = itm;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        // else use reflection
                        if (string.IsNullOrEmpty(s))
                            cb.Value = null;
                        else
                        {
                            ok = false;
                            object? BetterItm = null;
                            foreach (object itm in cb.Items)
                            {
                                var cc = char.ConvertFromUtf32(160);
                                string? v;
                                v = itm.GetType().GetProperty(cb.DisplayMember)?.GetValue(itm, null)?.ToString();
                                if (string.Equals(v,s, StringComparison.CurrentCultureIgnoreCase)
                                    || string.Equals(v,s.Replace(cc, " "), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    ok = true;
                                    if (!string.IsNullOrEmpty(cb.ValueMember))
                                        cb.Value = itm.GetType().GetProperty(cb.ValueMember)?.GetValue(itm, null);
                                    else
                                        cb.Value = itm;
                                    break;
                                }
                                else if (BetterItm == null && v!=null &&  v.StartsWith(s, StringComparison.CurrentCultureIgnoreCase))
                                    BetterItm = itm;
                            }
                            // if no match -> put better item
                            if (!ok && BetterItm != null)
                            {
                                ok = true;
                                if (!string.IsNullOrEmpty(cb.ValueMember))
                                    cb.Value = BetterItm.GetType().GetProperty(cb.ValueMember)?.GetValue(BetterItm, null);
                                else
                                    cb.Value = BetterItm;
                            }
                        }
                        if (!ok)
                            MessageBox.Show(this.FindForm(), "Can't past value to DropDownListBox: " + s);
                        return;
                    }
                }
                //else if (pasteTarget is LibWin.OurDataGridViewComboBoxCell)
                //{
                //    GbbLibWin.OurDataGridViewComboBoxCell cb = pasteTarget;
                //    if (cb.Items != null && cb.Items.Count > 0)
                //    {
                //        // find text on list
                //        bool ok = true;
                //        if (string.IsNullOrEmpty(cb.DisplayMember))
                //        {
                //            // no display member -> take ToString
                //            if (string.IsNullOrEmpty(s))
                //                cb.Value = null;
                //            else
                //            {
                //                ok = false;
                //                foreach (object itm in cb.Items)
                //                {
                //                    if (itm.ToString() == s)
                //                    {
                //                        ok = true;
                //                        if (!string.IsNullOrEmpty(cb.ValueMember))
                //                            cb.Value = itm.GetType().GetProperty(cb.ValueMember).GetValue(itm, null);
                //                        else
                //                            cb.Value = itm;
                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //        else if (cb.Items(0) is DataRowView)
                //        {
                //            // special case for DataRowView
                //            if (string.IsNullOrEmpty(s))
                //                cb.Value = DBNull.Value;
                //            else
                //            {
                //                ok = false;
                //                foreach (DataRowView itm in cb.Items)
                //                {
                //                    if (itm.Row(cb.DisplayMember) == s)
                //                    {
                //                        ok = true;
                //                        if (!string.IsNullOrEmpty(cb.ValueMember))
                //                            cb.Value = itm.Row(cb.ValueMember);
                //                        else
                //                            cb.Value = itm;
                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //        else
                //                                    // else use reflection
                //                                    if (string.IsNullOrEmpty(s))
                //            cb.Value = null;
                //        else
                //        {
                //            ok = false;
                //            object BetterItm = null;
                //            foreach (object itm in cb.Items)
                //            {
                //                string v;
                //                v = itm.GetType().GetProperty(cb.DisplayMember).GetValue(itm, null).ToString;
                //                if (v == s)
                //                {
                //                    ok = true;
                //                    if (!string.IsNullOrEmpty(cb.ValueMember))
                //                        cb.Value = itm.GetType().GetProperty(cb.ValueMember).GetValue(itm, null);
                //                    else
                //                        cb.Value = itm;
                //                    break;
                //                }
                //                else if (BetterItm == null
                //                                                    && v.StartsWith(s))
                //                    BetterItm = itm;
                //            }
                //            // if no match -> put better item
                //            if (!ok && BetterItm != null)
                //            {
                //                ok = true;
                //                if (!string.IsNullOrEmpty(cb.ValueMember))
                //                    cb.Value = BetterItm.GetType().GetProperty(cb.ValueMember).GetValue(BetterItm, null);
                //                else
                //                    cb.Value = BetterItm;
                //            }
                //        }
                //        if (!ok)
                //            GbbLibWin.Log.LogMsgBox(this, "Can't past value to DropDownListBox: " + s);
                //        return;
                //    }
                //}

                // remove char(160) (space)
                string? ss=null;
                if (s!=null)
                    ss= s.Replace(char.ConvertFromUtf32(160), "", StringComparison.CurrentCulture);

                // others
                if (pasteTarget.ValueType == typeof(string))
                {
                    if (string.IsNullOrEmpty(s))
                        pasteTarget.Value = null;
                    else
                        pasteTarget.Value = s;
                    ret = true;
                }
                // date
                else if (pasteTarget.ValueType == typeof(DateTime)
                                || pasteTarget.ValueType == typeof(Nullable<DateTime>))
                {
                    if (string.IsNullOrEmpty(s))
                        pasteTarget.Value = null;
                    else
                    {
                        DateTime parsed;
                        if (DateTime.TryParse(s, out parsed))
                        {
                            pasteTarget.Value = parsed;
                            ret = true;
                        }
                        else
                            throw new ApplicationException("This is not date: " + s);
                    }
                }
                else
                {
                    double div = 1;
                    if (s!=null && s.IndexOf("%") >= 0)
                    {
                        div = 100;
                        s = s.Replace("%", "");
                    }
                    // integer
                    if (pasteTarget.ValueType == typeof(int) || pasteTarget.ValueType == typeof(Nullable<int>) || pasteTarget.ValueType == typeof(Int16) || pasteTarget.ValueType == typeof(Nullable<Int16>))
                    {
                        if (string.IsNullOrEmpty(s))
                            pasteTarget.Value = null;
                        else
                        {
                            int parsed;
                            if (s.StartsWith("T") || s.StartsWith("t"))
                            {
                                pasteTarget.Value = 1;
                                ret = true;
                            }
                            else if (s.StartsWith("N") || s.StartsWith("n")
                                                        || s.StartsWith("F") || s.StartsWith("f"))
                            {
                                pasteTarget.Value = 0;
                                ret = true;
                            }
                            else if (int.TryParse(ss, out parsed))
                            {
                                pasteTarget.Value = parsed;
                                ret = true;
                            }
                            else
                                throw new ApplicationException("This is not integer: " + s);
                        }
                    }
                    // bool
                    else if (pasteTarget.ValueType == typeof(bool)
                                        || pasteTarget.ValueType == typeof(Nullable<bool>))
                    {
                        if (s != null)
                        {
                            if (s.StartsWith("T") || s.StartsWith("t") || (Information.IsNumeric(s) && System.Convert.ToInt32(s) != 0))
                            {
                                pasteTarget.Value = true;
                                ret = true;
                            }
                            else if (s=="" || s.StartsWith("N") || s.StartsWith("n")
                                                    || s.StartsWith("F") || s.StartsWith("f")
                                                    || (Information.IsNumeric(s) && System.Convert.ToInt32(s) == 0))
                            {
                                pasteTarget.Value = false;
                                ret = true;
                            }
                            else 
                                throw new ApplicationException("This is not bool: " + s);
                        }
                    }
                    // double
                    else if (pasteTarget.ValueType == typeof(double)
                                        || pasteTarget.ValueType == typeof(Nullable<double>))
                    {
                        if (string.IsNullOrEmpty(s))
                            pasteTarget.Value = null;
                        else
                        {
                            double parsed;
                            if (double.TryParse(ss, out parsed))
                            {
                                pasteTarget.Value = parsed / div;
                                ret = true;
                            }
                            else
                                throw new ApplicationException("This is not number: " + s);
                        }
                    }
                    // decimal
                    else if (pasteTarget.ValueType == typeof(decimal)
                                        || pasteTarget.ValueType == typeof(Nullable<decimal>))
                    {
                        if (string.IsNullOrEmpty(s))
                            pasteTarget.Value = null;
                        else
                        {
                            decimal parsed;
                            if (decimal.TryParse(ss, out parsed))
                            {
                                pasteTarget.Value = parsed;
                                ret = true;
                            }
                            else
                                throw new ApplicationException("This is not number: " + s);
                        }
                    }
                }
            }
        }
    }

    // 
    // Error support
    // 

    public bool DataErrorMustThrowException = false;
    private bool m_InError;
    private void DataGridView_DataError(object? sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
    {
        if (DataErrorMustThrowException)
            e.ThrowException = true;
        else
        {
            if (!this.m_InError)
            {
                try
                {
                    this.m_InError = true;
                    // skip "Index 0 does not have value" error!
                    // skip "Indeks 0 nie ma wartości." error
                    if (e.Exception.Message.IndexOf("does not have a value.") < 0 && e.Exception.Message.IndexOf("nie ma warto") < 0)
                        MessageBox.Show(this.FindForm(), e.Exception.Message);
                }
                finally
                {
                    this.m_InError = false;
                }
            }
            e.ThrowException = false;
        }
    }


    // 
    // AutoSave on row exit
    // 

    private bool LastIsRowDirty;
    

    private void DataGridView_RowValidating(object? sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
    {
        this.LastIsRowDirty = this.IsCurrentRowDirty;
    }

    private void DataGridView_RowValidated(object? sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
        if (this.LastIsRowDirty)
        {
            DoSaveArgs args = new(this, e.RowIndex);
            OnOurDoSaveAfterRowChange(args);
            Rows[e.RowIndex].ErrorText = args.Error;
        }
    }

    // 
    // AutoSave on delete
    // 

    private void DataGridView_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
    {
        if (e.Row != null)
        {
            DoSaveArgs args = new DoSaveArgs(e.Row.DataBoundItem);
            OnOurDoSaveAfterRowChange(args);
            e.Cancel = args.Canceled;
        }
    }

    // 
    // Save data
    // 

    public class DoSaveArgs : EventArgs
    {
        //public bool IsNew;
        public bool IsDeleted;
        public object Data;

        public bool Canceled;
        public string? Error;

        public DoSaveArgs(OurDataGridView v, int _RowIndex)
        {
            var r = v.Rows[_RowIndex];
            //IsNew = r.IsNewRow; // to nie działa
            Data = r.DataBoundItem;
        }

        public DoSaveArgs(object DeletedRow)
        {
            IsDeleted = true;
            Data = DeletedRow;
        }
    }



    public delegate void OurDoSaveAfterRowChangeEventHandler(object sender, DoSaveArgs arg);
    public event OurDoSaveAfterRowChangeEventHandler? OurDoSaveAfterRowChange;

    protected virtual void OnOurDoSaveAfterRowChange(DoSaveArgs arg)
    {
        if (this.DesignMode)
            return;

        // try show data to user without changes
        int r;
        System.Drawing.Point c;
        r = this.FirstDisplayedScrollingRowIndex;
        c = this.CurrentCellAddress;

        OurDoSaveAfterRowChange?.Invoke(this, arg);

        if (r >= 0)
        {
            if (r != this.FirstDisplayedScrollingRowIndex)
                this.FirstDisplayedScrollingRowIndex = r;
        }

        if (c.Y >= 0 && c.Y < this.RowCount && c.X >= 0 && c.X < this.ColumnCount)
        {
            if (this.CurrentCell == null || (this.CurrentCell.RowIndex != c.Y || this.CurrentCell.ColumnIndex != c.X))
            {
                try
                {
                    this.CurrentCell = this.Rows[c.Y].Cells[c.X];
                }
                catch (Exception )
                {
                }
            }
        }
    }



    // 
    // ICopyPasteUI
    // 

    public bool OurCopy()
    {
        return this.OurCopyToClipboard();
    }

    private bool OurCut()
    {
        if (this.OurCopyToClipboard())
            return OurClear();
        else
            return false;
    }

    public bool OurPaste()
    {
        return this.PasteFromClipboard(false);
    }

    public bool OurSelectAll()
    {
        this.SelectAll();
        return true;
    }

    private void Clear_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        OurClear();
    }


    // 
    // delete
    // 

    private void Delete_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        try
        {
            this.OurValidateMe();
            this.ProcessDeleteKey(0);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }

    public void OurSetReadonly()
    {
        this.AllowUserToAddRows = false;
        this.AllowUserToDeleteRows = false;
        this.ReadOnly = true;
    }

    public void OurResetReadonly()
    {
        this.AllowUserToAddRows = true;
        this.AllowUserToDeleteRows = true;
        this.ReadOnly = false;
    }

    // 
    // find
    // 
    public string? OurFindText;

    public bool OurFindNext()
    {
        int StartRow;
        int StartCol;

        string? t;
        t = this.OurFindText;
        if (string.IsNullOrEmpty(t))
            return false;

        if (this.CurrentCell == null)
            return false;
        StartCol = this.CurrentCell.ColumnIndex;
        StartRow = this.CurrentCell.RowIndex;

        var currCol = StartCol + 1;
        var currRow = StartRow;

        do
        {
            do
            {
                // next cell
                currCol += 1;
                if (currCol >= this.ColumnCount)
                {
                    currRow += 1;
                    currCol = 0;
                }

                if (currRow >= this.Rows.Count)
                    currRow = 0;
                if (currCol == StartCol && currRow == StartRow)
                    return false;

                // skip hidden columns
                if (this.Columns[currCol].Visible)
                    break;
            }
            while (true);
            string? v;
            DataGridViewCell c;
            c = this[currCol, currRow];
            v = null;
            if (c is OurDataGridViewComboBoxCell2)
            {
                OurDataGridViewComboBoxCell2 cb = (OurDataGridViewComboBoxCell2)c;
                v = (string)cb.FormattedValue;
            }

            if (v == null)
            {
                if (c.Value != null)
                    v = c.Value.ToString();
            }


            // check value
            if (v != null && v.IndexOf(t, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                this.CurrentCell = c;
                return true;
            }
        }
        while (true)// value
;
    }

    public void OurFindNext_UI()
    {
        try
        {
            OurDataGridView_Find_Form dlg = new OurDataGridView_Find_Form();
            dlg.OurDataGridView = this;
            dlg.ShowDialog(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }

    private void Find_ToolStripMenuItem_Click(object? sender, System.EventArgs e)
    {
        OurFindNext_UI();
    }

    public void OurOpenZoom_UI()
    {
        try
        {
            if (this.CurrentCell == null)
                return;

            DataGridViewCell c;
            c = this.CurrentCell;

            OurDataGridView_Zoom dlg = new OurDataGridView_Zoom();
            if (c.Value != null)
                dlg.OurText = c.Value.ToString();
            dlg.OurReadOnly = this.ReadOnly || c.ReadOnly;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                bool ret = false;
                this.NotifyCurrentCellDirty(true);
                PasteToCell(dlg.OurText, this.CurrentCell, ref ret);
                this.NotifyCurrentCellDirty(false);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.FindForm(), ex.Message);
        }
    }


    // 
    // OnCellParsing -> better percent% number parsing
    // 
    protected override void OnCellParsing(System.Windows.Forms.DataGridViewCellParsingEventArgs e)
    {
        if (e.Value is string && e.InheritedCellStyle?.Format != null 
            && e.InheritedCellStyle.Format.StartsWith("P", StringComparison.CurrentCultureIgnoreCase) 
            && (e.DesiredType == typeof(double) || e.DesiredType == typeof(Nullable<double>)))
        {
            string? s = e.Value.ToString();
            if (s != null)
            {
                double d;
                if (double.TryParse(s.Replace("%", ""), out d))
                {
                    e.Value = d / 100;
                    e.ParsingApplied = true; // bez tego Cell.SetValue nie otrzymywało nowej wartości!
                }
            }
        }

        // If Not e.ParsingApplied Then
        base.OnCellParsing(e);
    }


    /// <summary>
    ///     ''' calling OnValidating, to remove unwanted rows
    ///     ''' </summary>
    ///     ''' <remarks></remarks>
    public void OurValidateMe()
    {
        System.ComponentModel.CancelEventArgs p = new System.ComponentModel.CancelEventArgs();
        this.OnValidating(p);
    }


    // 
    // Better support of ReadOnly property (remember a list of ReadOnly columns)
    // 

    public new bool ReadOnly
    {
        get
        {
            return base.ReadOnly;
        }
        set
        {
            if (base.ReadOnly != value)
            {
                if (value)
                {
                    // remember ReadOnly columns
                    this.m_ReadOnlyColumns.Clear();
                    foreach (DataGridViewColumn itm in this.Columns)
                    {
                        if (itm.ReadOnly)
                            this.m_ReadOnlyColumns.Add(itm);
                    }
                }
                base.ReadOnly = value;
                if (!value)
                {
                    // restore columns readonly
                    foreach (var itm in this.m_ReadOnlyColumns)
                        itm.ReadOnly = true;
                }
            }
        }
    }

    private List<DataGridViewColumn> m_ReadOnlyColumns = new List<DataGridViewColumn>();


}
