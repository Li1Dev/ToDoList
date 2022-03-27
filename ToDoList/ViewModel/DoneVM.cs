using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ToDoList.Models;

namespace ToDoList.ViewModel
{
    public class DoneVM : ViewModelBase
    {
        private List<Task> allTasks = DataWorker.GetAllDoneTask();
        public List<Task> AllTasks
        {
            get { return allTasks; }
            set
            {
                allTasks = value;
                RaisePropertyChanged(() => AllTasks);
            }
        }

        private RelayCommand isDone_Click;
        public RelayCommand IsDone_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Task task = obj as Task;
                    if (task != null)
                    {
                        DataWorker.СhangeIsDone(task);
                        AllTasks = DataWorker.GetAllDoneTask();
                    }
                });
            }
        }

        private RelayCommand deleteTask_Click;
        public RelayCommand DeleteTask_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Task task = obj as Task;
                    if (task != null)
                    {
                        DataWorker.RemoveTask(task);
                        AllTasks = DataWorker.GetAllDoneTask();
                    }
                });
            }
        }
    }
}
