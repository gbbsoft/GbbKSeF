/*
 * Author: Gbb Software 2002
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace GbbLibWin;


// 
// TODO: We don't support changes in Columns after creating cells from templates
// 


[Designer("System.Windows.Forms.Design.DataGridViewComboBoxColumnDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ToolboxBitmap(typeof(OurDataGridViewComboBoxColumn2), "DataGridViewComboBoxColumn.bmp")]
public class OurDataGridViewComboBoxColumn2 : System.Windows.Forms.DataGridViewComboBoxColumn
{


    // 
    // Creating
    // 

    public OurDataGridViewComboBoxColumn2() : base()
    {
        m_columns = new OurDataGridViewComboBoxEditingControl2.ColumnCollection();
        _m_columns = new OurDataGridViewComboBoxEditingControl2.ColumnCollection();

        // overides CellTemplate setting
        this.CellTemplate = new OurDataGridViewComboBoxCell2();

        this.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
        this.SortMode = DataGridViewColumnSortMode.Automatic;
    }

    public enum EditStyles
    {
        DropDown,
        ComboBox,
        ComboBoxLimitedToList
    }

    // 
    // Properties
    // 

    [Description("Edit style of control.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public EditStyles EditStyle
    {
        get
        {
            return m_EditStyle;
        }
        set
        {
            if (value != this.m_EditStyle)
            {
                this.m_EditStyle = value;

                OurDataGridViewComboBoxCell2? tmpl;
                tmpl = this.CellTemplate as OurDataGridViewComboBoxCell2;
                if (tmpl != null)
                    tmpl.EditStyle = value;
            }
        }
    }
    private EditStyles m_EditStyle = EditStyles.DropDown;


    [Description("The column information for the list.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public OurDataGridViewComboBoxEditingControl2.ColumnCollection Columns
    {
        get
        {
            return m_columns;
        }
    }
    private OurDataGridViewComboBoxEditingControl2.ColumnCollection _m_columns;

    private OurDataGridViewComboBoxEditingControl2.ColumnCollection m_columns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _m_columns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_m_columns != null)
            {
                _m_columns.CountChanged -= m_columns_CountChanged;
            }

            _m_columns = value;
            if (_m_columns != null)
            {
                _m_columns.CountChanged += m_columns_CountChanged;
            }
        }
    }

    private void m_columns_CountChanged(object sender, OurDataGridViewComboBoxEditingControl2.CountChangedEventArgs e)
    {
        OurDataGridViewComboBoxCell2? tmpl;
        tmpl = this.CellTemplate as OurDataGridViewComboBoxCell2;

        // copy columns to template
        if (tmpl != null)
        {
            tmpl.Columns.Clear();
            foreach (var itm in this.Columns)
                tmpl.Columns.Add((OurDataGridViewComboBoxEditingControl2.Column)itm);
        }
    }


    public override object Clone()
    {
        OurDataGridViewComboBoxColumn2 ret = (OurDataGridViewComboBoxColumn2)base.Clone();

        // we don't need clone columns, just copy
        //ret.Columns.Clear();
        //foreach (var itm in this.Columns)
        //    ret.Columns.Add(itm);

        ret.m_columns = this.m_columns;

        ret.EditStyle = this.EditStyle;

        return ret;
    }
}
