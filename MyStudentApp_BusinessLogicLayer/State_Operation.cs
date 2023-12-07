using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudentApp_BusinessLogicLayer
{
    public class State_Operation
    {
        public List<string> GetStates()
        {
            MyStudentApp_DataAccessLayer.DBOperation.State_DBOperation state_DBOperation = new MyStudentApp_DataAccessLayer.DBOperation.State_DBOperation();
            return state_DBOperation.GetStateNames();
        }
    }
}
