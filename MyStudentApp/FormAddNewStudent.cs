using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MyStudentApp_DataAccessLayer.Model;
using MyStudentApp_BusinessLogicLayer;
using System.Net.NetworkInformation;
using MyStudentApp_DataAccessLayer.DBOperation;

namespace MyStudentApp
{
    public partial class FormAddNewStudent : Form
    {
        public FormAddNewStudent()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student studentNew = new Student()
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                AddressLine1 = txtAddressLine1.Text,
                AddressLine2 = txtAddressLine2.Text,
                City = txtCity.Text,
                State = cmbState.SelectedItem.ToString(),
                ZipCode = txtZipCode.Text,
                DateofBirth = dtpDOB.Value

            };

            Student_Operation student_Operation = new Student_Operation();
            student_Operation.AddStudent(studentNew);
        }


        /*
        private void InsertIntoDatabase(Student student)
        {
            string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);
            
            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "insert into Student (FirstName, MiddleName, LastName, AddressLine1, AddressLine2, City, State, Zipcode, DOB) " +
                    "values " + " ('" + student.FirstName + "',  '" + student.MiddleName + "', '" + student.LastName + "', '" + student.AddressLine1 + "', '" + student.AddressLine2 + "', '" + student.City + "', '" + student.State + "', '" + student.ZipCode + "', '" + student.DateofBirth.ToShortDateString() + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Student Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
            
            sqlConnection.Close();

        }   */


        private void FormAddNewStudent_Load(object sender, EventArgs e)
        {


            //Figure out a way to get the list of states from BusinessLogicLayer to DataAccessLayer
            MyStudentApp_BusinessLogicLayer.State_Operation state_Operation = new State_Operation();
            cmbState.DataSource = state_Operation.GetStates();

            //string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
            //SqlConnection sqlConnection = new SqlConnection(connString);

            //try
            //{
            //    sqlConnection.Open();
            //    SqlCommand command = sqlConnection.CreateCommand();
            //    command.CommandText = "select * from State";
            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        cmbState.Items.Add(reader[1].ToString());
            //    }
            //    // command.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}

            //sqlConnection.Close();

        }

    }
    }
    
