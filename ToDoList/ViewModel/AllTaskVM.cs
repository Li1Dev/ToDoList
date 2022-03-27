using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using ToDoList.Models;



namespace ToDoList.ViewModel
{
    public class AllTaskVM : ViewModelBase
    {
        private static bool isFirstStart = true;

        public AllTaskVM()
        {
            SelectedDate = MainVM._SelectedDate;
            AllTasks = DataWorker.GetAllNotDoneTask(SelectedDate);
        }



        private static DateTime selectedDate;
        public static DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
            }

        }
        

        private List<Task> allTasks;
        public List<Task> AllTasks
        {
            get { return allTasks; }
            set
            {
                allTasks = value;
                RaisePropertyChanged(() => AllTasks);
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
                        AllTasks = DataWorker.GetAllNotDoneTask(SelectedDate);
                    }
                });
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
                        AllTasks = DataWorker.GetAllNotDoneTask(SelectedDate);
                        MessageBox.Show(SelectedDate.Day.ToString());
                    }
                });
            }
        }
    }
}
