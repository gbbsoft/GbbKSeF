/*
 * Author: Gbb Software 2002
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Data;

namespace GbbLibWin;


/// -----------------------------------------------------------------------------
/// ''' Project	 : MultiColumnCombo
/// ''' Class	 : Controls.MultiColumnComboBox
/// ''' -----------------------------------------------------------------------------
/// ''' <summary>
/// ''' MultiColumnCombo is a subclass of the windows forms Combobox control.  This control adds the option of images in the drop down list,
/// ''' allows multiple columns to be in the list, allows a header to describe the columns in the list, and allows for databinding to the columns.
/// ''' </summary>
/// ''' <remarks>
/// ''' For updated versions of if you have any bug fixes go to http://www.edneeis.com.  Also special thanks to Loren Lowe (lorenmlowe@yahoo.com)
/// ''' for providing code and concept for the AutoSize feature of the columns.
/// ''' </remarks>
/// ''' <history>
/// ''' 	[ed]	6/11/2004	Created
/// ''' </history>
/// ''' -----------------------------------------------------------------------------
public class OurDataGridViewComboBoxEditingControl2 
    : System.Windows.Forms.DataGridViewComboBoxEditingControl, IDataGridViewEditingControl
{
    public OurDataGridViewComboBoxEditingControl2(ref ComboBox cbo)
    {
        _columns = new ColumnCollection();
        // assign all properties from cbo to me
        // Dim pi As Reflection.PropertyInfo
        // For Each pi In cbo.GetType.GetProperties
        // Dim s As String = pi.Attributes.ToString
        // If pi.CanWrite Then
        // 'On Error Resume Next 'just in case
        // Me.GetType.GetProperty(pi.Name).SetValue(Me, pi.GetValue(cbo, Nothing), Nothing)
        // End If
        // Next
        // TODO: have it consume ALL properties of original combo
        this.Anchor = cbo.Anchor;
        this.BackColor = cbo.BackColor;
        this.BackgroundImage = cbo.BackgroundImage;
        this.CausesValidation = cbo.CausesValidation;
        this.ContextMenuStrip = cbo.ContextMenuStrip;
        this.DataSource = cbo.DataSource;
        this.DisplayMember = cbo.DisplayMember;
        this.Dock = cbo.Dock;
        this.DropDownStyle = cbo.DropDownStyle;
        this.DropDownWidth = cbo.DropDownWidth;
        this.Enabled = cbo.Enabled;
        this.Font = cbo.Font;
        this.ForeColor = cbo.ForeColor;
        this.IntegralHeight = cbo.IntegralHeight;
        foreach (var item in cbo.Items)
            this.Items.Add(item);
        // If cbo.Items.Count > 0 Then
        // Dim tmp(cbo.Items.Count) As Object
        // cbo.Items.CopyTo(tmp, 0)
        // Me.Items.AddRange(tmp)
        // End If
        this.MaxDropDownItems = cbo.MaxDropDownItems;
        this.MaxLength = cbo.MaxLength;
        this.Sorted = cbo.Sorted;
        this.Text = cbo.Text;
        this.TabStop = cbo.TabStop;
        this.ValueMember = cbo.ValueMember;
        this.Visible = cbo.Visible;
        this.Location = cbo.Location;
        this.Size = cbo.Size;
        this.TabIndex = cbo.TabIndex;
        // set to ownerdraw
        this.DrawMode = DrawMode.OwnerDrawFixed;
        // switch combos
        Control parent = cbo.Parent;
        parent.Controls.Remove(cbo);
        parent.Controls.Add(this);
    }



    public OurDataGridViewComboBoxEditingControl2()
    {
        _columns = new ColumnCollection();
        // set to ownerdraw
        this.DrawMode = DrawMode.OwnerDrawFixed;
    }


    public event OurDataGridViewComboBoxEditingControl2.CountChangedEventHandler? ColumnCountChanged;

    // internal members for added properties
    private ImageList? _imageList;
    private string _imageIndexMember = string.Empty;
    private ColumnCollection? __columns;

    private ColumnCollection _columns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            ArgumentNullException.ThrowIfNull(__columns);
            return __columns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__columns != null)
            {
                __columns.CountChanged -= _columns_CountChanged;
            }

            __columns = value;
            if (__columns != null)
            {
                __columns.CountChanged += _columns_CountChanged;
            }
        }
    }

    private bool _showColumns = false;
    private bool _showColumnHeaders = false;
    private Border3DStyle _columnHeaderBorderStyle = Border3DStyle.Flat;
    private bool _showImageInText = false;
    private Color _SelectionForeColor = SystemColors.HighlightText;
    private Color _SelectionBackColor = SystemColors.Highlight;

    private const int ScrollBarWidth = 36;
    private const int MinItemsForScrollBar = 4;

    /// -----------------------------------------------------------------------------
    ///     ''' <summary>
    ///     ''' Internal flag which causes the autosizing of columns to be performed, similiar to an IsDirty flag for resizing.
    ///     ''' </summary>
    ///     ''' <remarks>
    ///     ''' </remarks>
    ///     ''' <history>
    ///     ''' 	[ed]	6/11/2004	Created
    ///     ''' </history>
    ///     ''' -----------------------------------------------------------------------------

    protected bool PerformResize
    {
        get
        {
            return _performResize;
        }
        set
        {
            _performResize = value;
        }
    }
    private bool _performResize = true;

    // this method provides a way for the developer to manually force
    // the autosize columns to refresh their width.
    public void RefreshColumns()
    {
        // reset resize flag
        this.PerformResize = true;
    }

    [Description("Determines whether or not to show the image in the textbox when in DropDownList mode.")]
    public bool ShowImageInText
    {
        get
        {
            return _showImageInText;
        }
        set
        {
            _showImageInText = value;
        }
    }

    [Description("The image list to get images from for the list items.")]
    public ImageList? ImageList
    {
        get
        {
            return _imageList;
        }
        set
        {
            _imageList = value;
        }
    }

    [Description("Indicates the property to use the index for the ImageList when getting item images.")]
    public string ImageIndexMember
    {
        get
        {
            return _imageIndexMember;
        }
        set
        {
            _imageIndexMember = value;
        }
    }

    [Description("The column information for the list.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ColumnCollection Columns
    {
        get
        {
            return _columns;
        }
    }

    // if false then defaults to normal or image combo regardless of columns collection
    [Description("Determines whether or not to show the columns from the columns collection.")]
    public bool ShowColumns
    {
        get
        {
            return _showColumns;
        }
        set
        {
            _showColumns = value;
        }
    }

    [Description("Determines whether or not to show the column header.")]
    public bool ShowColumnHeader
    {
        get
        {
            return _showColumnHeaders;
        }
        set
        {
            _showColumnHeaders = value;
            this.IntegralHeight = !_showColumnHeaders;
            if (_showColumnHeaders)
                this.DrawMode = DrawMode.OwnerDrawVariable;
            else
                this.DrawMode = DrawMode.OwnerDrawFixed;
        }
    }

    [Description("Gets or sets the border style for column header.")]
    public Border3DStyle ColumnHeaderBorderStyle
    {
        get
        {
            return _columnHeaderBorderStyle;
        }
        set
        {
            _columnHeaderBorderStyle = value;
        }
    }

    [Description("Sets or Gets the color of the selected item's text.")]
    public Color SelectionForeColor
    {
        get
        {
            return _SelectionForeColor;
        }
        set
        {
            _SelectionForeColor = value;
        }
    }

    [Description("Sets or Gets the color of the selected item's background.")]
    public Color SelectionBackColor
    {
        get
        {
            return _SelectionBackColor;
        }
        set
        {
            _SelectionBackColor = value;
        }
    }

    protected override void OnDrawItem(DrawItemEventArgs ea)
    {
        // this replaces the normal drawing of the dropdown list
        ea.DrawBackground();
        ea.DrawFocusRectangle();

        int iwidth = 0;

        // test to see if height is inflated if so then this has a header
        bool IsDrawingHeader = (ea.Bounds.Height > this.ItemHeight);
        int useTop = ea.Bounds.Y;

        if (IsDrawingHeader && _showColumnHeaders)
            useTop = ea.Bounds.Top + this.FontHeight;

        // handle image
        try
        {
            int imageindex = -1;
            // test for imagelist to avoid delay caused by exception handler
            if (ImageList != null)
            {
                Size imageSize = ImageList.ImageSize;
                // get imageindexmember value
                // Dim iInfo As Reflection.PropertyInfo = Items(ea.Index).GetType.GetProperty(Me.ImageIndexMember)
                // If Not iInfo Is Nothing Then
                // optionally show image in textbox when in dropdownlist mode
                bool IsInEdit = (ea.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit;
                if ((IsInEdit && _showImageInText) | !IsInEdit)
                {
                    // draw image
                    imageindex = System.Convert.ToInt32(ReflectValue(Items[ea.Index], this.ImageIndexMember));
                    // ImageList.Draw(ea.Graphics, ea.Bounds.Left, ea.Bounds.Top, imageindex)
                    ImageList.Draw(ea.Graphics, ea.Bounds.Left, useTop, imageindex);
                    iwidth = imageSize.Width;
                }
            }
        }
        catch (Exception )
        {
            // image drawing skipped
            throw ;
        }

        // handle regular drawing
        try
        {
            if (ea.Index != -1)
            {
                // handle columns
                // dropdownlist fix provided by David Gauerke (dlg@com-systems.com)
                // do not draw columns for textbox if in dropdownlist mode
                if (_showColumns && this.Columns.Count > 0 && (ea.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
                {
                    int cnt = 0;
                    int prevWidth = 0;
                    foreach (Column col in this.Columns)
                    {
                        cnt += 1;

                        if (cnt == 1)
                            prevWidth = ea.Bounds.X;
                        int useX = ea.Bounds.X + col.Width;
                        int useY = ea.Bounds.Y + ea.Bounds.Height;
                        // Dim useTop As Integer = ea.Bounds.Y

                        // 'test to see if height is inflated if so then this has a header
                        // Dim IsDrawingHeader As Boolean = (ea.Bounds.Height > Me.ItemHeight)

                        if (IsDrawingHeader && _showColumnHeaders)
                        {
                            // adjust top for drawing of other item parts
                            // useTop = ea.Bounds.Top + Me.FontHeight
                            int tmpX = useX;
                            if (cnt == this.Columns.Count)
                            {
                                // last column make sure it fills entire width
                                if (iwidth == 0)
                                    tmpX = ea.Bounds.Width - useX;
                            }
                            int tmpLeft = ea.Bounds.X + prevWidth;
                            // adjust headers if image is drawn
                            if (cnt > 1)
                            {
                                tmpLeft += iwidth;
                                // of this is the last column then extend it to the end regardless of set width
                                // Thanks to Trinh Ngoc Trac (trinhngoctrac@yahoo.com) for the catch and fix
                                if (cnt == this.Columns.Count)
                                    tmpX = ea.Bounds.Width;
                            }
                            else
                                tmpX += iwidth;
                            RectangleF recth = new RectangleF(tmpLeft, ea.Bounds.Top, tmpX, this.FontHeight);
                            // Dim recth As New RectangleF((ea.Bounds.X + prevWidth) + iwidth, ea.Bounds.Top, tmpX, Me.FontHeight)
                            // draw column header background
                            ea.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), recth);
                            ControlPaint.DrawBorder3D(ea.Graphics, System.Convert.ToInt32(recth.X), System.Convert.ToInt32(recth.Y), System.Convert.ToInt32(recth.Width), System.Convert.ToInt32(recth.Height), _columnHeaderBorderStyle);

                            // use col.Header property or member as backup
                            string txtHeader = col.Header;
                            if (txtHeader.Length == 0)
                                txtHeader = col.ColumnMember;
                            // draw header text
                            ArgumentNullException.ThrowIfNull(ea.Font);
                            ea.Graphics.DrawString(txtHeader, new Font(ea.Font, FontStyle.Bold), new SolidBrush(Color.Black), recth);
                        }

                        // get the text from the bound object by property name in the columnmember
                        string display = this.GetDisplayText(col.DisplayNullAs, Items[ea.Index], col.ColumnMember);
                        int bufferHt = 2;
                        RectangleF rectf = new RectangleF((ea.Bounds.X + prevWidth) + iwidth, useTop, useX, this.FontHeight + bufferHt);
                        if (cnt == this.Columns.Count)
                            // ensure that the last columne is the full width
                            rectf.Width = ea.Bounds.Width;

                        // change drawing colors if the items is selected
                        // Thanks to Ivan Stipcevic (ivan.stipcevic@dcsl.com) for adding this feature
                        bool isSelected = ((ea.State & DrawItemState.Selected) == DrawItemState.Selected);
                        if (isSelected)
                        {
                            // selected so use selection colors
                            ea.Graphics.FillRectangle(new SolidBrush(this.SelectionBackColor), rectf);
                            ArgumentNullException.ThrowIfNull(ea.Font);
                            ea.Graphics.DrawString(display, ea.Font, new SolidBrush(this.SelectionForeColor), rectf);
                        }
                        else
                        {
                            // not selected so use column color
                            ea.Graphics.FillRectangle(new SolidBrush(col.Color), rectf);
                            ArgumentNullException.ThrowIfNull(ea.Font);
                            ea.Graphics.DrawString(display, ea.Font, new SolidBrush(ea.ForeColor), rectf);
                        }

                        if (cnt > 1)
                        {
                            // draw the line for everyone but the first one
                            // other good colors for the line is silver and gray
                            int buffer = 0;
                            if (IsDrawingHeader && _showColumnHeaders)
                            {
                                buffer = this.FontHeight + 1;
                                if ((_columnHeaderBorderStyle & Border3DStyle.Adjust) != Border3DStyle.Adjust)
                                    buffer += 1;
                            }
                            // line length work around provided by David Gauerke (dlg@com-systems.com)
                            // extend past needed length to ensure proper drawing
                            ea.Graphics.DrawLine(System.Drawing.Pens.LightGray, prevWidth + iwidth, useTop + ea.Bounds.Top + buffer, prevWidth + iwidth, this.FontHeight);
                        }
                        // remember previous column width
                        prevWidth += col.Width;
                    }
                }
                else
                {
                    // hide columns deafault to normal
                    // get the text from the bound object by property name in the columnmember
                    // Dim display As String = GetTextForItem(Items(ea.Index))
                    string display = this.GetDisplayText("NULL", Items[ea.Index], this.DisplayMember);
                    ArgumentNullException.ThrowIfNull(ea.Font);
                    ea.Graphics.DrawString(display, ea.Font, new SolidBrush(ea.ForeColor), ea.Bounds.Left + iwidth, ea.Bounds.Top);
                }
            }
            else
            {
                // draw default simplest form
                ArgumentNullException.ThrowIfNull(ea.Font);
                ea.Graphics.DrawString(this.Text, ea.Font, new SolidBrush(ea.ForeColor), Bounds.Left, Bounds.Top);
            }
        }
        catch (Exception )
        {
            // draw default simplest form
            ArgumentNullException.ThrowIfNull(ea.Font);
            ea.Graphics.DrawString(this.Text, ea.Font, new SolidBrush(ea.ForeColor), Bounds.Left, Bounds.Top);
        }

        base.OnDrawItem(ea);
    }

    protected override void OnMeasureItem(System.Windows.Forms.MeasureItemEventArgs e)
    {
        // if this is the first row then add height for the column headers
        if (e.Index == 0 && _showColumnHeaders)
            e.ItemHeight += this.FontHeight;
        base.OnMeasureItem(e);
    }

    protected override void OnDropDown(System.EventArgs e)
    {
        base.OnDropDown(e);

        // adjust column width for DropDownWidth or AutoSize
        if (this.PerformResize)
            AdjustDropDownWidth();
    }

    // '
    // ' Changind DataSourceChanged
    // '

    // Private m_DataSource As Object
    // Private m_PrevDataSource As BindingSource
    // Private m_DataTable As DataTable
    // Private m_DataView As DataView

    // Public Overloads Property DataSource() As Object
    // Get
    // Return MyBase.DataSource ' tak musi być, bo jest to wykorzystywane w OurDataGridViewComboBoxCell.InitializeEditingControl
    // End Get
    // Set(ByVal value As Object)
    // If value IsNot m_DataSource Then
    // DataSourceSet(value)
    // End If
    // End Set
    // End Property

    // Friend Sub DataSourceSet(ByVal Value As Object)
    // ' add handler to catch datasourcechanged on bindingsource
    // If Me.m_PrevDataSource IsNot Nothing Then
    // RemoveHandler Me.m_PrevDataSource.DataSourceChanged, AddressOf OnBindingSourceChanged
    // Me.m_PrevDataSource = Nothing
    // End If

    // Me.m_DataSource = value

    // SetBaseDataSource(value)

    // If m_DataSource IsNot Nothing _
    // AndAlso TypeOf m_DataSource Is BindingSource Then
    // Dim bs As BindingSource = Me.m_DataSource
    // AddHandler bs.DataSourceChanged, AddressOf OnBindingSourceChanged
    // Me.m_PrevDataSource = bs
    // End If
    // End Sub


    // ' call missing event after datasourcechanged on bindingsouce
    // Private Sub OnBindingSourceChanged(ByVal caller As Object, ByVal arg As EventArgs)
    // Me.OnSelectedIndexChanged(EventArgs.Empty)

    // ' check SupportsFiltering on data source again
    // If Me.DataSource IsNot Nothing Then
    // SetBaseDataSource(Me.DataSource)
    // End If
    // End Sub

    // Private Sub SetBaseDataSource(ByVal value As Object)

    // Dim i As Integer

    // '
    // ' if datasouce doesn't support filtering -> change to DataView and DataTable
    // '
    // If Me.DropDownStyle = ComboBoxStyle.DropDown _
    // AndAlso TypeOf value Is System.ComponentModel.IBindingListView Then
    // Dim ok As Boolean
    // ok = True

    // ' leave only Linq-to-? dataSource, cancel old DataSet dataSources
    // If TypeOf value Is BindingSource Then
    // Dim v As BindingSource = value

    // 'If v.DataSource Is Nothing _
    // 'OrElse TypeOf v.DataSource Is Type Then
    // '    ok = False
    // 'End If
    // Do
    // If v.DataSource Is Nothing _
    // OrElse TypeOf v.DataSource Is Type _
    // OrElse TypeOf v.DataSource Is DataView _
    // OrElse TypeOf v.DataSource Is DataSet _
    // OrElse TypeOf v.DataSource Is DataTable Then
    // ok = False
    // Exit Do
    // End If
    // If Not TypeOf v.DataSource Is BindingSource Then
    // Exit Do
    // End If
    // v = v.DataSource
    // Loop
    // End If

    // Dim ds As System.ComponentModel.IBindingListView = value
    // If ok _
    // AndAlso Not ds.SupportsFiltering Then
    // ' create DataTable
    // Dim col1 As String
    // Dim col2 As String = Nothing
    // Me.m_DataTable = New DataTable("Table")

    // ' col1 -> ValueMember or self
    // If Me.ValueMember Is Nothing Then
    // col1 = "_Self"
    // Else
    // col1 = Me.ValueMember
    // End If
    // Me.m_DataTable.Columns.Add(col1, GetType(Object))

    // ' col2 -> don't add if the same as col1
    // If Me.DisplayMember IsNot Nothing AndAlso Me.DisplayMember <> col1 Then
    // col2 = Me.DisplayMember
    // Me.m_DataTable.Columns.Add(Me.DisplayMember, GetType(String))
    // End If

    // ' other columns
    // For Each c As Column In Me.Columns
    // If c.ColumnMember <> col1 AndAlso c.ColumnMember <> col2 Then
    // Me.m_DataTable.Columns.Add(c.ColumnMember, GetType(String))
    // End If
    // Next

    // ' copy all values
    // For Each itm As Object In ds
    // Dim row As DataRow
    // row = Me.m_DataTable.NewRow
    // If Me.ValueMember Is Nothing Then
    // row.Item(0) = Me
    // Else
    // row.Item(0) = ReflectValue(itm, Me.ValueMember)
    // End If
    // i = 1
    // If Me.DisplayMember IsNot Nothing AndAlso Me.DisplayMember <> col1 Then
    // row.Item(1) = ReflectValue(itm, Me.DisplayMember)
    // i += 1
    // End If
    // For Each c As Column In Me.Columns
    // If c.ColumnMember <> col1 AndAlso c.ColumnMember <> col2 Then
    // row.Item(i) = ReflectValue(itm, c.ColumnMember)
    // i += 1
    // End If
    // Next

    // Me.m_DataTable.Rows.Add(row)
    // Next

    // ' create DataView
    // Me.m_DataView = New DataView(Me.m_DataTable)
    // value = Me.m_DataView
    // End If
    // End If

    // MyBase.DataSource = value


    // End Sub


    // 'this method provides a way to refresh the data contains if they appear out of sync
    // 'this usually happens when the datasource is a simple object that does not implement IBindingList
    // Public Sub RefreshDataBinding()
    // 'skip if there is currently no datasource
    // If Me.DataSource Is Nothing Then Return

    // 'get old datasource
    // Dim oldSource As Object = Me.DataSource
    // Dim oldDisplay As String = Me.DisplayMember
    // Dim oldValue As String = Me.ValueMember
    // 'clear current source
    // Me.DataSource = Nothing
    // 'reset the datasource
    // Me.DataSource = oldSource
    // Me.DisplayMember = oldDisplay
    // Me.ValueMember = oldValue

    // End Sub


    protected void AdjustDropDownWidth()
    {
        // don't adjust if there is no datasource
        if (this.Items == null)
            return;
        // get content items
        IList list;
        if (this.Items.GetType().GetInterface("IListSource") != null)
            list = ((IListSource)this.Items).GetList();
        else
            list = (IList)this.Items;
        // adjust AutoSize columns width
        // this method call sets any autosize column width to the width
        // of the widest string in the content list
        AutosizeColumns(list);

        // aggregate column widths
        int maxWidth=0;
        foreach (OurDataGridViewComboBoxEditingControl2.Column col in _columns)
            maxWidth += col.Width;

        if (maxWidth > 0)
        {

            // check for scrollbars to add width to adjust for them
            // I didn't find an easy way to see if scrollbars were showing so
            // I simply assume here that more than 4 items means the scrollbars are shown
            if (this.Items.Count > MinItemsForScrollBar)
                // 36 is roughly the width of the scrollbar and if not
                // used the scrollbar will overlap some of the text
                maxWidth += ScrollBarWidth;

            this.DropDownWidth = maxWidth;
        }

        // reset resize flag
        this.PerformResize = false;
    }

    private void AutosizeColumns(IList list)
    {
        // loop through items in list
        if (this.Columns.Count > 0)
        {
            foreach (object item in list)
            {
                // loop through columns for this item
                foreach (OurDataGridViewComboBoxEditingControl2.Column col in this.Columns)
                {
                    var v = ReflectValue(item, col.ColumnMember);
                    if (v != null)
                    {
                        string? s = v.ToString();
                        if (s != null)  
                            col.Resize(s, this);
                    }
                }
            }
        }
    }

    private string GetDisplayText(string displayNullAs, object item, string member)
    {
        // for display purposes adjust the value for nulls
        object? value = ReflectValue(item, member);
        if (value == null || Information.IsDBNull(value))
            return displayNullAs;
        else
            return value.ToString()??displayNullAs;
    }

    private object? ReflectValue(object item, string member)
    {
        // get the text from the bound object by property name in the columnmember
        try
        {
            // handle getting the property differently if the datasource is a datarowview
            if (item is DataRowView)
            {
                DataRowView d = (DataRowView)item;
                // check for column exisitance
                if (d.DataView.Table!=null && d.DataView.Table.Columns.Contains(member))
                {
                    object value = d[member];
                    if (Information.IsDBNull(value))
                        return DBNull.Value;
                    else
                        return System.Convert.ToString(d[member]);
                }
            }
            // to increase performance we can check for the existance of the property first instead
            // of relying on an exception being thrown
            System.Reflection.PropertyInfo? pInfo = item.GetType().GetProperty(member);
            if (pInfo == null)
                return item.ToString();
            else
                // Return CType(pInfo.GetValue(item, Nothing), String)
                return pInfo.GetValue(item, null);
        }
        // display = CType(Items(ea.Index).GetType.GetProperty(col.ColumnMember).GetValue(Items(ea.Index), Nothing), String)
        catch (Exception )
        {
            if (item == null)
                return null;
            else
                return item.ToString();
        }
    }

    [System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    public extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);


    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        base.WndProc(ref m);

        // BUG FIX: Resizes the list height for small numbers of items with a header
        // 8465 is a combo command
        if (m.Msg == 8465 && this.ShowColumnHeader)
        {

            // 7 is the list dropping down but we are after the dropdown event and the base height setting
            if (m.WParam.ToInt32() >> 16 == 7 && this.Items.Count > 0)
            {
                // a dropdown event has been sent and the dropdown height set now change it
                // since the dropDownHandle is private we will use reflection to access the value anyway
                System.Reflection.FieldInfo? fi = typeof(ComboBox).GetField("dropDownHandle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                ArgumentNullException.ThrowIfNull(fi);
#pragma warning disable CS8605 // Unboxing a possibly null value.
                IntPtr hWnd = (IntPtr)fi.GetValue(this);
#pragma warning restore CS8605 // Unboxing a possibly null value.
                // get the height of all items if less than the max items
                int count = this.Items.Count;
                if (count > this.MaxDropDownItems)
                    count = this.MaxDropDownItems;
                // now adjust the height adding room for the header
                int ht = (this.ItemHeight * count) + this.ItemHeight;
                // use the API call to actually set the height of the list window
                SetWindowPos(hWnd, IntPtr.Zero, 0, 0, this.DropDownWidth, ht, 6);
            }
        }
    }


    /// -----------------------------------------------------------------------------
    ///     ''' Project	 : MultiColumnCombo
    ///     ''' Class	 : Controls.MultiColumnComboBox.Column
    ///     ''' -----------------------------------------------------------------------------
    ///     ''' <summary>
    ///     ''' Column object used to setup columns within the MultiColumnComboBox.
    ///     ''' </summary>
    ///     ''' <remarks>
    ///     ''' </remarks>
    ///     ''' <history>
    ///     ''' 	[ed]	6/11/2004	Created
    ///     ''' </history>
    ///     ''' -----------------------------------------------------------------------------
    ///     '''
    [Serializable()]
    public class Column
    {
        private const string DefaultDisplayNullAs = "";

        private int _Width;
        private string _ColumnMember="";
        private string _Header="";
        private bool _AutoSize = false;
        private Color _Color = SystemColors.Window;
        private string _DisplayNullAs = DefaultDisplayNullAs;

        // width of the column
        // if it exceed the width of the dropdownwidth then it will not be shown
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }

        // bound field or property that you want to display in this column
        public string ColumnMember
        {
            get
            {
                return _ColumnMember;
            }
            set
            {
                _ColumnMember = value;
            }
        }

        // header title
        public string Header
        {
            get
            {
                return _Header;
            }
            set
            {
                _Header = value;
            }
        }

        // set to try to automatically resize the column by the length of the longest text
        public bool AutoSize
        {
            get
            {
                return _AutoSize;
            }
            set
            {
                _AutoSize = value;
            }
        }

        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }

        // text to display if the value is NULL
        public string DisplayNullAs
        {
            get
            {
                return _DisplayNullAs;
            }
            set
            {
                _DisplayNullAs = value;
            }
        }

        public Column()
        {
            //base.@new();
        }

        public Column(string columnMember) : this(columnMember, string.Empty)
        {
        }

        public Column(string columnMember, string header)
        {
            // notice that if no width is specified then it defaults to autosize
            //base.@new();
            this.ColumnMember = columnMember;
            this.Header = header;
            this.AutoSize = true;
        }

        public Column(string columnMember, int width) : this(columnMember, columnMember, width)
        {
        }

        public Column(string columnMember, string header, int width)
        {
            //base.@new();
            this.Width = width;
            this.ColumnMember = columnMember;
            this.Header = header;
        }

        public virtual void Resize(string text, OurDataGridViewComboBoxEditingControl2 control)
        {
            if (_AutoSize)
            {
                // get buffer to account for the line or extra space
                int linebuffer = 5;
                // get width of content
                Graphics g = Graphics.FromHwnd(control.Handle);
                System.Drawing.SizeF sz = g.MeasureString(text, control.Font);
                // if content is wider than current width increase it
                int itemWidth = System.Convert.ToInt32(sz.Width + linebuffer);
                if (itemWidth > _Width)
                    _Width = itemWidth;

                if (control.ShowColumnHeader)
                {
                    // check if header is wider then current width
                    // if it is then adjust the width to fit the header
                    // but adjust the linebuffer to account for the header borders
                    linebuffer = 10;
                    sz = g.MeasureString(Header, control.Font);
                    // if content is wider than current width increase it
                    itemWidth = System.Convert.ToInt32(sz.Width + linebuffer);
                    if (itemWidth > _Width)
                        _Width = itemWidth;
                }
            }
        }
    }

    /// -----------------------------------------------------------------------------
    ///     ''' Project	 : MultiColumnCombo
    ///     ''' Class	 : Controls.MultiColumnComboBox.ColumnCollection
    ///     ''' -----------------------------------------------------------------------------
    ///     ''' <summary>
    ///     ''' Strongly Typed Collection object for columns within the MultiColumnComboBox.
    ///     ''' </summary>
    ///     ''' <remarks>
    ///     ''' </remarks>
    ///     ''' <history>
    ///     ''' 	[ed]	6/11/2004	Created
    ///     ''' </history>
    ///     ''' -----------------------------------------------------------------------------
    ///     '''
    public class ColumnCollection : CollectionBase
    {
        public event CountChangedEventHandler? CountChanged;

        // item
        public Column this[int index]
        {
            get
            {
                var c = (Column?)base.List[index];
                ArgumentNullException.ThrowIfNull(c);
                return c;
            }
            set
            {
                base.List[index] = value;
            }
        }

        // add
        public int Add(Column item)
        {
            return base.List.Add(item);
        }

        // remove
        public void Remove(Column item)
        {
            base.List.Remove(item);
        }

        // insert
        public void Insert(int index, Column item)
        {
            base.List.Insert(index, item);
        }

        // contains
        public bool Contains(Column item)
        {
            if (base.List.IndexOf(item) > -1)
                return true;   
            return false;
        }

        // indexof
        public int IndexOf(Column item)
        {
            return base.List.IndexOf(item);
        }

        protected override void OnClearComplete()
        {
            base.OnClearComplete();

            CountChanged?.Invoke(this, new OurDataGridViewComboBoxEditingControl2.CountChangedEventArgs(CountChangedEventArgs.ChangeTypes.Cleared));
        }

        protected override void OnInsertComplete(int index, object? value)
        {
            base.OnInsertComplete(index, value);

            CountChanged?.Invoke(this, new OurDataGridViewComboBoxEditingControl2.CountChangedEventArgs(CountChangedEventArgs.ChangeTypes.Increased, value));
        }

        protected override void OnRemoveComplete(int index, object? value)
        {
            base.OnRemoveComplete(index, value);

            CountChanged?.Invoke(this, new OurDataGridViewComboBoxEditingControl2.CountChangedEventArgs(CountChangedEventArgs.ChangeTypes.Decreased, value));
        }

        //internal void Add(object itm)
        //{
        //    throw new NotImplementedException();
        //}
    }



    // event delegate for CountChanged event
    public delegate void CountChangedEventHandler(object sender, CountChangedEventArgs e);

    /// -----------------------------------------------------------------------------
    ///     ''' Project	 : MultiColumnCombo
    ///     ''' Class	 : Controls.MultiColumnComboBox.CountChangedEventArgs
    ///     ''' -----------------------------------------------------------------------------
    ///     ''' <summary>
    ///     ''' Event arguments for the CountChanged Event of the ColumnCollection object.
    ///     ''' </summary>
    ///     ''' <remarks>
    ///     ''' </remarks>
    ///     ''' <history>
    ///     ''' 	[ed]	6/11/2004	Created
    ///     ''' </history>
    ///     ''' -----------------------------------------------------------------------------
    public class CountChangedEventArgs : EventArgs
    {
        public enum ChangeTypes
        {
            Increased,
            Decreased,
            Cleared
        }

        private ChangeTypes _ChangeType;
        private object? _Item;

        public ChangeTypes ChangeType
        {
            get
            {
                return _ChangeType;
            }
            set
            {
                _ChangeType = value;
            }
        }

        public object? Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
            }
        }

        public CountChangedEventArgs(ChangeTypes changetype) : this(changetype, null)
        {
        }

        public CountChangedEventArgs(ChangeTypes changetype, object? item)
        {
            //base.@new();
            _ChangeType = changetype;
            _Item = item;
        }
    }

    // bubble up the countchanged event for the columns collection
    private void _columns_CountChanged(object sender, CountChangedEventArgs e)
    {
        OnColumnCountChanged(e);
    }

    protected void OnColumnCountChanged(CountChangedEventArgs e)
    {
        ColumnCountChanged?.Invoke(this, e);
    }


    // 2010-01-29 - it doesn't work well... 

    // '=====================================================
    // ' Auto filtering during typing
    // '

    private void OurDataGridViewComboBoxEditingControl_TextUpdate(object sender, System.EventArgs e)
    {
        // mark cell as dirty, without this every second change doesn't set dirty flag
        // OnSelectedIndexChanged(New EventArgs)
        // 2010-08-10: better way:
        this.EditingControlValueChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
    }

    // Private Sub RecalculateFilter()
    // Try

    // If Me.DataSource Is Nothing Then Return

    // If MyBase.DisplayMember IsNot Nothing Then
    // Dim OK As Boolean
    // OK = False
    // If TypeOf MyBase.DataSource Is System.ComponentModel.IBindingListView Then
    // Dim ds As System.ComponentModel.IBindingListView = MyBase.DataSource
    // If ds.SupportsFiltering Then
    // Dim t As String

    // If ds.Filter Is Nothing Then
    // t = ""
    // Else
    // t = ds.Filter
    // End If

    // Dim text As String
    // text = Me.Text

    // ' constans
    // Dim prefix As String
    // Dim sufix As String
    // Dim aa As String
    // aa = ") and "
    // prefix = Me.DisplayMember & " like '*"
    // sufix = "*'"


    // ' remove previous
    // If t.Length > 0 Then
    // Dim i As Integer
    // i = t.IndexOf(prefix)
    // If i = 0 Then
    // t = ""
    // ElseIf i > 0 Then
    // t = t.Substring(1, i - Len(aa) - 1)
    // End If
    // End If


    // ' add new filter
    // If Me.Text.Length > 0 Then
    // If t.Length = 0 Then
    // t = prefix & text & sufix
    // Else
    // t = "(" & t & aa & prefix & text & sufix
    // End If
    // End If

    // Dim prevsel As Integer
    // Dim prevlen As Integer
    // prevsel = Me.SelectionStart
    // prevlen = Me.SelectionLength

    // If String.IsNullOrEmpty(t) Then
    // ds.Filter = Nothing
    // Else
    // ds.Filter = t
    // End If

    // Me.Text = text
    // Me.Select(prevsel, prevlen)
    // OK = True
    // End If

    // End If
    // End If
    // Catch ex As Exception
    // GbbLib.Log.Log(ex, TraceEventType.Error)
    // End Try
    // End Sub

    // =================================
    // Obsługa trybu ComboBox
    // 

    public new object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        object ret;
        string s;
        s = this.Text; // we need string
        ret = s;

        // search list of data and find matching item
        if (this.DropDownStyle == ComboBoxStyle.DropDown) // && !string.IsNullOrEmpty(ret))
        {
            if (this.DataManager != null)
            {
                bool retchanged = false;
                foreach (var itm in this.DataManager.List)
                {
                    string dslp;
                    dslp = GetDisplayText("", itm, this.DisplayMember);
                    if (dslp.StartsWith(s, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (dslp.Equals(s, StringComparison.CurrentCultureIgnoreCase))
                        {
                            ret = dslp; // small and big letters can be different, so update ret
                            break;
                        }
                        if (!retchanged)
                        {
                            retchanged = true;
                            ret = dslp;
                        }
                    }
                }
            }
            else if (this.Items.Count > 0)
            {
                bool retchanged = false;
                foreach (var itm in this.Items)
                {
                    string dslp;
                    dslp = GetDisplayText("", itm, this.DisplayMember);
                    if (dslp.StartsWith(s, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (dslp.Equals(s, StringComparison.CurrentCultureIgnoreCase))
                        {
                            ret = dslp; // small and big letters can be different, so update ret
                            break;
                        }
                        if (!retchanged)
                        {
                            retchanged = true;
                            ret = dslp;
                        }
                    }
                }
            }
        }
        return ret;
    }



    public override bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
    {
        if (this.DropDownStyle == ComboBoxStyle.DropDown)
        {
            switch ((keyData & Keys.KeyCode))
            {
                case Keys.Prior:
                case Keys.Next:
                    {
                        if (!this.EditingControlValueChanged)
                            break;
                        return true;
                    }

                case Keys.End:
                case Keys.Home:
                    {
                        if ((this.SelectionLength == this.Text.Length))
                            break;
                        return true;
                    }

                case Keys.Left:
                    {
                        if ((((this.RightToLeft != RightToLeft.No) || ((this.SelectionLength == 0) && (base.SelectionStart == 0))) && ((this.RightToLeft != RightToLeft.Yes) || ((this.SelectionLength == 0) && (base.SelectionStart == this.Text.Length)))))
                            break;
                        return true;
                    }

                case Keys.Right:
                    {
                        if ((((this.RightToLeft != RightToLeft.No) || ((this.SelectionLength == 0) && (base.SelectionStart == this.Text.Length))) && ((this.RightToLeft != RightToLeft.Yes) || ((this.SelectionLength == 0) && (base.SelectionStart == 0)))))
                            break;
                        return true;
                    }

                case Keys.Delete:
                    {
                        if (((this.SelectionLength <= 0) && (base.SelectionStart >= this.Text.Length)))
                            break;
                        return true;
                    }
            }
        }
        return base.EditingControlWantsInputKey(keyData, dataGridViewWantsInputKey);
    }
}
