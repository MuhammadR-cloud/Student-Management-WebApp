using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStudentApp
{
    public partial class FormDeleteStudent : Form
    {
        public FormDeleteStudent()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent(txtStudentID.Text);
        }

        private void DeleteStudent(String StudentID)
        {
            string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "delete from Student where StudentID = " + StudentID;

                command.ExecuteNonQuery();

                MessageBox.Show("Student Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            sqlConnection.Close();


        }

        private void FormDeleteStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
