using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Data;

namespace ToDoList.Models
{
    public class DataWorker
    {
        public static void СhangeIsDone(Task task)
        {
            using (TaskContext db = new TaskContext())
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
                task.IsDone = !task.IsDone;
                AddTask(task.CreateDateTime, task.IsDone, task.ToDo, task.ExecutionDateTime);
               
            }
        }
        public static List<Task> GetAllTask()
        {
            using (TaskContext db = new TaskContext())
            {
                var rezult = db.Tasks.ToList();
                return rezult;
            }
        }
        public static List<Task> GetAllDoneTask()
        {
            using (TaskContext db = new TaskContext())
            {
                var rezult = db.Tasks.Where(p => p.IsDone == true).ToList();
                return rezult;
            }
        }
        public static List<Task> GetAllNotDoneTask(DateTime date)
        {
            using (TaskContext db = new TaskContext())
            {
                var rezult = db.Tasks.Where(p => p.IsDone == false && p.ExecutionDateTime == date).ToList();
                return rezult;
            }
        }

        public static List<Task> GetAllNotDoneTask()
        {
            using (TaskContext db = new TaskContext())
            {
                var rezult = db.Tasks.Where(p => p.IsDone == false).ToList();
                return rezult;
            }
        }

        //Add task
        public static string AddTask(DateTime createDateTime, bool isDone, string toDo, DateTime executionDateTime)
        {
            string rezult = "Уже есть";
            using (TaskContext db = new TaskContext())
            {
                bool checkIsExist = db.Tasks.Any(el => el.CreateDateTime == createDateTime && el.IsDone == isDone && el.ToDo == toDo && el.ExecutionDateTime == executionDateTime);
                if (!checkIsExist)
                {
                    Task task = new Task
                    {
                        CreateDateTime = createDateTime,
                        IsDone = isDone,
                        ToDo = toDo,
                        ExecutionDateTime = executionDateTime
                    };
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    rezult = "Сделано";
                }
                return rezult;
            }
        }
        //Remove task
        public static string RemoveTask(Task task)
        {
            string rezult = "Такого клиента нет";
            using (TaskContext db = new TaskContext())
            {
                bool checkIsExist = db.Tasks.Any(el => el == task);
                if (checkIsExist)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    rezult = "Сделано";
                }
                return rezult;
            }
        }

    }
}
