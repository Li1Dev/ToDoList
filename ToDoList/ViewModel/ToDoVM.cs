using DevExpress.Mvvm;
using System;
using System.Windows.Input;
using ToDoList.Models;

namespace ToDoList.ViewModel
{
    public class ToDoVM : ViewModelBase 
    {
        public ToDoVM()
        {
            ExecutionDateTime = DateTime.Now;
        }

        #region Fields and properties for the model
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

        private bool setReminder;
        public bool SetReminder 
        { 
            get { return setReminder; }
            set
            { 
                setReminder = value;
                RaisePropertyChanged(() => SetReminder);
            }
        }
        #endregion

        public ICommand AddNewTask
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (ToDo != null | ToDo == "")
                    {
                        DataWorker.AddTask(DateTime.Now, false, ToDo, ExecutionDateTime);
                    }
                    ToDo = null;
                });
            }
        }
    }
}
