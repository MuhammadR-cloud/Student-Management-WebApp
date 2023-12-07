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
    public partial class FormUpdateStudent : Form
    {
        public FormUpdateStudent()
        {
            InitializeComponent();
        }

        private void FormUpdateStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = " select * from Student where StudentID =" + txtStudentID.Text;
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    
                    if (reader.Read())
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

                        txtFirstName.Text = studentNew.FirstName;
                        txtMiddleName.Text = studentNew.MiddleName;
                        txtLastName.Text = studentNew.LastName;
                        txtAddressLine1.Text = studentNew.AddressLine1;
                        txtAddressLine2.Text = studentNew.AddressLine2;
                        txtCity.Text = studentNew.City;
                        txtState.Text = studentNew.State;
                        txtZipCode.Text = studentNew.ZipCode;
                        dtpDOB.Value = studentNew.DateofBirth;
                    }
                }
                else
                {                  
                    txtFirstName.Text = "";
                    txtMiddleName.Text = "";
                    txtLastName.Text = "";
                    txtAddressLine1.Text = "";
                    txtAddressLine2.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtZipCode.Text = "";
                    dtpDOB.Value = DateTime.Now;

                    MessageBox.Show("No Data Found");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            sqlConnection.Close();
        }





        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {

        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student studentNew = new Student()
            {
                StudentID = Convert.ToInt32(txtStudentID.Text), 
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                AddressLine1 = txtAddressLine1.Text,

                AddressLine2 = txtAddressLine2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                ZipCode = txtZipCode.Text,
                DateofBirth = dtpDOB.Value

            };

            //UpdateDatabase(studentNew);
            MyStudentApp_BusinessLogicLayer.Student_Operation student_Operation = new MyStudentApp_BusinessLogicLayer.Student_Operation();
            student_Operation.UpdateStudent(studentNew);
        }

        //private void UpdateDatabase(Student student)
        //{
        //    string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(connString);

        //    try
        //    {
        //        sqlConnection.Open();
        //        SqlCommand command = sqlConnection.CreateCommand();
        //        command.CommandText = "update Student set " 
        //            + "FirstName = '" + txtFirstName.Text +"',"
        //            + "MiddleName = '" + txtMiddleName.Text + "',"
        //            + "LastName = '" + txtLastName.Text + "',"
        //            + "AddressLine1 = '" + txtAddressLine1.Text + "',"
        //            + "AddressLine2 = '" + txtAddressLine2.Text + "',"
        //            + "City = '" + txtCity.Text + "',"
        //            + "State = '" + txtState.Text + "',"
        //            + "ZipCode = '" + txtZipCode.Text + "',"
        //            + "DOB = '" + dtpDOB.Value.ToShortDateString() + "'"
        //            + " where StudentID = " + txtStudentID.Text;

        //        command.ExecuteNonQuery();

        //        MessageBox.Show("Student Updated Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }


        //    sqlConnection.Close();


        //}

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
    

