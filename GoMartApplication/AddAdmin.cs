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
//nguyen code
namespace GoMartApplication
{
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminBUS adminBUS = new AdminBUS();
            //add new admin
            try
            {
                if (txtAdminName.Text == String.Empty || txtAdminID.Text == String.Empty || txtPass.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter valid admin name, admin User ID and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clrbtn();
                }
                else
                {
                    //check duplicate record
                    bool result=adminBUS.checkDuplicateRecord(lblAdminID.Text);
                    if (result)
                    {
                        MessageBox.Show("Admin ID already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        clrbtn();
                    }
                    else
                    {
                        if (adminBUS.InsertAdmin(lblAdminID.Text, txtPass.Text, txtAdminName.Text))
                        {
                            MessageBox.Show("Admin Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clrbtn();
                            BindAdmin();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BindAdmin()
        {
            AdminBUS adminBUS=new AdminBUS();
            DataTable dt = adminBUS.selectAll();
            dataGridView1.DataSource = dt;
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {
            lblAdminID.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
            txtAdminName.Focus();
            BindAdmin(); 
        }
        private void clrbtn()
        {
            txtAdminID.Clear();
            txtAdminName.Clear();
            txtPass.Clear();
            txtAdminName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminBUS adminBUS = new AdminBUS();
            try
            {
                if (txtAdminName.Text == String.Empty || txtAdminID.Text == String.Empty || txtPass.Text == String.Empty || lblAdminID.Text==String.Empty)
                {
                    MessageBox.Show("Please Enter valid admin name, admin User ID and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clrbtn();
                }
                else
                {
                    if (adminBUS.UpdateAdmin(lblAdminID.Text, txtAdminName.Text, txtPass.Text))
                    {
                        MessageBox.Show("Admin record updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clrbtn();
                        BindAdmin();
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
            AdminBUS adminBUS = new AdminBUS();
            try
            {
                if(lblAdminID.Text==String.Empty)
                {
                    MessageBox.Show("Please select Admin record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (adminBUS.DeleteAdmin(lblAdminID.Text))
                        {
                            MessageBox.Show("Seller Deleted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clrbtn();
                            BindAdmin();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnAdd.Visible = true;
                            lblAdminID.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Delete failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clrbtn();
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
                lblAdminID.Visible = true;
                btnAdd.Visible = false;

                lblAdminID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtAdminID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtPass.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtAdminName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        
        }

        private void txtAdminName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
