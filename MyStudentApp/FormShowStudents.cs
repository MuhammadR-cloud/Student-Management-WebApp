using MyStudentApp_DataAccessLayer.Model;
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

namespace MyStudentApp
{
    public partial class FormShow_Students : Form
    {
        public FormShow_Students()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = " select * from Student";
               SqlDataReader reader = command.ExecuteReader();
                List<Student> list = new List<Student>();
                while (reader.Read())
                {
                    Student studentNew = new Student();
                    studentNew.StudentID = Convert.ToInt32(reader[0]);
                    studentNew.FirstName = reader[1].ToString();
                    studentNew.MiddleName = reader[2].ToString();
                    studentNew.LastName = reader[3].ToString();
                    studentNew.AddressLine1 = reader[4].ToString();
                    studentNew.AddressLine2 = reader[5].ToString();
                    studentNew.City = reader[6].ToString();
                    studentNew.State = reader[7].ToString();
                    studentNew.ZipCode = reader[8].ToString();
                    studentNew.DateofBirth = Convert.ToDateTime(reader[9]);
                    studentNew.UpdatedOn = Convert.ToDateTime(reader[10]);

                    list.Add(studentNew);
                }
                dgvStudent.DataSource = list;

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            sqlConnection.Close();
        }
    }
}
