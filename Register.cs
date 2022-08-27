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

namespace PasswordManger
{
    public partial class Register : Form
    {
        DBConnection databaseConnection = new DBConnection();
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 previousWindow = new Form1();
            this.Hide();
            previousWindow.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            string email = textEmail.Text;
            string phone = textPhone.Text;
            string name = textName.Text;

            try
            {
                SqlConnection con = databaseConnection.getConn();
                con.Open();
                String query = "INSERT INTO [dbo].[User] (Username, Password, FullName, Email, Phone) VALUES ('" + username + "', '" + password + "', '" + name + "', '" + email + "', '" + phone + "');";
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();

                MessageBox.Show("User was created successfully", "User created", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Error submitting the request", "Database Error", MessageBoxButtons.OK);
            }
        }
    }
}
