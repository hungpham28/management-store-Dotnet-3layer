using BUS;
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
// nguyen code
namespace GoMartApplication
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        private void BindProductList()
        {
            ProductBUS bus = new ProductBUS();
            try
            {
                DataTable dt = bus.SelectAllProduct();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            BindCategory();
            BindProductList();
            lblProdID.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
            SearcgBy_Category();
        }

        private void BindCategory()
        {
            CategoryBUS catebus = new CategoryBUS();
            DataTable dt=catebus.spGetCategory();
            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CatID";
        }
        private void SearcgBy_Category()
        {
            CategoryBUS catebus = new CategoryBUS();
            DataTable dt = catebus.spGetCategory();
            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CatID";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductBUS productBUS = new ProductBUS();
            try
            {
                if (txtProdName.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProdName.Focus();
                    return;
                }
                else if (Convert.ToInt32(txtPrice.Text) < 0 || txtPrice.Text == String.Empty )
                {
                    MessageBox.Show("Please Enter valid price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return;
                }
                else if (txtQty.Text == String.Empty || Convert.ToInt32(txtQty.Text)< 0)
                {
                    MessageBox.Show("Please Enter valid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQty.Focus();
                    return;
                }
                else
                {
                    if (productBUS.CheckDuplicateProduct(txtProdName.Text,Convert.ToInt32(cmbCategory.SelectedValue)))
                    {
                        MessageBox.Show("Product Name already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                    }
                    else
                    {
                        if (productBUS.InsertProduct(txtProdName.Text, Convert.ToInt32(cmbCategory.SelectedValue), Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtQty.Text)))
                        {
                            MessageBox.Show("Product Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindProductList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void txtClear()
        {
            txtProdName.Clear();
            txtPrice.Clear();
            txtQty.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductBUS productBUS = new ProductBUS();
            try
            {
                if (lblProdID.Text=="" && txtProdName.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter ProductID and name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProdName.Focus();
                    return;
                }
                else if (txtPrice.Text == String.Empty && Convert.ToInt32(txtPrice.Text) >= 0)
                {
                    MessageBox.Show("Please Enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return;
                }
                else if (txtQty.Text == String.Empty && Convert.ToInt32(txtQty.Text) >= 0)
                {
                    MessageBox.Show("Please Enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQty.Focus();
                    return;
                }
                else
                {
                    if (productBUS.CheckDuplicateProduct(txtProdName.Text, Convert.ToInt32(cmbCategory.SelectedValue)))
                    {
                        MessageBox.Show("Product Name already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                    }
                    else
                    {
                        if (productBUS.UpdateProduct(txtProdName.Text, Convert.ToInt32(cmbCategory.SelectedValue), Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtQty.Text)))
                        {
                            MessageBox.Show("Product Updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindProductList();
                            lblProdID.Visible = false;
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Updation Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblProdID.Visible = true;
                btnAdd.Visible = false;

                lblProdID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtProdName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                cmbCategory.SelectedValue = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtQty.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductBUS productBUS= new ProductBUS();
            try
            {
                if (lblProdID.Text == String.Empty)
                {
                    MessageBox.Show("Please select Product ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lblProdID.Text != String.Empty)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (productBUS.DeleteProduct(Convert.ToInt32(lblProdID.Text)))
                        {
                            MessageBox.Show("Product Deleted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindProductList();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnAdd.Visible = true;
                            lblProdID.Visible = false;
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

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void Searched_ProductList()
        {
            ProductBUS productBUS = new ProductBUS();
            try
            {
                DataTable dt = productBUS.GetAllProductList_SearchByCat(Convert.ToInt32(cmbsearch.SelectedValue));
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Searched_ProductList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindProductList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
