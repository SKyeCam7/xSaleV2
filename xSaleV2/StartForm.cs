using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xSaleV2
{
    public partial class StartForm : Form
    {

        // DECLERATION
        private String path;
        private OpenFileDialog openDialog;
        public StartForm()
        {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            // INITIALIZATION
            openDialog = new OpenFileDialog();
            openDialog.Title = "Select file";
            openDialog.InitialDirectory = @"c:\";
            openDialog.Filter = "Excel 2003(*.xlsx)|*.xlsx|Excel 2013(*.xlsx)|*.xlsx";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;

            // Get and check user's selection
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if (openDialog.FileName != "")
                {
                    path = openDialog.FileName;
                }
                else
                {
                    MessageBox.Show("chose Excel sheet path..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Run function to open selected file in new window
            OpenProductForm();
        }

        public void OpenProductForm()
        {
            ImportForm inForm = new ImportForm(path);
            this.Hide();
            inForm.Show();
        }
    }
}
