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
    partial class OurDataGridView_Zoom : Form
    {
        public string? OurText
        {
            get
            {
                return this.TextBox.Text;
            }
            set
            {
                this.TextBox.Text = value;
            }
        }

        public bool OurReadOnly
        {
            get
            {
                return this.TextBox.ReadOnly;
            }
            set
            {
                this.TextBox.ReadOnly = value;
                this.OK_Button.Enabled = !value;
            }
        }


        public OurDataGridView_Zoom()
        {
            InitializeComponent();
        }



        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


    }
}
