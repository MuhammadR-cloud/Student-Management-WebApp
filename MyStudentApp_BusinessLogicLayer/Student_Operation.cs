using MyStudentApp_DataAccessLayer.Model;
using MyStudentApp_DataAccessLayer.DBOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudentApp_BusinessLogicLayer
{
    public class Student_Operation
    {
        public void AddStudent(Student student) 
        {
            Student_DBOperation student_DBOperation = new Student_DBOperation();
            student_DBOperation.AddNewStudent(student);
            
        
        }
        public List <Student> GetStudents()
        {
            Student_DBOperation student_DBOperation = new Student_DBOperation();
            return student_DBOperation.GetStudents();

        }

        public Student GetStudent(int StudentID)
        {
            Student_DBOperation student_DBOperation = new Student_DBOperation();
            return student_DBOperation.GetStudent( StudentID);


        }
        public void UpdateStudent(Student student)
        {
            Student_DBOperation student_DBOperation = new Student_DBOperation();
            student_DBOperation.UpdateStudent(student);
        }
        public void DeleteStudent(int StudentID)
        {
            Student_DBOperation student_DBOperation = new Student_DBOperation();
            student_DBOperation.DeleteStudent ( StudentID );
        }
    }

}
