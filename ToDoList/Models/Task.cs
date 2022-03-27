using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsDone { get; set; }
        public string ToDo { get; set; }
        public DateTime ExecutionDateTime { get; set; }
    }
}
