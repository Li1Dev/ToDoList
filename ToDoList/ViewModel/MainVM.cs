using DevExpress.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ToDoList.ViewModel
{
    public class MainVM : ViewModelBase
    {
        private Page AllTask;
        private Page ToDo;
        private Page Done;

        private static DateTime selectedDate;
        public DateTime SelectedDate
        { 
            get { return selectedDate; }
            set 
            { 
                selectedDate = value;
                UpdataPage();
                if (PresentPageName == "All Task")
                {
                    CurrentPage = AllTask;
                }
                else if (PresentPageName == "Done")
                {
                    CurrentPage = Done;
                }
                RaisePropertyChanged(() => SelectedDate);
            }
        }
        public static DateTime _SelectedDate 
        {
            get { return selectedDate; }
        }

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                RaisePropertyChanged(() => CurrentPage);
            }
        }

        private string presentPageName;
        public string PresentPageName
        {
            get { return presentPageName; }
            set
            {
                presentPageName = value;
                RaisePropertyChanged(() => presentPageName);
            }
        }

        public MainVM()
        {
            selectedDate = DateTime.Now;
            AllTask = new Views.Pages.AllTask();
            ToDo = new Views.Pages.ToDo();
            Done = new Views.Pages.Done();
            CurrentPage = AllTask;
            presentPageName = "All Task";
        }

        private void UpdataPage()
        {
            AllTask = new Views.Pages.AllTask();
            Done = new Views.Pages.Done();
        }



        #region MENU COMMAND
        public ICommand BtnMenuAllTask_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    UpdataPage();
                    CurrentPage = AllTask;
                    PresentPageName = "All Task";

                });
            }
        }
        public ICommand BtnMenuToDo_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CurrentPage = ToDo;
                    PresentPageName = "ToDo";
                });
            }
        }
        public ICommand BtnMenuDone_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    UpdataPage();
                    CurrentPage = Done;
                    PresentPageName = "Done";
                });
            }
        }
        #endregion
    }
}