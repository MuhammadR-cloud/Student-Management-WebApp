using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStudentApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddNewStudent formAddNewStudent = new FormAddNewStudent();
            formAddNewStudent.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormShow_Students formShow_Students = new FormShow_Students();
            formShow_Students.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUpdateStudent formUpdateStudent = new FormUpdateStudent();
            formUpdateStudent.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDeleteStudent formDeleteStudent = new FormDeleteStudent(); 
            formDeleteStudent.ShowDialog();
        }
    }
}
