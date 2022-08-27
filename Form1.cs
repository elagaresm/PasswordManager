using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManger
{
    public partial class Form1 : Form
    {
        DBConnection databaseConnection = new DBConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            try
            {
                
                SqlConnection con = databaseConnection.getConn();
                con.Open();
                String query = "SELECT * FROM [dbo].[User] WHERE Username = '" + username + "' AND Password = '" + password + "'";
                SqlCommand command = new SqlCommand(query, con);

                SqlDataReader reader = command.ExecuteReader();

                User currentUser = new User();

                if (reader.Read())
                {
                    currentUser.Id = (int)reader.GetValue(0);
                    currentUser.Username = reader.GetValue(1).ToString();
                    currentUser.Password = reader.GetValue(2).ToString();
                    currentUser.Name = reader.GetValue(3).ToString();
                    currentUser.Email = reader.GetValue(4).ToString();
                    currentUser.Phone = reader.GetValue(5).ToString();
                    

                    this.Hide();
                    Main mainForm = new Main(currentUser);
                    mainForm.Show();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Error submitting the request", "Database Error", MessageBoxButtons.OK);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register registerWindow = new Register();
            this.Hide();
            registerWindow.Show();
        }
    }
}
