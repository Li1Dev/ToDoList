using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ToDoList.Models;

namespace ToDoList.ViewModel
{
    public class ToDoVM : ViewModelBase 
    {
        public ToDoVM()
        {
            ExecutionDate = DateTime.Now;
        }
        private DateTime executionDate;
        public DateTime ExecutionDate
        {
            get { return executionDate; }
            set
            {
                executionDate = value;
                RaisePropertyChanged(() => ExecutionDate);
            }
        }

        private TimeOnly executionTime;
        public TimeOnly ExecutionTime
        { 
            get { return executionTime; }
            set
            {
                executionTime = value;
                RaisePropertyChanged(() => ExecutionTime);
            }
        }

        private DateTime createDateTime;
        public DateTime CreateDateTime 
        {
            get { return createDateTime; }
            set 
            {
                createDateTime = value;
                RaisePropertyChanged(() => CreateDateTime);
            }
        }

        public bool isDone;
        public bool IsDone 
        {
            get { return isDone; }
            set
            {
                isDone = value;
                RaisePropertyChanged(() => IsDone);
            }
        }

        private string toDo;
        public string ToDo 
        {
            get { return toDo; }
            set 
            { 
                toDo = value;
                RaisePropertyChanged(() => ToDo);
            }
        }

        private DateTime executionDateTime;
        public DateTime ExecutionDateTime
        {
            get { return executionDateTime; }
            set
            {
                executionDateTime = value;
                RaisePropertyChanged(() => ExecutionDateTime);
            }
        }


        private List<Task> allTasks = DataWorker.GetAllTask();
        public List<Task> AllTasks
        {
            get { return allTasks; }
            set
            {
                allTasks = value;
                RaisePropertyChanged(() => AllTasks);
            }
        }

        public ICommand AddNewTask
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ExecutionDateTime = new DateTime(ExecutionDate.Year, ExecutionDate.Month, ExecutionDate.Day, ExecutionTime.Hour, ExecutionTime.Minute, 00);
                    CreateDateTime = DateTime.Now;
                    IsDone = false;
                if (ToDo != null && ExecutionDateTime != null)
                {
                    DataWorker.AddTask(CreateDateTime, IsDone, ToDo, ExecutionDateTime);
                }
                    ToDo = null;
                });
            }
        }
    }
}
