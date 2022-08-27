using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace PasswordManger
{
    public partial class Main : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        DBConnection databaseConnection = new DBConnection();
        public User currentUser;
        
        public Main(User _currentUser)
        {
            InitializeComponent();
            this.labelName.Text = _currentUser.Name;
            this.labelEmail.Text = _currentUser.Email;
            this.labelPhone.Text = _currentUser.Phone;
            this.label6.Text += _currentUser.Id;
            currentUser = _currentUser;
            InitializeDataGridView();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {
        }

        private void btnAddPassword_Click(object sender, EventArgs e)
        {
            string URL = textURL.Text;
            string username = textUsername.Text;
            string password = textPassword.Text;
            int Id = currentUser.Id;
            try
            {
                SqlConnection con = databaseConnection.getConn();
                con.Open();
                String query = "INSERT INTO [dbo].[Password] (URL, Username, Password, UserID) VALUES ('" + URL + "', '" + username + "', '" + password + "', '" + Id + "');";
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();

                MessageBox.Show("Password was added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InitializeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - Error submitting the request", "Database Error", MessageBoxButtons.OK);
            }
        }

        public void InitializeDataGridView()
        {
            try
            {
                int Id = currentUser.Id;

                dataGridView1.AutoGenerateColumns = true;

                SqlConnection con = databaseConnection.getConn();
                con.Open();
                String query = "SELECT * FROM Password WHERE userID='" + Id + "';";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                var dt = new DataTable();

                sda.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Issue with DataView source : " + exception, "Data View Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
