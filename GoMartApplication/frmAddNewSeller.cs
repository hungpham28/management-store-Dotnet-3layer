using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class frmAddNewSeller : Form
    {

        SellerBUS sellerBUS = new SellerBUS();
        public frmAddNewSeller()
        {
            InitializeComponent();
        }

        private void frmAddNewSeller_Load(object sender, EventArgs e)
        {
            lblSellerID.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
            BindSeller();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSellerName.Text == String.Empty)
            {
                MessageBox.Show("Please Enter seller name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSellerName.Focus();
                return;
            }
            else if (txtPass.Text == String.Empty)
            {
                MessageBox.Show("Please Enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return;
            }
            else
            {

                if (sellerBUS.IsExistUsername(txtSellerName.Text))
                {
                    MessageBox.Show("Seller Name already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClear();
                }
                else
                {
                    SellerDTO seller=new SellerDTO();   
                    seller.sellerName = txtSellerName.Text;
                    seller.sellerPhone = txtPhone.Text;
                    seller.sellerPass= txtPass.Text;
                    seller.sellerAge = Convert.ToInt32(txtAge.Text);
                    if (sellerBUS.Add(seller))
                    {
                        MessageBox.Show("Seller Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindSeller();
                    }
                }
            }
        }

        private void txtClear()
        {
            txtSellerName.Clear();
            txtAge.Clear();
            txtPass.Clear();
            txtPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSellerID.Text == String.Empty)
                {
                    MessageBox.Show("Please select sellerID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }
                if (txtSellerName.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSellerName.Focus();
                    return;
                }
                else if (txtPass.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                    return;
                }
                else
                {
                    if (sellerBUS.IsExistUsername(txtSellerName.Text))
                    {
                        MessageBox.Show( "Selle Name already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                    }
                    else
                    {
                        SellerDTO seller = new SellerDTO();
                        seller.sellerId = Convert.ToInt32(lblSellerID.Text);
                        seller.sellerName = txtSellerName.Text;
                        seller.sellerPhone = txtPhone.Text;
                        seller.sellerPass = txtPass.Text;
                        seller.sellerAge = Convert.ToInt32(txtAge.Text);
                        if (sellerBUS.Update(seller))
                        {
                            MessageBox.Show("Seller updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindSeller();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnAdd.Visible = true;
                            lblSellerID.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("update failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtClear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSellerID.Text == String.Empty)
                {
                    MessageBox.Show("Please select CategoryID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lblSellerID.Text != String.Empty)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (sellerBUS.DeleteById(Convert.ToInt32(lblSellerID.Text)))
                        {
                            MessageBox.Show("Seller Deleted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindSeller();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnAdd.Visible = true;
                            lblSellerID.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Delete failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtClear();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindSeller()
        {
            dataGridView1.DataSource = sellerBUS.getAllSeller();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lblSellerID.Visible = true;
            btnAdd.Visible = false;

            lblSellerID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtSellerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtAge.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPass.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
