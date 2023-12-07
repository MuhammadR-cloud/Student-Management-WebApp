using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MyStudentApp_DataAccessLayer.Model;

namespace MyStudentApp_DataAccessLayer.DBOperation
{
    public class Student_DBOperation
    {
        string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
        public void AddNewStudent(Student student)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spInsertStudent";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //command.CommandText = "spGetStates";
                //command.CommandType = System.Data.CommandType.StoredProcedure;
                //SqlDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    cmbState.Items.Add(reader[1].ToString());
                //}

                command.Parameters.Add(new SqlParameter() { Value = student.FirstName, ParameterName ="@FirstName" });
                command.Parameters.Add(new SqlParameter() { Value = student.MiddleName, ParameterName = "@MiddleName" });
                command.Parameters.Add(new SqlParameter() { Value = student.LastName, ParameterName = "@LastName" });
                command.Parameters.Add(new SqlParameter() { Value = student.AddressLine1, ParameterName = "@AddrLine1" });
                command.Parameters.Add(new SqlParameter() { Value = student.AddressLine2, ParameterName = "@AddrLine2" });
                command.Parameters.Add(new SqlParameter() { Value = student.City, ParameterName = "@City" });
                command.Parameters.Add(new SqlParameter() { Value = student.State, ParameterName = "@State" });
                command.Parameters.Add(new SqlParameter() { Value = student.ZipCode, ParameterName = "@ZipC" });
                command.Parameters.Add(new SqlParameter() { Value = student.DateofBirth, ParameterName = "@DateOfBirth" });


                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {


            }


            sqlConnection.Close();

        }


        public List<Student> GetStudents()
        {
            List<Student> studentList = new List<Student>();
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spGetAllStudents";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                
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

                    studentList.Add(studentNew);
                }



            }
            catch (Exception ex)
            {


            }


            sqlConnection.Close();

            return studentList;

        }

        public Student GetStudent(int StudentID)
        {
            Student studentNew = new Student();
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spGetOneStudent";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.Direction = System.Data.ParameterDirection.Input;
                sqlParameter1.Value = StudentID;
                sqlParameter1.ParameterName = "@StudentID";
                sqlParameter1.DbType = System.Data.DbType.Int32;

                command.Parameters.Add(sqlParameter1);



                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
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

                    }

                }
            }

            catch (Exception ex)
            {

            }

            sqlConnection.Close();
            return studentNew;

        }
        public void UpdateStudent(Student student)
        {
           // string connString1 = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            { 
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spUpdateStudent";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter() { Value = student.FirstName, ParameterName = "@FirstName" });
                command.Parameters.Add(new SqlParameter() { Value = student.MiddleName, ParameterName = "@MiddleName" });
                command.Parameters.Add(new SqlParameter() { Value = student.LastName, ParameterName = "@LastName" });
                command.Parameters.Add(new SqlParameter() { Value = student.AddressLine1, ParameterName = "@AddrLine1" });
                command.Parameters.Add(new SqlParameter() { Value = student.AddressLine2, ParameterName = "@AddrLine2" });
                command.Parameters.Add(new SqlParameter() { Value = student.City, ParameterName = "@City" });
                command.Parameters.Add(new SqlParameter() { Value = student.State, ParameterName = "@State" });
                command.Parameters.Add(new SqlParameter() { Value = student.ZipCode, ParameterName = "@ZipC" });
                command.Parameters.Add(new SqlParameter() { Value = student.DateofBirth, ParameterName = "@DateOfBirth" });
                command.Parameters.Add(new SqlParameter() { Value = student.StudentID, ParameterName = "@StudentID" });

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }


            sqlConnection.Close();

        }

        public void DeleteStudent(int StudentID)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spDeleteStudent";
                command.CommandType = System.Data.CommandType.StoredProcedure;


                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }

            sqlConnection.Close();

        }
    }

}
    

