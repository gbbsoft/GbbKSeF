/*
 * Author: Gbb Software 2002
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GbbLibWin
{
    partial class OurDataGridView_Find_Form : Form
    {

        public OurDataGridView? OurDataGridView;
        private static System.Windows.Forms.AutoCompleteStringCollection LastText = new System.Windows.Forms.AutoCompleteStringCollection();

        public OurDataGridView_Find_Form()
        {
            InitializeComponent();

        }

        private void OurDataGridView_Find_Form_Load(object sender, EventArgs e)
        {
            ArgumentNullException.ThrowIfNull(OurDataGridView);

            this.TextBox.AutoCompleteCustomSource = OurDataGridView_Find_Form.LastText;
            this.TextBox.Text = this.OurDataGridView.OurFindText ?? "";
            this.TextBox.SelectionStart = 0;
            this.TextBox.SelectionLength = this.TextBox.Text.Length;

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // add text to list
                bool ok;
                ok = true;
                foreach (string s in OurDataGridView_Find_Form.LastText)
                {
                    if (s == this.TextBox.Text)
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    OurDataGridView_Find_Form.LastText.Insert(0, this.TextBox.Text);
                }

                if (this.OurDataGridView is object)
                {
                    this.OurDataGridView.OurFindText = this.TextBox.Text;
                    if (!this.OurDataGridView.OurFindNext())
                    {
                        MessageBox.Show(this.FindForm(), "Can't find text: \"" + this.TextBox.Text + "\"");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.FindForm(), ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            this.OK_Button.Enabled = this.TextBox.Text.Length > 0;
        }

    }
}
