/*
 * Author: Gbb Software 2002
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace GbbLibWin;


public class OurDataGridViewComboBoxCell2 : System.Windows.Forms.DataGridViewComboBoxCell
{

    public OurDataGridViewComboBoxCell2()
    {
        this.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
    }



    // 
    // Properties
    // 

    public OurDataGridViewComboBoxEditingControl2.ColumnCollection Columns
    {
        get
        {
            return m_columns;
        }
    }
    private OurDataGridViewComboBoxEditingControl2.ColumnCollection m_columns = new OurDataGridViewComboBoxEditingControl2.ColumnCollection();

    public OurDataGridViewComboBoxColumn2.EditStyles EditStyle
    {
        get
        {
            return m_EditStyle;
        }
        set
        {
            if (value != this.m_EditStyle)
                this.m_EditStyle = value;
        }
    }
    private OurDataGridViewComboBoxColumn2.EditStyles m_EditStyle = OurDataGridViewComboBoxColumn2.EditStyles.DropDown;


    // 
    // Creating
    // 

    public override object Clone()
    {
        OurDataGridViewComboBoxCell2 ret = (OurDataGridViewComboBoxCell2)base.Clone();

        //// we don't need clone columns, just copy
        //ret.Columns.Clear();
        //foreach (var itm in this.Columns)
        //    ret.Columns.Add(itm);

        ret.m_columns = this.m_columns;

        ret.EditStyle = this.EditStyle;

        return ret;
    }


    // 
    // Overiding
    // 

    public override Type EditType
    {
        get
        {
            return m_EditType;
        }
    }
    private Type m_EditType = typeof(OurDataGridViewComboBoxEditingControl2);


    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle)
    {
        // fill Items from Dictionary
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

        OurDataGridViewComboBoxEditingControl2? editingControl = DataGridView?.EditingControl as OurDataGridViewComboBoxEditingControl2;
        if (editingControl != null)
        {
            // Always recreate column list, because me.Columns can change 
            editingControl.Columns.Clear();
            foreach (var itm in this.Columns)
                editingControl.Columns.Add((OurDataGridViewComboBoxEditingControl2.Column)itm);
            editingControl.ShowColumns = true;

            if (this.EditStyle == OurDataGridViewComboBoxColumn2.EditStyles.ComboBox | this.EditStyle == OurDataGridViewComboBoxColumn2.EditStyles.ComboBoxLimitedToList)
            {
                // make combobox
                editingControl.DropDownStyle = ComboBoxStyle.DropDown;
                editingControl.Text = (string)initialFormattedValue; // if value was not on list, we must set it again
            }
            else
                // make drop down list box
                editingControl.DropDownStyle = ComboBoxStyle.DropDownList;
            editingControl.RefreshColumns();

            editingControl.Height *= 2;
        }
    }

    // correction of problem, when ComboBox must show value not on list -> just show value
    protected override object? GetFormattedValue(object value, int rowIndex, ref System.Windows.Forms.DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.Windows.Forms.DataGridViewDataErrorContexts context)
    {
        OurDataGridView? dg = this.DataGridView as OurDataGridView;
        if (dg == null)
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        else
        {
            var old = dg.DataErrorMustThrowException;
            try
            {
                dg.DataErrorMustThrowException = true;
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
            catch (Exception )
            {
                // on error just return value
                // TODO: value should be formated!
                if (value == null)
                    return null;
                else
                    return value.ToString();
            }
            finally
            {
                dg.DataErrorMustThrowException = old;
            }
        }
    }

    public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
    {
        if (this.EditStyle == OurDataGridViewComboBoxColumn2.EditStyles.ComboBox)
            // for Combobox -> don't check list 
            // don't try to find value on dropdownlist items (if can't find this causes error, so maybe we should coutch exception?!? )
            // BUG: we should call ParseFormattedValueInternal but it is private
            return formattedValue;
        else
            // for DropDown and ComboBoxLimitedToList -> check list
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
    }
}

