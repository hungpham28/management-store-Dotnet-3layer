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
    public partial class FormLogin : Form
    {
        AccountBUS accountBUS=new AccountBUS();
        public static string loginname, logintype;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 1;
            txtUsername.Text = "admin1";
            txtPass.Text = "123456";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbRole.SelectedIndex>0)
                {
                    if (txtUsername.Text == String.Empty)
                    {
                        MessageBox.Show("Please Enter valid UserName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Focus();
                        return;
                    }
                    if (txtPass.Text==String.Empty)
                    {
                        MessageBox.Show("Please Enter valid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPass.Focus();
                        return;
                    }

                    if (cmbRole.SelectedIndex > 0 && txtUsername.Text != String.Empty && txtPass.Text != String.Empty)
                    {
                        //login code
                        if(cmbRole.Text=="Admin")
                        {
                            AdminDTO admin= accountBUS.checkAdmin(new AccountDTO(txtUsername.Text,txtPass.Text,cmbRole.Text));
                            if(admin!=null)
                            {
                                MessageBox.Show("Login Success Welcome to Home Page", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginname = txtUsername.Text;
                                logintype = cmbRole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login Please check userName and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            

                        }
                        else if(cmbRole.Text == "Seller")
                        {
                            SellerDTO seller=accountBUS.checkSeller(new AccountDTO(txtUsername.Text, txtPass.Text, cmbRole.Text));
                            if (seller!=null)
                            {
                                MessageBox.Show("Login Success Welcome to Home Page", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginname = txtUsername.Text;
                                logintype = cmbRole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login Please check userName and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clrValue();
                    }

                }
                else
                {
                    MessageBox.Show("Please select any role","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clrValue();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you really want to close this Application ?", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                Application.Exit();
            }
        }

        private void clrValue()
        {
            cmbRole.SelectedIndex = 0;
            txtUsername.Clear();
            txtPass.Clear();
        }
    }
}
