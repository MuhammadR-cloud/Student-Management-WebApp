using MyStudentApp_DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudentApp_DataAccessLayer.DBOperation
{
    public class State_DBOperation
    {
        string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=StudentDataManagementSystem;Integrated Security=True";

        public List<string> GetStateNames()
        {
            List<string> states = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spGetStates";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //cmbState.Items.Add(reader[1].ToString());
                    states.Add(reader[0].ToString());
                }
               // command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {


            }


            sqlConnection.Close();

            return states;
        }

    }

    }


