using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eWarehouseManagement.Domain;
using eWarehouseManagement.Helper;
using eWarehouseManagement.BAL;

namespace eWarehouseManagement
{
    public partial class ItemScanning : Form
    {
        public ItemScanning()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {

            //Validation check
            if (!Validation())
                return;


            if (!Helper.Helper.IsQtyNumeric(tbxQty.Text))
            {
                MessageBox.Show("Qty must be numeric!");
            }

            ItemModel objModel = new ItemModel();

            //Mapping UI values into your domain model

            objModel.SNo = ItemScanningBAL.scanneditems.Count() + 1;
            objModel.ItemName = tbxItemName.Text.Trim();
            objModel.ItemNo = tbxItemNo.Text.Trim();
            objModel.Location = cbxLocation.SelectedItem.ToString();
            objModel.Category = cbxCategory.SelectedItem.ToString();

            ItemScanningBAL objBL = new ItemScanningBAL();

            objBL.SaveInMemoryItemScanning(objModel);

            var bindingList = new BindingList<ItemModel>(ItemScanningBAL.scanneditems);
            var source = new BindingSource(bindingList, null);

            dgvitemscanned.DataSource = source;
            

            Reset();
        }

        private void Reset()
        {
            lblSNo.Text = Convert.ToString(ItemScanningBAL.scanneditems.Count() + 1);
            tbxItemNo.Text = string.Empty;
            tbxItemName.Text = string.Empty;
            tbxQty.Text = string.Empty;
            cbxLocation.SelectedIndex = 0;
            cbxCategory.SelectedIndex = 0;
        }

        private bool Validation()
        {

            if (tbxItemNo.Text.Equals(string.Empty))
            {
                MessageBox.Show("Item Number can not be blank!");
                tbxItemNo.Focus();
                return false;
            }
            else if (tbxItemName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Item Name can not be blank!");
                tbxItemName.Focus();
                return false;
            }
            else if (tbxQty.Text.Equals(string.Empty))
            {
                MessageBox.Show("Item Number can not be blank!");
                tbxQty.Focus();
                return false;
            }
            else if (cbxLocation.SelectedIndex.Equals(0))
            {
                MessageBox.Show("Please select Location!");
                cbxLocation.Focus();
                return false;
            }
            else if (cbxCategory.SelectedIndex.Equals(0))
            {
                MessageBox.Show("Please select Category!");
                cbxCategory.Focus();
                return false;
            }
            else
                return true;
        }

        private void tbxQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemScanning_Load(object sender, EventArgs e)
        {
            lblSNo.Text = "1";
            cbxLocation.SelectedIndex = 0;
            cbxCategory.SelectedIndex = 0;

            tbxItemNo.Focus();

        }
    }
}
